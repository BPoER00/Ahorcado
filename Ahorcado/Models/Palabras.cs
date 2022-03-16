using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahorcado.Models
{
    [Table("Palabras")]
    public class Palabras
    {
        [Key]
        public int Id { get; set; }
        public string Palabra { get; set; }
        public int IdDificultad { get; set; }

        public virtual Dificultades Dificultades { get; set; }
    }
}