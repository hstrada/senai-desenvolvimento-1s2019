using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Instituicao
{
    public class InstituicaoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social da Instituição.")]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter 14 caracteres.")]
        public string Cnpj { get; set; }
        public string Logradouro { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 caracteres.")]
        public string Cep { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve conter 2 caracteres.")]
        public string Uf { get; set; }
        public string Cidade { get; set; }
    }
}
