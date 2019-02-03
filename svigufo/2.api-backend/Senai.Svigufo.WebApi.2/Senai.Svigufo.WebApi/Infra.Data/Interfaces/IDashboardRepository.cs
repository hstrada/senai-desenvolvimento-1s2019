using Senai.Svigufo.WebApi.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IDashboardRepository
    {
        #region Leitura
        DashboardViewModel BuscarDadosDashboard();
        #endregion

    }
    
}