using Correct.Storage.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Correct.Storage.DataAccessLayer
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoxEntityConfiguration());
        }
    }
}