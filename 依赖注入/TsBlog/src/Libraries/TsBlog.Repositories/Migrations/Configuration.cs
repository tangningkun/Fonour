namespace TsBlog.Repositories.Migrations
{
    using MySql.Data.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TsBlog.Repositories.Migrations.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<TsBlog.Repositories.TsBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());//设置Sql生成器为Mysql的
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
