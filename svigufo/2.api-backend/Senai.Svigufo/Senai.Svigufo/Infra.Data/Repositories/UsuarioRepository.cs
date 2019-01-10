using Senai.Svigufo.Domain;
using Senai.Svigufo.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.Infra.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly string stringDeConexao = @"Data Source=DESKTOP-NI0NFG1;Initial Catalog=SVIGUFO;Integrated Security=True;";

        // public UsuarioDomain BuscarPorEmailSenha(LoginViewModel model)
        public UsuarioViewModel BuscarPorEmailSenha(LoginViewModel model)
        {

            // UsuarioDomain usuarioBuscado = new UsuarioDomain();
            UsuarioViewModel usuarioBuscado = new UsuarioViewModel();
            
            // Cria um objeto do tipo SqlConnection 
            using (SqlConnection sqlConnection = new SqlConnection(stringDeConexao))
            {

                // Query SQL que será executada
                // string queryDeBuscaPorEmailSenha = "SELECT * FROM USUARIOS WHERE EMAIL = '" + model.Email + "' AND SENHA = '" + model.Senha + "'";
                // famoso joana d'arc
                string queryDeBuscaPorEmailSenha = "SELECT * FROM USUARIOS WHERE EMAIL = @email AND SENHA = @senha";

                // Abre a conexão
                sqlConnection.Open();

                // Cria um objeto do tipo SqlCommand(query que eu quero executar, aonde eu quero executar)
                SqlCommand comando = new SqlCommand(queryDeBuscaPorEmailSenha, sqlConnection);
                comando.Parameters.AddWithValue("@email", model.Email);
                comando.Parameters.AddWithValue("@senha", model.Senha);
                
                // Envia o comando e recebe um DataReader no retorno
                SqlDataReader lerOsRegistros = comando.ExecuteReader();
                // Caso ele encontre registros
                if (lerOsRegistros.HasRows)
                {
                    // Caso ele encontre, o valor do viewmodel será atualizado com todos os registros encontrados no banco de dados
                    while (lerOsRegistros.Read())
                    {
                        usuarioBuscado.Id = Int32.Parse(lerOsRegistros["Id"].ToString());
                        usuarioBuscado.Email = lerOsRegistros["Email"].ToString();
                        usuarioBuscado.Nome = lerOsRegistros["Nome"].ToString();
                        usuarioBuscado.TipoUsuario = lerOsRegistros["TIPO_USUARIO"].ToString();
                    }
                    return usuarioBuscado;
                }
                // Uma vez executada a query, fecha a conexão
                sqlConnection.Close();
            }

            return null;

        }
    }
}
