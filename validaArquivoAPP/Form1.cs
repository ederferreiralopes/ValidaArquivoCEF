using ClassLibraryValidaArquivoCEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace validaArquivoAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog.InitialDirectory = "C:";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    //informa o caminho do arquivo para ser validado no servidor
                    string caminho = openFileDialog.FileName;
                    string caminhoLogValidaca = "";

                    if (rb_remessa.Checked)
                    {
                        //instancia o objeto que valida o arquivo
                        ValidaArquivoCAIXA validaArq = new ValidaArquivoCAIXA();
                        validaArq.lerRemessaCnab240(caminho, caminhoLogValidaca);
                    }

                    if (rb_retorno.Checked)
                    {
                        ValidaArquivoCAIXA validaArq = new ValidaArquivoCAIXA();
                        validaArq.lerRetornoCnab240(caminho, caminhoLogValidaca);
                    }

                    else
                    {
                        lb_mensagem.Text = "Favor selecionar o tipo do arquivo!";
                    }
                    //lê o arquivo de log da validação e exibe no navegador
                    StreamReader sr = new StreamReader("C:\\validacao.log", true);
                    while (sr.Peek() > -1)
                    {
                        texto_validacao_box.Text += sr.ReadLine();
                    }
                    sr.Close();
                    bt_limpar.Visible = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                lb_mensagem.Text = "Favor selecionar um arquivo!";
        }

        private void bt_limpar_Click(object sender, EventArgs e)
        {
            string caminho = "\\arquivo\\";
            //caminho = Server.MapPath(caminho);
            texto_validacao_box.Text = "";
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
    }
}
