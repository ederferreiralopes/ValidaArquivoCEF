namespace ValidaArquivoSiteMVC.Migrations
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationContextUsuario : DbMigrationsConfiguration<ValidaArquivoSiteMVC.Models.DBUsuario>
    {
        public ConfigurationContextUsuario()
        {
            CodeGenerator = new MySqlMigrationCodeGenerator();

            AutomaticMigrationsEnabled = true;

            // register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(ValidaArquivoSiteMVC.Models.DBUsuario context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
