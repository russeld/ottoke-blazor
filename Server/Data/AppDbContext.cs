using Microsoft.EntityFrameworkCore;
using OttokeBlazor.Server.Entities;

namespace OttokeBlazor.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
