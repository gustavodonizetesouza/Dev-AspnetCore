using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<EmprestimosModel> Emprestimos { get; set; }
        public DbSet<AutorModel> autor { get; set; }
        public DbSet<EditoraModel> editora { get; set; }
        public DbSet<GeneroModel> genero { get; set; }
        public DbSet<BibliotecaModel> biblioteca { get; set; }
    }
}
