using interview.Models;
using Microsoft.EntityFrameworkCore;

namespace interview.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Example> Examples { get; set; }
    }
}
