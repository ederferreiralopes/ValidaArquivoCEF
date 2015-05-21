using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    public class DBUsuario : DbContext
    {
        public DBUsuario():base("connMysql")
        {
        }

        public DbSet<UsuarioModel> Usuario { get; set; }

        static DBUsuario()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}