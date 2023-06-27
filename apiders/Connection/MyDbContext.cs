using apiders.Models;
using Microsoft.EntityFrameworkCore;

namespace apiders.Connection
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Commad> Commads { get; set; }
    }
}
