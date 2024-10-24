
using TodoApp.Domain.Common;
using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Persistence
{
    public class DataBaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            // Filter Deleted Items

            modelBuilder.Entity<Todo>()
                .HasQueryFilter(t => t.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }


        // DataBase Tables
        public DbSet<Todo> Todo { get; set; }


        // Change Tracking 
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreateDate = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdateDate = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
