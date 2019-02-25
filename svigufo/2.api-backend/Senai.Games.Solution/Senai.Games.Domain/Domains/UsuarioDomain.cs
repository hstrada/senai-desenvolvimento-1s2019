using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senai.Games.Domain.Domains
{
    [Table("Usuarios")]
    public class UsuarioDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column("Email", TypeName = "varchar(150)")]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Column("Senha", TypeName = "varchar(150)")]
        [Required]
        public string Senha { get; set; }

        [Column("TipoUsuario", TypeName = "varchar(150)")]
        public string TipoUsuario { get; set; }
    }
}
