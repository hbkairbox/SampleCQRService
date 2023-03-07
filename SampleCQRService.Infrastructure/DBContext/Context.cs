using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.Entities;
using SampleCQRService.Infrastructure.EntityConfigurations;
using SampleCQRService.Infrastructure.Repositories;

namespace SampleCQRService.Infrastructure.DBContext
{
    public class Context : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}