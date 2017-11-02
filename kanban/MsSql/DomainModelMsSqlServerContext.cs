using Microsoft.EntityFrameworkCore;
using System.Linq;
using Provider.Model;

namespace Mssql
{
    public class DomainModelMsSqlServerContext : DbContext
    {
        public DomainModelMsSqlServerContext(DbContextOptions<DomainModelMsSqlServerContext> options) : base(options)
        { }

        public DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tasks>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Tasks>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        }
    }
}
