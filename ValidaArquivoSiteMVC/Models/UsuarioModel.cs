using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValidaArquivoSiteMVC.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
    }
}