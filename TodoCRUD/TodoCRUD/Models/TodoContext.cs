using Microsoft.EntityFrameworkCore;

namespace TodoCRUD.Models
{
    public class TodoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TodoCRUD;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TodoModel> Todos { get; set; }
    }
}
