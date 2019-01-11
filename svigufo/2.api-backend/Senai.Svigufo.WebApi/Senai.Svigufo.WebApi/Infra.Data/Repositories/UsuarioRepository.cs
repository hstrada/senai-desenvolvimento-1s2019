using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string stringDeConexao;

        public UsuarioRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public UsuarioDomain Login(string email, string senha)
        {

            UsuarioDomain usuario = new UsuarioDomain();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Select * From Usuarios Where Email = @Email AND Senha = @Senha";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);
                con.Open();
                SqlDataReader lerOsRegistros = cmd.ExecuteReader();
                if (lerOsRegistros.HasRows)
                {
                    while (lerOsRegistros.Read())
                    {
                        usuario.Id = Int32.Parse(lerOsRegistros["Id"].ToString());
                        usuario.Email = lerOsRegistros["Email"].ToString();
                        usuario.TipoUsuario = lerOsRegistros["TIPO_USUARIO"].ToString();
                    }
                    return usuario;
                }
                con.Close();
            }

            return null;

        }
    }
}
