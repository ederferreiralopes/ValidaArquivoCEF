namespace validaArquivoAPP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_procurar = new System.Windows.Forms.Button();
            this.bt_validar = new System.Windows.Forms.Button();
            this.bt_limpar = new System.Windows.Forms.Button();
            this.bt_sair = new System.Windows.Forms.Button();
            this.lb_mensagem = new System.Windows.Forms.Label();
            this.texto_validacao_box = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rb_remessa = new System.Windows.Forms.RadioButton();
            this.rb_retorno = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // bt_procurar
            // 
            this.bt_procurar.Location = new System.Drawing.Point(222, 21);
            this.bt_procurar.Name = "bt_procurar";
            this.bt_procurar.Size = new System.Drawing.Size(75, 45);
            this.bt_procurar.TabIndex = 0;
            this.bt_procurar.Text = "Procurar Arquivo";
            this.bt_procurar.UseVisualStyleBackColor = true;
            this.bt_procurar.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_validar
            // 
            this.bt_validar.Location = new System.Drawing.Point(312, 21);
            this.bt_validar.Name = "bt_validar";
            this.bt_validar.Size = new System.Drawing.Size(75, 45);
            this.bt_validar.TabIndex = 1;
            this.bt_validar.Text = "Validar";
            this.bt_validar.UseVisualStyleBackColor = true;
            // 
            // bt_limpar
            // 
            this.bt_limpar.Location = new System.Drawing.Point(400, 21);
            this.bt_limpar.Name = "bt_limpar";
            this.bt_limpar.Size = new System.Drawing.Size(75, 45);
            this.bt_limpar.TabIndex = 2;
            this.bt_limpar.Text = "Limpar";
            this.bt_limpar.UseVisualStyleBackColor = true;
            this.bt_limpar.Click += new System.EventHandler(this.bt_limpar_Click);
            // 
            // bt_sair
            // 
            this.bt_sair.Location = new System.Drawing.Point(494, 32);
            this.bt_sair.Name = "bt_sair";
            this.bt_sair.Size = new System.Drawing.Size(75, 23);
            this.bt_sair.TabIndex = 3;
            this.bt_sair.Text = "Sair";
            this.bt_sair.UseVisualStyleBackColor = true;
            // 
            // lb_mensagem
            // 
            this.lb_mensagem.AutoSize = true;
            this.lb_mensagem.Location = new System.Drawing.Point(25, 18);
            this.lb_mensagem.Name = "lb_mensagem";
            this.lb_mensagem.Size = new System.Drawing.Size(0, 13);
            this.lb_mensagem.TabIndex = 5;
            // 
            // texto_validacao_box
            // 
            this.texto_validacao_box.Location = new System.Drawing.Point(12, 82);
            this.texto_validacao_box.Name = "texto_validacao_box";
            this.texto_validacao_box.Size = new System.Drawing.Size(557, 328);
            this.texto_validacao_box.TabIndex = 6;
            this.texto_validacao_box.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // rb_remessa
            // 
            this.rb_remessa.AutoSize = true;
            this.rb_remessa.Location = new System.Drawing.Point(28, 44);
            this.rb_remessa.Name = "rb_remessa";
            this.rb_remessa.Size = new System.Drawing.Size(69, 17);
            this.rb_remessa.TabIndex = 7;
            this.rb_remessa.TabStop = true;
            this.rb_remessa.Text = "Remessa";
            this.rb_remessa.UseVisualStyleBackColor = true;
            // 
            // rb_retorno
            // 
            this.rb_retorno.AutoSize = true;
            this.rb_retorno.Location = new System.Drawing.Point(114, 44);
            this.rb_retorno.Name = "rb_retorno";
            this.rb_retorno.Size = new System.Drawing.Size(63, 17);
            this.rb_retorno.TabIndex = 8;
            this.rb_retorno.TabStop = true;
            this.rb_retorno.Text = "Retorno";
            this.rb_retorno.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 422);
            this.Controls.Add(this.rb_retorno);
            this.Controls.Add(this.rb_remessa);
            this.Controls.Add(this.texto_validacao_box);
            this.Controls.Add(this.lb_mensagem);
            this.Controls.Add(this.bt_sair);
            this.Controls.Add(this.bt_limpar);
            this.Controls.Add(this.bt_validar);
            this.Controls.Add(this.bt_procurar);
            this.Name = "Form1";
            this.Text = "Valida Arquivo CEF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_procurar;
        private System.Windows.Forms.Button bt_validar;
        private System.Windows.Forms.Button bt_limpar;
        private System.Windows.Forms.Button bt_sair;
        private System.Windows.Forms.Label lb_mensagem;
        private System.Windows.Forms.RichTextBox texto_validacao_box;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton rb_remessa;
        private System.Windows.Forms.RadioButton rb_retorno;
    }
}

