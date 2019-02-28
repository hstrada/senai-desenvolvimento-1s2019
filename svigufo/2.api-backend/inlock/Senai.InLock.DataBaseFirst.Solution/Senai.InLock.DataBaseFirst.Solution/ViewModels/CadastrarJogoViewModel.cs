using Microsoft.AspNetCore.Http;
using System;

namespace Senai.InLock.DataBaseFirst.Solution.ViewModels
{
    public class CadastrarJogoViewModel
    {
        public int Jogoid { get; set; }
        public string Nomejogo { get; set; }
        public string Descricao { get; set; }
        public DateTime Datalancamento { get; set; }
        public decimal? Valor { get; set; }
        public IFormFile Imagem { get; set; }
        public int Estudioid { get; set; }
    }
}
