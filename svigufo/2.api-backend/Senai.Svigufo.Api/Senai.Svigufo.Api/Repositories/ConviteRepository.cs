using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Domains.Enums;
using Senai.Svigufo.Api.Interfaces;

namespace Senai.Svigufo.Api.Repositories
{
    public class ConviteRepository : IConviteRepository
    {

        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";

        public List<ConviteDomain> Listar()
        {
            throw new System.NotImplementedException();
        }

        public List<ConviteDomain> ListarMeusConvites(int id)
        {
           
            List<ConviteDomain> convites = new List<ConviteDomain>();
            string QuerySelect = "SELECT C.ID AS ID_CONVITE, C.SITUACAO" +
                ", E.ID AS ID_EVENTO, E.TITULO AS TITULO_EVENTO, E.DATA_EVENTO, E.ACESSO_LIVRE" +
                ", TE.TITULO AS TIPO_EVENTO" +
                " FROM CONVITES C " +
                " INNER JOIN EVENTOS E " +
                " ON C.ID_EVENTO = E.ID" +
                " INNER JOIN TIPOS_EVENTOS TE" +
                " ON E.ID_TIPO_EVENTO = TE.ID" +
                " WHERE C.ID_USUARIO = @ID; ";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain
                        {
                            Id = Convert.ToInt32(rdr["ID_CONVITE"]),
                            Situacao = (EnSituacaoConvite) Convert.ToInt32(rdr["SITUACAO"]),
                            Evento = new EventoDomain
                            {
                                Titulo = rdr["TITULO_EVENTO"].ToString(),
                                TipoEvento = new TipoEventoDomain
                                {
                                    Nome = rdr["TIPO_EVENTO"].ToString()
                                }
                            }
                        };

                        convites.Add(convite);
                    }
                }
            }

            return convites;
        }
    }
}
