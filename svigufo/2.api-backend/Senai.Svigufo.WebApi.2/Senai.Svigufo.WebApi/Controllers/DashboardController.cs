using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels.Dashboard;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ListarDadosDashboard()
        {

            return Ok(_dashboardRepository.BuscarDadosDashboard());
        }
        
    }
}
