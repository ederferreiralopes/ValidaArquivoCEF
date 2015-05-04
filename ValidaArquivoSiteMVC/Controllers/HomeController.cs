using ClassLibraryValidaArquivoCEF;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ValidaArquivoSiteMVC.Models;

namespace ValidaArquivoSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/ 

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidaArquivoCEF(ArquivoModel model)
        {
            try
            {
                int quantArq = Request.Files.Count;
                for (int i = 0; i < quantArq; i++)
                {
                    model.Arquivo = Request.Files[i];
                    model.Nome = Request.Files[i].FileName;
                }

                ValidaArquivoCAIXA valida = new ValidaArquivoCAIXA();
                model.Validacao = ("Validando arquivo: " + model.Nome + "<br><br>");
                
                if (model.Tipo.Equals("REM"))
                {
                model.Validacao += valida.lerRemessaCnab240(model.Arquivo.InputStream);
                }
                if (model.Tipo.Equals("RET"))
                {
                    model.Validacao += valida.lerRemessaCnab240(model.Arquivo.InputStream);
                }
                model.id = 1;
                DBLogValidacao logBanco = new DBLogValidacao();

                Validacao val = new Validacao();
                val.validacao = model.Validacao;
                logBanco.LogValidacao.Add(val);
                logBanco.SaveChanges();

                TempData["TextoValidacao"] = model.Validacao;

                return View("Index", model);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public FileResult GeneratePDF()
        {
            try
            {
                Document document = new Document();

                MemoryStream stream = new MemoryStream();

                try
                {
                    var textoValidacao = TempData["TextoValidacao"].ToString();
                    var textoValidacaoSemTag = string.Empty;
                    var pos = 0;
                   
                    //retira <br> e insere /n (quebra de linha)
                    for (int i = 0; i < textoValidacao.Length; i++)
                    {
                        pos = textoValidacao.IndexOf("<br>", 0);
                        textoValidacaoSemTag += textoValidacao.Substring(0, pos);
                        textoValidacaoSemTag = textoValidacaoSemTag.Insert(textoValidacaoSemTag.Length, "\n");
                        textoValidacao = textoValidacao.Substring(pos + 4, textoValidacao.Length - (pos + 4));
                    }

                    PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
                    pdfWriter.CloseStream = false;

                    document.Open();

                    Paragraph header = new Paragraph("EL Project Sistemas - by Eder Lopes\n\nLog de validação de Arquivo CEF\n\n") { Alignment = Element.ALIGN_CENTER };
                    //Paragraph paragraph = new Paragraph("paragrafo");
                    Phrase phrase = new Phrase(textoValidacaoSemTag);
                    // Fim do Conteudo do PDF

                    document.Add(header);
                    //doc.Add(paragraph);
                    document.Add(phrase);
                }
                catch (DocumentException de)
                {
                    Console.Error.WriteLine(de.Message);
                }
                catch (IOException ioe)
                {
                    Console.Error.WriteLine(ioe.Message);
                }

                document.Close();

                stream.Flush(); //Always catches me out
                stream.Position = 0; //Not sure if this is required

                return File(stream, "application/pdf", "ValidacaoCEF.pdf");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
