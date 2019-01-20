using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly string stringDeConexao;

        public DashboardRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public DashboardViewModel BuscarDadosDashboard()
        {
            string meusEventos = "SELECT  (SELECT COUNT(*) FROM TIPOS_EVENTOS) AS QTD_TIPOSEVENTOS,"
            + "(SELECT COUNT(*) FROM USUARIOS) AS QTD_USUARIOS,"
            + "(SELECT COUNT(*) FROM EVENTOS WHERE ACESSO_LIVRE = 1) AS QTD_EVENTOS_PUBLICOS,"
            + "(SELECT COUNT(*) AS QTD_EVENTOS_PRIVADO FROM EVENTOS WHERE ACESSO_LIVRE = 0) AS QTD_EVENTOS_PRIVADO;";
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                SqlCommand cmd = new SqlCommand(meusEventos, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dashboardViewModel.TiposEventos = (int) rdr["QTD_TIPOSEVENTOS"];
                    dashboardViewModel.Usuarios = (int)rdr["QTD_USUARIOS"];
                    dashboardViewModel.EventosPublicos = (int)rdr["QTD_EVENTOS_PUBLICOS"];
                    dashboardViewModel.EventosPrivados = (int)rdr["QTD_EVENTOS_PRIVADO"];
                }
                con.Close();
            }
            return dashboardViewModel;
        }
    }
}
