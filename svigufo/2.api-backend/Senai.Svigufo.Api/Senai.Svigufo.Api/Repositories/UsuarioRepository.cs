using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.ViewModels;
using System;
using System.Data.SqlClient;

namespace Senai.Svigufo.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";

        public UsuarioDomain BuscarPorEmailESenha(LoginViewModel login)
        {
            string QueryEmailSenha = "SELECT ID, NOME, EMAIL, TIPO_USUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QueryEmailSenha, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", login.Email);
                    cmd.Parameters.AddWithValue("@SENHA", login.Senha);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();
                        while (rdr.Read())
                        {
                            usuarioBuscado.Id = Int32.Parse(rdr["ID"].ToString());
                            usuarioBuscado.Email = rdr["EMAIL"].ToString();
                            usuarioBuscado.Nome = rdr["NOME"].ToString();
                            usuarioBuscado.TipoUsuario = rdr["TIPO_USUARIO"].ToString();
                        }
                        return usuarioBuscado;
                    }

                }
                return null;
            }

        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            string QueryInsert = "INSERT INTO USUARIOS (NOME, EMAIL, SENHA, TIPO_USUARIO) VALUES (@NOME, @EMAIL, @SENHA, @TIPO_USUARIO)";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@TIPO_USUARIO", usuario.TipoUsuario);

                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
