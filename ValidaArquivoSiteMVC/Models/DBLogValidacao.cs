using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    public class DBLogValidacao:DbContext
    {
        public DBLogValidacao():base("connMysql")
        {

        }

        public DbSet<ArquivoModel> Validacao { get; set; }

        static DBLogValidacao()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ArquivoModel>().Ignore(t => t.Arquivo);
            base.OnModelCreating(modelBuilder);
        }
    }
}