using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AulaApi.Models
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            DataCadastro = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
    }
}