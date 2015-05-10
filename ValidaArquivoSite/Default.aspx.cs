using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClassLibraryValidaArquivoCEF;
using System.Text;

using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Security.Permissions;

namespace ValidaArquivoSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fileUp.Visible = false;
                bt_Validar.Visible = false;
                bt_Limpar.Visible = false;
                bt_exportaPdf.Visible = false;
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if (fileUp.HasFile == true)
            {
                try
                {
                    //informa o caminho do arquivo para ser validado no servidor

                    if (!Directory.Exists(Server.MapPath("\\arquivo\\")))
                    {
                        Directory.CreateDirectory(Server.MapPath("\\arquivo\\"));
                        FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.AllAccess, Server.MapPath("\\arquivo\\"));
                    }

                    String pasta = Server.MapPath("\\arquivo\\");

                    String caminho = pasta;
                    String caminhoLogValidaca = pasta;

                    //lista os arquivos antigos e apaga
                    String[] arquivos = System.IO.Directory.GetFiles(caminho);
                    foreach (var i in arquivos)
                    {
                        System.IO.File.Delete(i);
                    }

                    //copia o arquivo do cliente para o servidor
                    fileUp.SaveAs((caminho + fileUp.FileName));
                    caminho = caminho + fileUp.FileName;
                    File.SetAttributes(caminho, FileAttributes.Normal);

                    if (rb_Remessa.Checked)
                    {
                        //instancia o objeto que valida o arquivo
                        ValidaArquivoCAIXA validaArq = new ValidaArquivoCAIXA();
                        validaArq.lerRemessaCnab240(caminho, caminhoLogValidaca);
                    }

                    if (rb_Retorno.Checked)
                    {
                        ValidaArquivoCAIXA validaArq = new ValidaArquivoCAIXA();
                        validaArq.lerRetornoCnab240(caminho, caminhoLogValidaca);
                    }

                    else
                    {
                        Statuslbl.Text = "Favor selecionar o tipo do arquivo!";
                    }
                    //lê o arquivo de log da validação e exibe no navegador
                    StreamReader sr = new StreamReader(caminhoLogValidaca + "\\validacao.log", true);
                    while (sr.Peek() > -1)
                    {
                        lt_LogValidacao.Text += sr.ReadLine() + "<br>";
                    }
                    sr.Close();
                    bt_Limpar.Visible = true;
                    bt_exportaPdf.Visible = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                Statuslbl.Text = "Favor selecionar um arquivo!";
        }

        protected void rb_Retorno_CheckedChanged(object sender, EventArgs e)
        {
            bt_Validar.Visible = true;
            fileUp.Visible = true;
        }

        protected void rb_Remessa_CheckedChanged(object sender, EventArgs e)
        {
            bt_Validar.Visible = true;
            fileUp.Visible = true;
        }

        protected void bt_Limpar_Click(object sender, EventArgs e)
        {
            String caminho = "\\arquivo\\";
            caminho = Server.MapPath(caminho);
            lt_LogValidacao.Text = "";
            try
            {
                StreamReader sr = new StreamReader(caminho + "\\validacao.log");
                sr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void bt_exportaPdf_Click(object sender, EventArgs e)
        {
            ShowPdf(CreatePDF());
        }

        private byte[] CreatePDF()
        {
            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);
            String caminho = "\\arquivo\\";
            caminho = Server.MapPath(caminho);
            StreamReader sr = new StreamReader(caminho + "\\validacao.log", true);
            String validacao = sr.ReadToEnd(); 

            using (MemoryStream output = new MemoryStream())
            {                
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();

                // Inicio do Conteudo do PDF
                //String validacao = lt_LogValidacao.Text.ToString();
                //var plainText = ConvertToPlainText(string validacao);

                Paragraph header = new Paragraph("EL Project Sistemas - by Eder Lopes\n\nLog de validação de Arquivo CEF\n") { Alignment = Element.ALIGN_CENTER };
                //Paragraph paragraph = new Paragraph("paragrafo");
                Phrase phrase = new Phrase(validacao);
                //Chunk chunk = new Chunk("This is a chunk.");
                // Fim do Conteudo do PDF

                doc.Add(header);
                //doc.Add(paragraph);
                doc.Add(phrase);
                //doc.Add(chunk);

                doc.Close();

                return output.ToArray();
            }
        }

        private void ShowPdf(byte[] strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "Validacao_arquivo_CEF.pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
    }
}