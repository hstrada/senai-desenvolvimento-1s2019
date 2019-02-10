using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Senai.Svigufo.Api.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";
        private string queryASerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> listaTiposEventos = new List<TipoEventoDomain>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand(queryASerExecutada, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TipoEventoDomain tipoEvento = new TipoEventoDomain
                    {
                        Id = Convert.ToInt32(rdr["ID"]),
                        Nome = rdr["TITULO"].ToString()
                    };

                    listaTiposEventos.Add(tipoEvento);
                }
                con.Close();
            }
            return listaTiposEventos;
        }

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            throw new NotImplementedException();
        }

        public TipoEventoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            throw new NotImplementedException();
        }
   
    }
}
