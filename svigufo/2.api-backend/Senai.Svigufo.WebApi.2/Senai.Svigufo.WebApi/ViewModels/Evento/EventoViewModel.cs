using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Evento
{
    public class EventoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "A data do evento não pode ser nula.")]
        public DateTime DataEvento { get; set; }

        [DefaultValue(1)]
        public bool AcessoLivre { get; set; }

        [Required(ErrorMessage = "O tipo do evento não pode ser nulo.")]
        public TipoEventoDomain TipoEvento { get; set; }

        [Required(ErrorMessage = "A instituição não pode ser nula.")]
        public InstituicaoDomain Instituicao { get; set; }
    }
}
