namespace Synopsis.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Synopsis.Infrastructure.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(Synopsis.Infrastructure.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            
            // load any seed data
            ApplicationDbContextSeed.SeedSampleData(context);
        }
    }
}
