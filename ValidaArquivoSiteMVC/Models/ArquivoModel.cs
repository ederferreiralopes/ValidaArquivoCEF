using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    [Table("Arquivo")]
    public class ArquivoModel
    {
        public int id { get; set; }
        public DateTime Data { get; set; }
        public String Nome {get;set;}
        public String Tipo { get; set; }
        public String Validacao { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
    }
}