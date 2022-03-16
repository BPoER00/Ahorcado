using Microsoft.EntityFrameworkCore;

namespace Ahorcado.Models
{
    public class Conexion : DbContext
    {
        public Conexion (DbContextOptions<Conexion> options) : base(options)
        {

        }

        public DbSet<Palabras> Palabras { get; set; }
        public DbSet<Dificultades> Dificultades { get; set; }        

        public DbSet<TablaSalas> TablaSalas { get; set; }
    }
}