﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;

namespace Senai.Svigufo.Api.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";

        public void Atualizar(int id, EventoDomain evento)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "UPDATE EVENTOS SET " +
                    "TITULO = @TITULO, " +
                    "ID_INSTITUICAO = @ID_INSTITUICAO," +
                    "DESCRICAO = @DESCRICAO, " +
                    "DATA_EVENTO = CONVERT(DATETIME, @DATA_EVENTO, 120), " +
                    "ACESSO_LIVRE = @ACESSO_LIVRE, " +
                    "ID_TIPO_EVENTO = @ID_TIPO_EVENTO " +
                    "WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);
                cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public EventoDomain BuscarPorId(int id)
        {
            // string queryASerExecutada = "SELECT ID, TITULO, DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_INSTITUICAO, ID_TIPO_EVENTO FROM EVENTOS";
            string queryASerExecutada = "SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO_EVENTO, E.DESCRICAO, E.DATA_EVENTO, E.ACESSO_LIVRE" +
                ", I.ID AS ID_INSTITUICAO, I.NOME_FANTASIA AS NOME_INSTITUICAO" +
                ", TE.ID AS ID_TIPO_EVENTO ,TE.TITULO AS TIPO_EVENTO " +
                "FROM EVENTOS E INNER JOIN INSTITUICOES I ON E.ID_INSTITUICAO = I.ID " +
                "INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID" +
                "WHERE ID = @ID;";


            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {

                using (SqlCommand cmd = new SqlCommand(queryASerExecutada, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            EventoDomain evento = new EventoDomain
                            {
                                Id = Convert.ToInt32(rdr["ID_EVENTO"]),
                                Titulo = rdr["TITULO_EVENTO"].ToString(),
                                Descricao = rdr["DESCRICAO"].ToString(),
                                DataEvento = Convert.ToDateTime(rdr["DATA_EVENTO"].ToString()),
                                AcessoLivre = rdr["ACESSO_LIVRE"].ToString().Equals("True") ? true : false,
                                Instituicao = new InstituicaoDomain
                                {
                                    Id = Convert.ToInt32(rdr["ID_INSTITUICAO"]),
                                    NomeFantasia = rdr["NOME_INSTITUICAO"].ToString()
                                },
                                TipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(rdr["ID_TIPO_EVENTO"]),
                                    Nome = rdr["TIPO_EVENTO"].ToString()
                                }
                            };

                            return evento;
                        }
                    }
                }
            }

            return null;
        }

        public void Cadastrar(EventoDomain evento)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "INSERT INTO EVENTOS (TITULO, DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_TIPO_EVENTO, ID_INSTITUICAO) " +
                    "Values(@TITULO, @DESCRICAO, CONVERT(DATETIME, @DATA_EVENTO,120), @ACESSO_LIVRE, @ID_TIPO_EVENTO, @ID_INSTITUICAO)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);
                cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
        public List<EventoDomain> Listar()
        {
            // string queryASerExecutada = "SELECT ID, TITULO, DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_INSTITUICAO, ID_TIPO_EVENTO FROM EVENTOS";
            string queryASerExecutada = "SELECT E.ID AS ID_EVENTO, E.TITULO AS TITULO_EVENTO, E.DESCRICAO, E.DATA_EVENTO, E.ACESSO_LIVRE" +
                ", I.ID AS ID_INSTITUICAO, I.NOME_FANTASIA AS NOME_INSTITUICAO" +
                ", TE.ID AS ID_TIPO_EVENTO ,TE.TITULO AS TIPO_EVENTO " +
                "FROM EVENTOS E INNER JOIN INSTITUICOES I ON E.ID_INSTITUICAO = I.ID " +
                "INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID;";

            List<EventoDomain> eventos = new List<EventoDomain>();
            
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
              
                using (SqlCommand cmd = new SqlCommand(queryASerExecutada, con))
                {
                   
                    con.Open();
                    
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        //EventoDomain evento = new EventoDomain
                        //{
                        //    Id = Convert.ToInt32(rdr["ID"]),
                        //    Titulo = rdr["TITULO"].ToString(),
                        //    Descricao = rdr["DESCRICAO"].ToString(),
                        //    DataEvento = Convert.ToDateTime(rdr["DATA_EVENTO"].ToString()),
                        //    AcessoLivre = rdr["ACESSO_LIVRE"].ToString().Equals("True") ? true : false
                        //};


                        EventoDomain evento = new EventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID_EVENTO"]),
                            Titulo = rdr["TITULO_EVENTO"].ToString(),
                            Descricao = rdr["DESCRICAO"].ToString(),
                            DataEvento = Convert.ToDateTime(rdr["DATA_EVENTO"].ToString()),
                            AcessoLivre = rdr["ACESSO_LIVRE"].ToString().Equals("True") ? true : false,
                            Instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(rdr["ID_INSTITUICAO"]),
                                NomeFantasia = rdr["NOME_INSTITUICAO"].ToString()
                            },
                            TipoEvento = new TipoEventoDomain
                            {
                                Id = Convert.ToInt32(rdr["ID_TIPO_EVENTO"]),
                                Nome = rdr["TIPO_EVENTO"].ToString()
                            }
                        };

                        eventos.Add(evento);
                    }
                }
            }

            return eventos;
        }

    }
}
