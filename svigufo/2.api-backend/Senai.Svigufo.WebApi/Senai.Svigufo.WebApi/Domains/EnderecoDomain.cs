using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class EnderecoDomain
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
