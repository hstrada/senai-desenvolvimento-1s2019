﻿using Microsoft.Extensions.Configuration;
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
                string comandoSQL = "Insert into Eventos (Titulo, Descricao, DAta_Evento, Acesso_Livre, ID_Tipo_Evento, ID_INSTITUICAO) " +
                    "Values(@Titulo, @Descricao, CONVERT(DATETIME, @Data_Evento,120), @Acesso_Livre, @Id_Tipo_Evento, @Id_Instituicao)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Titulo", eventoDomain.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", eventoDomain.Descricao);
                cmd.Parameters.AddWithValue("@Data_Evento", eventoDomain.DataEvento);
                cmd.Parameters.AddWithValue("@Acesso_Livre", eventoDomain.AcessoLivre);
                cmd.Parameters.AddWithValue("@Id_Tipo_Evento", eventoDomain.TipoEvento.Id);
                cmd.Parameters.AddWithValue("@Id_Instituicao", eventoDomain.Instituicao.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Atualizar(EventoDomain eventoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                //CONVERT(DATETIME, @Data_Cadastro,120)
                string comandoSQL = "UPDATE EVENTOS SET Titulo = @Titulo, Id_Instituicao = @Id_Instituicao ,Descricao = @Descricao, DAta_Evento = CONVERT(DATETIME, @Data_Evento,120), Acesso_Livre = @Acesso_Livre, ID_Tipo_Evento" +
                    " = @Id_Tipo_Evento WHERE ID = @Id ";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Titulo", eventoDomain.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", eventoDomain.Descricao);
                cmd.Parameters.AddWithValue("@Data_Evento", eventoDomain.DataEvento);
                cmd.Parameters.AddWithValue("@Acesso_Livre", eventoDomain.AcessoLivre);
                cmd.Parameters.AddWithValue("@Id_Tipo_Evento", eventoDomain.TipoEvento.Id);
                cmd.Parameters.AddWithValue("@Id_Instituicao", eventoDomain.Instituicao.Id);
                cmd.Parameters.AddWithValue("@Id", eventoDomain.Id);
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
                SqlCommand cmd = new SqlCommand("SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO, E.DESCRICAO AS DESCRICAO, E.DATA_EVENTO FROM EVENTOS E;", con);
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
                        DataEvento = rdr["DATA_EVENTO"].ToString()

                    };
                    listaEventos.Add(evento);
                }
                con.Close();
            }
            return listaEventos;
        }

    }
}
