using EntityFirstCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFirstCrud.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
