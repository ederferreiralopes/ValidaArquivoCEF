using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    public class ArquivoModel
    {
        public int id { get; set; }
        public String Nome {get;set;}
        public String Caminho { get; set; }
        public String Tipo { get; set; }
        public String Validacao { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
    }
}