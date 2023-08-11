using Microsoft.EntityFrameworkCore;

namespace Staj.Models
{
    public class DoorContext : DbContext
    {
      
        public DbSet<door> door { get; set; }

        public DoorContext(DbContextOptions<DoorContext> options) : base(options)
        {
        }
    }
}
