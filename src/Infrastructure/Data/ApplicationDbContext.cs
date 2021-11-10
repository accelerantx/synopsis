using System.Data.Entity;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public const string SchemaName = "Synopsis";

        // TODO: when upgrading to EF Core change to ModelBuilder
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(SchemaName);
            
            // TODO: switch to commented line when upgrading to EF Core
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Configurations.AddFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserProfile> Users { get; set; }
    }
}
