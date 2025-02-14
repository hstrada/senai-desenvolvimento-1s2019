﻿using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enum;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;
using Senai.Svigufo.WebApi.ViewModels.Convite;
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

        public void AprovarConvite(int idConvite)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string aprovarEntrada = "UPDATE Convites SET Situacao = 2 Where Id = @Id";
                SqlCommand cmd = new SqlCommand(aprovarEntrada, con);
                cmd.Parameters.AddWithValue("@Id", idConvite);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void EntrarEvento(ConviteDomain domain)
        {

            string buscarEvento = "Select Acesso_Livre from Eventos Where Id = @Id";
            string entrarEvento = "INSERT INTO CONVITES(ID_USUARIO, ID_EVENTO, SITUACAO) VALUES " +
                "(@Id_usuario, @Id_Evento, @Situacao)";

            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
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
                        if (acessoLivreEvento == false)
                        {
                            cmdEntrarEvento.Parameters.AddWithValue("@Situacao", EnSituacaoConvite.AGUARDANDO);
                        }
                        else
                        {
                            cmdEntrarEvento.Parameters.AddWithValue("@Situacao", EnSituacaoConvite.CONFIRMADO);
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

        public IEnumerable<ConvitesViewModel> MeusEventos(int idUsuario)
        {
            string meusEventos = "SELECT C.ID AS ID, C.SITUACAO AS SITUACAO, E.TITULO AS TITULO, E.DATA_EVENTO AS DATA_EVENTO, T.TITULO AS TIPO_EVENTO FROM CONVITES C INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID INNER JOIN TIPOS_EVENTOS T ON E.ID_TIPO_EVENTO = T.ID AND C.ID_USUARIO = @Id;";
            List<ConvitesViewModel> listaEventos = new List<ConvitesViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand(meusEventos, con);
                cmd.Parameters.AddWithValue("@Id", idUsuario);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ConvitesViewModel convite = new ConvitesViewModel
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        // Situacao = (EnSituacaoConvite) rdr["Situacao"],
                        Titulo = rdr["Titulo"].ToString(),
                        DataEvento = (DateTime)rdr["DATA_EVENTO"],
                        TipoEvento = rdr["Tipo_Evento"].ToString(),
                    };

                    listaEventos.Add(convite);
                }
                con.Close();
            }
            return listaEventos;
        }

        public IEnumerable<ConvitesViewModel> TodosOsEventos()
        {

            List<ConvitesViewModel> listaEventos = new List<ConvitesViewModel>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string eventosSQL = "SELECT C.ID, C.SITUACAO, E.TITULO, E.DATA_EVENTO, T.TITULO AS TIPO_EVENTO FROM CONVITES C INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID INNER JOIN TIPOS_EVENTOS T ON E.ID_TIPO_EVENTO = T.ID WHERE C.STATUS = 1 and E.ACESSO_LIVRE = 0";
                SqlCommand cmd = new SqlCommand(eventosSQL, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ConvitesViewModel convite = new ConvitesViewModel
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        // Situacao = (EnSituacaoConvite)rdr["Situacao"],
                        Titulo = rdr["Titulo"].ToString(),
                        DataEvento = (DateTime) rdr["DATA_EVENTO"],
                        TipoEvento = rdr["Tipo_Evento"].ToString(),
                    };
                    
                    listaEventos.Add(convite);
                }
                con.Close();
            }
            return listaEventos;
            
        }
    }
}
