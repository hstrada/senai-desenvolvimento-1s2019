using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;
using Senai.Svigufo.WebApi.ViewModels.Evento;
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

        public void Cadastrar(EventoDomain eventoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                //CONVERT(DATETIME, @Data_Cadastro,120)
                string comandoSQL = "Insert into Eventos (Titulo, Descricao, DAta_Evento, Data_Cadastro, Acesso_Livre, ID_Tipo_Evento) " +
                    "Values(@Titulo, @Descricao, CONVERT(DATETIME, @Data_Evento,120), GETDATE() , @Acesso_Livre, @Id_Tipo_Evento)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Titulo", eventoDomain.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", eventoDomain.Descricao);
                cmd.Parameters.AddWithValue("@Data_Evento", eventoDomain.DataEvento);
                // cmd.Parameters.AddWithValue("@Data_Cadastro", eventoDomain.DataCadastro);
                cmd.Parameters.AddWithValue("@Acesso_Livre", eventoDomain.AcessoLivre);
                cmd.Parameters.AddWithValue("@Id_Tipo_Evento", eventoDomain.TipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void CadastrarPalestrante(PalestranteViewModel viewModel)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Insert into convites (Id_Usuario, Id_EVento, Palestrante, Aprovado) VALUES" +
                " (@Id_Usuario, @Id_Evento, @Palestrante, @Aprovado) ";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Id_Usuario", viewModel.IdUsuario);
                cmd.Parameters.AddWithValue("@Id_Evento", viewModel.IdEvento);
                cmd.Parameters.AddWithValue("@Palestrante", viewModel.Palestrante);
                cmd.Parameters.AddWithValue("@Aprovado", viewModel.Aprovado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<EventosViewModel> Listar()
        {
            List<EventosViewModel> listaEventos = new List<EventosViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand("SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO, E.DESCRICAO AS DESCRICAO, U.NOME AS PALESTRANTE FROM EVENTOS E INNER JOIN CONVITES C ON E.ID = C.ID_EVENTO INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID;", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EventosViewModel evento = new EventosViewModel
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
