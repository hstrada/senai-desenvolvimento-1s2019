using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enum;
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

            string inserirUsuario = "Insert into Usuarios (Nome, Email, Senha, Tipo_Usuario) Values(@Nome, @Email, @Senha, @Tipo_Usuario)";
            
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
                    // transaction = con.BeginTransaction();
                    
                    // using (SqlCommand cmdUsuario = new SqlCommand(inserirUsuario, con))
                    using (SqlCommand cmdUsuario = new SqlCommand(inserirUsuario, con, transaction))
                    {
                        cmdUsuario.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmdUsuario.Parameters.AddWithValue("@Email", usuario.Email);
                        cmdUsuario.Parameters.AddWithValue("@Senha", usuario.Senha);
                        cmdUsuario.Parameters.AddWithValue("@Tipo_Usuario", usuario.TipoUsuario);

                        cmdUsuario.ExecuteNonQuery();
                    }

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    throw new Exception("Ocorreu um erro ao realizar a inserção do usuário");
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public IEnumerable<UsuarioViewModel> Listar()
        {
            List<UsuarioViewModel> listaUsuarios = new List<UsuarioViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand("SELECT U.* FROM USUARIOS U", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UsuarioViewModel usuario = new UsuarioViewModel
                    {

                        Nome = rdr["Nome"].ToString(),
                        Email = rdr["Email"].ToString(),
                        
                    };

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
                        if (lerOsRegistros["TIPO_USUARIO"].ToString() == "ADMINISTRADOR")
                            usuario.TipoUsuario = EnTiposUsuario.ADMINISTRADOR;
                        else
                            usuario.TipoUsuario = EnTiposUsuario.COMUM;
                    }
                    return usuario;
                }
                con.Close();
            }

            return null;

        }
    }
}
