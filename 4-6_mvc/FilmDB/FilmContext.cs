using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB
{
    public class FilmContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=FilmDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<FilmModel> Films { get; set; } = null!;
    }
}
