using Microsoft.EntityFrameworkCore;

namespace apbd_test_retake.Models
{
    public class SomeDbContext : DbContext
    {
        public SomeDbContext() { }
        public SomeDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
