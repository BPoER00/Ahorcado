using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahorcado.Models
{
    [Table("Dificultades")]
    public class Dificultades
    {
        [Key]
        public int IdDificultad { get; set; }
        public string Dificultad { get; set; }
    }
}