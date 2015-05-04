using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    public class DBLogValidacao:DbContext
    {
        public DbSet<Validacao> LogValidacao { get; set; }
    }
}