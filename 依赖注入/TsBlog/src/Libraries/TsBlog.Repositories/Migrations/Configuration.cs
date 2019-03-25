namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TsBlog.Repositories.Migrations.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<TsBlog.Repositories.TsBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TsBlog.Repositories.TsBlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            new InitialHostDbBuilder(context).Create();
        }
    }
}
