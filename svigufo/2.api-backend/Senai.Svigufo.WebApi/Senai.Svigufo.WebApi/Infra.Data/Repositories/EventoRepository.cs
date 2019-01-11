using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string stringDeConexao;

        public EventoRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }


        public IEnumerable<EventoViewModel> Listar()
        {
            List<EventoViewModel> listaEventos = new List<EventoViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand("SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO, E.DESCRICAO AS DESCRICAO, U.NOME AS PALESTRANTE FROM EVENTOS E INNER JOIN CONVITES C ON E.ID = C.ID_EVENTO INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID;", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EventoViewModel evento = new EventoViewModel
                    {
                        Id = Convert.ToInt32(rdr["ID_EVENTO"]),
                        Titulo = rdr["TITULO"].ToString(),
                        Descricao = rdr["DESCRICAO"].ToString(),
                        Palestrante = rdr["PALESTRANTE"].ToString()
                    };
                    listaEventos.Add(evento);
                }
                con.Close();
            }
            return listaEventos;
        }

    }
}
