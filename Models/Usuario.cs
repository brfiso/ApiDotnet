using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AulaApi.Models
{
    [Table("Usuario")]
    public class Usuario : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(11)")]
        public string Cpf { get; set; }
    }
}