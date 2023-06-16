using Microsoft.EntityFrameworkCore;
using ProjetoGR.Models;

namespace ProjetoGR.Data
{
    public class DataContext : DbContext
    {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estagio> Estagios { get; set; }
        public DbSet<Faculdade> Faculdades { get; set; }

    }
}