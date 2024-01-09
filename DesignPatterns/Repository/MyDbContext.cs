using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}