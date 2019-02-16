using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.Svigufo.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
