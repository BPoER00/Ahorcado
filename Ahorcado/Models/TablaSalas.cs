using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahorcado.Models
{
    [Table("TablaSalas")]
    public class TablaSalas
    {
        [Key]
        public int Id { get; set; }
        public string Palabra { get; set; }
        public int Token { get; set; } 
    }
}