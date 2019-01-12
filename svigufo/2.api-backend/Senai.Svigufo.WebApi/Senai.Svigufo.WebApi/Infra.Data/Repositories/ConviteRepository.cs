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
    public class ConviteRepository : IConviteRepository
    {

        private readonly string stringDeConexao;

        public ConviteRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public void EntrarEvento(ConviteDomain domain)
        {

            string buscarEvento = "Select Acesso_Livre from Eventos Where Id = @Id";
            string entrarEvento = "INSERT INTO CONVITES(ID_USUARIO, ID_EVENTO, PALESTRANTE, APROVADO) VALUES " +
                "(@Id_usuario, @Id_Evento, @Palestrante, @Aprovado)";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {

                    // transaction = con.BeginTransaction();

                    bool acessoLivreEvento;

                    //using (SqlCommand cmdEndereco = new SqlCommand(inserirEndereco, con))
                    using (SqlCommand cmdEvento = new SqlCommand(buscarEvento, con, transaction))
                    {
                        cmdEvento.Parameters.AddWithValue("@Id", domain.IdEvento);

                        acessoLivreEvento = (bool)cmdEvento.ExecuteScalar();
                        cmdEvento.Dispose();
                    }

                    // using (SqlCommand cmdUsuario = new SqlCommand(inserirUsuario, con))
                    using (SqlCommand cmdEntrarEvento = new SqlCommand(entrarEvento, con, transaction))
                    {
                        cmdEntrarEvento.Parameters.AddWithValue("@Id_usuario", domain.IdUsuario);
                        cmdEntrarEvento.Parameters.AddWithValue("@Id_Evento", domain.IdEvento);
                        cmdEntrarEvento.Parameters.AddWithValue("@Palestrante", false);
                        if (acessoLivreEvento == false)
                        {
                            cmdEntrarEvento.Parameters.AddWithValue("@Aprovado", false);
                        }
                        else
                        {
                            cmdEntrarEvento.Parameters.AddWithValue("@Aprovado", true);
                        }
                        
                        cmdEntrarEvento.ExecuteNonQuery();
                    }

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    throw new Exception("Ocorreu um erro ao entrar no evento.");
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}
