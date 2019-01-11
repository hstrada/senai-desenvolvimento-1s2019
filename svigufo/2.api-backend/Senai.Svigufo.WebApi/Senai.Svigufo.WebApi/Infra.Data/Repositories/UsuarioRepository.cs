using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public void Cadastrar(UsuarioViewModel usuario)
        {

            string inserirEndereco = "Insert into Enderecos (Logradouro, CEP, UF, Cidade, Latitude, Longitude) OUTPUT Inserted.ID VALUES (@Logradouro, @CEP, @UF, @Cidade, @Latitude, @Longitude);";
            string inserirUsuario = "Insert into Usuarios (Nome, Email, Senha, Tipo_Usuario, ID_Endereco) Values(@Nome, @Email, @Senha, @Tipo_Usuario, @ID_Endereco)";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                con.Open();

                int idEndereco;

                using (SqlCommand cmdEndereco = new SqlCommand(inserirEndereco, con))
                {
                    cmdEndereco.Parameters.AddWithValue("@Logradouro", usuario.Logradouro);
                    cmdEndereco.Parameters.AddWithValue("@Cep", usuario.Cep);
                    cmdEndereco.Parameters.AddWithValue("@Uf", usuario.Uf);
                    cmdEndereco.Parameters.AddWithValue("@Cidade", usuario.Cidade);
                    cmdEndereco.Parameters.AddWithValue("@Latitude", usuario.Latitude);
                    cmdEndereco.Parameters.AddWithValue("@Longitude", usuario.Longitude);

                    idEndereco = (Int32) cmdEndereco.ExecuteScalar();
                    cmdEndereco.Dispose();
                }

                using (SqlCommand cmdUsuario = new SqlCommand(inserirUsuario, con))
                {
                    cmdUsuario.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmdUsuario.Parameters.AddWithValue("@Email", usuario.Email);
                    cmdUsuario.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmdUsuario.Parameters.AddWithValue("@Tipo_Usuario", usuario.TipoUsuario);
                    cmdUsuario.Parameters.AddWithValue("@ID_Endereco", idEndereco);

                    cmdUsuario.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public IEnumerable<UsuarioViewModel> Listar()
        {
            List<UsuarioViewModel> listaUsuarios = new List<UsuarioViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand("SELECT U.*, E.* from Usuarios u INNER JOIN Enderecos E ON U.ID_ENDERECO = E.ID", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UsuarioViewModel usuario = new UsuarioViewModel
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Nome = rdr["Nome"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Logradouro = rdr["Logradouro"].ToString()
                    };
                    //TipoEventoViewModel tipoEvento = new TipoEventoViewModel();
                    //tipoEvento.Id = Convert.ToInt32(rdr["Id"]);
                    //tipoEvento.Titulo = rdr["Titulo"].ToString();
                    listaUsuarios.Add(usuario);
                }
                con.Close();
            }
            return listaUsuarios;
        }

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
