using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private readonly string stringDeConexao;

        public TipoEventoRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // private readonly string stringDeConexao = @"Data Source=DESKTOP-NI0NFG1;Initial Catalog=SVIGUFO;Integrated Security=True;";

        public void Cadastrar(TipoEventoDomain tipoEventoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Insert into Tipos_Eventos (Titulo) Values(@Titulo)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Titulo", tipoEventoDomain.Titulo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> listaTiposEventos = new List<TipoEventoDomain>();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Tipos_Eventos", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TipoEventoDomain tipoEvento = new TipoEventoDomain
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Titulo = rdr["Titulo"].ToString()
                    };
                    //TipoEventoViewModel tipoEvento = new TipoEventoViewModel();
                    //tipoEvento.Id = Convert.ToInt32(rdr["Id"]);
                    //tipoEvento.Titulo = rdr["Titulo"].ToString();
                    listaTiposEventos.Add(tipoEvento);
                }
                con.Close();
            }
            return listaTiposEventos;
        }

        public TipoEventoDomain BuscarPorId(int id)
        {
            TipoEventoDomain tipoEvento = new TipoEventoDomain();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Select * From Tipos_Eventos Where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader lerOsRegistros = cmd.ExecuteReader();
                if (lerOsRegistros.HasRows)
                {
                    while (lerOsRegistros.Read())
                    {
                        tipoEvento.Id = Int32.Parse(lerOsRegistros["Id"].ToString());
                        tipoEvento.Titulo = lerOsRegistros["Titulo"].ToString();
                    }
                    return tipoEvento;
                }
                con.Close();
            }

            return null;
        }
        
        public void Atualizar(TipoEventoDomain tipoEventoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Update Tipos_Eventos set Titulo = @Titulo Where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Titulo", tipoEventoDomain.Titulo);
                cmd.Parameters.AddWithValue("@Id", tipoEventoDomain.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Delete from Tipos_Eventos where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
