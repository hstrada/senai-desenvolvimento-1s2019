using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Games.Domain.Domains
{
    [Table("Jogos")]
    public class JogoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogoId { get; set; }

        [Column("Nome", TypeName = "varchar(150)")]
        [Required]
        public string Nome { get; set; }

        [Column("Descricao", TypeName = "Text")]
        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataLancamento { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public Decimal Valor { get; set; }

        [Required]
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        public EstudioDomain Estudio { get; set; }
    }
}