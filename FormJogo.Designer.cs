namespace teste1
{
    partial class FormJogo
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
            this.lblTituloDica = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblPalavra = new System.Windows.Forms.Label();
            this.lblDigite = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.lblLetrasUsadas = new System.Windows.Forms.Label();
            this.pbForca = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblDica = new System.Windows.Forms.Label();
            this.lblAcertos = new System.Windows.Forms.Label();
            this.lblErros = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbForca)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloDica
            // 
            this.lblTituloDica.AutoSize = true;
            this.lblTituloDica.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDica.Location = new System.Drawing.Point(148, 48);
            this.lblTituloDica.Name = "lblTituloDica";
            this.lblTituloDica.Size = new System.Drawing.Size(90, 39);
            this.lblTituloDica.TabIndex = 0;
            this.lblTituloDica.Text = "Dica:";
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(1333, 115);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(119, 39);
            this.lblTempo.TabIndex = 1;
            this.lblTempo.Text = "Tempo:";
            // 
            // lblPalavra
            // 
            this.lblPalavra.AutoSize = true;
            this.lblPalavra.Font = new System.Drawing.Font("Tempus Sans ITC", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalavra.Location = new System.Drawing.Point(44, 283);
            this.lblPalavra.Name = "lblPalavra";
            this.lblPalavra.Size = new System.Drawing.Size(48, 57);
            this.lblPalavra.TabIndex = 2;
            this.lblPalavra.Text = "_";
            // 
            // lblDigite
            // 
            this.lblDigite.AutoSize = true;
            this.lblDigite.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigite.Location = new System.Drawing.Point(646, 366);
            this.lblDigite.Name = "lblDigite";
            this.lblDigite.Size = new System.Drawing.Size(247, 39);
            this.lblDigite.TabIndex = 3;
            this.lblDigite.Text = "Digite uma letra:";
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(461, 377);
            this.txtLetra.MaxLength = 1;
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(205, 22);
            this.txtLetra.TabIndex = 4;
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTentativas.Location = new System.Drawing.Point(1333, 70);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(308, 39);
            this.lblTentativas.TabIndex = 6;
            this.lblTentativas.Text = "Tentativas restantes:";
            // 
            // lblLetrasUsadas
            // 
            this.lblLetrasUsadas.AutoSize = true;
            this.lblLetrasUsadas.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetrasUsadas.Location = new System.Drawing.Point(158, 169);
            this.lblLetrasUsadas.Name = "lblLetrasUsadas";
            this.lblLetrasUsadas.Size = new System.Drawing.Size(215, 39);
            this.lblLetrasUsadas.TabIndex = 7;
            this.lblLetrasUsadas.Text = "Letras usadas:";
            // 
            // pbForca
            // 
            this.pbForca.BackColor = System.Drawing.Color.Transparent;
            this.pbForca.Location = new System.Drawing.Point(412, 458);
            this.pbForca.Name = "pbForca";
            this.pbForca.Size = new System.Drawing.Size(661, 354);
            this.pbForca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbForca.TabIndex = 8;
            this.pbForca.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(1718, 833);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(208, 34);
            this.btnVoltar.TabIndex = 9;
            this.btnVoltar.Text = "VOLTAR AO MENU";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblDica
            // 
            this.lblDica.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDica.Location = new System.Drawing.Point(158, 93);
            this.lblDica.Name = "lblDica";
            this.lblDica.Size = new System.Drawing.Size(840, 76);
            this.lblDica.TabIndex = 10;
            this.lblDica.Text = "label da dica";
            // 
            // lblAcertos
            // 
            this.lblAcertos.AutoSize = true;
            this.lblAcertos.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcertos.Location = new System.Drawing.Point(1333, 164);
            this.lblAcertos.Name = "lblAcertos";
            this.lblAcertos.Size = new System.Drawing.Size(139, 39);
            this.lblAcertos.TabIndex = 11;
            this.lblAcertos.Text = "Acertos:";
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErros.Location = new System.Drawing.Point(1582, 164);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(101, 39);
            this.lblErros.TabIndex = 12;
            this.lblErros.Text = "Erros:";
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Kristen ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.Location = new System.Drawing.Point(1333, 236);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(122, 39);
            this.lblPontos.TabIndex = 13;
            this.lblPontos.Text = "Pontos:";
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(1149, 372);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(119, 32);
            this.btnVerificar.TabIndex = 14;
            this.btnVerificar.Text = "VERIFICAR";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += btnVerificar_Click;
            this.AcceptButton = btnVerificar;

            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 853);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.lblPontos);
            this.Controls.Add(this.lblErros);
            this.Controls.Add(this.lblAcertos);
            this.Controls.Add(this.lblDica);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.pbForca);
            this.Controls.Add(this.lblLetrasUsadas);
            this.Controls.Add(this.lblTentativas);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblDigite);
            this.Controls.Add(this.lblPalavra);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblTituloDica);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJogo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PALAVRA SECRETA - JOGO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormJogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbForca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloDica;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblPalavra;
        private System.Windows.Forms.Label lblDigite;
        private System.Windows.Forms.TextBox txtLetra;
        private System.Windows.Forms.Label lblTentativas;
        private System.Windows.Forms.Label lblLetrasUsadas;
        private System.Windows.Forms.PictureBox pbForca;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblDica;
        private System.Windows.Forms.Label lblAcertos;
        private System.Windows.Forms.Label lblErros;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Button btnVerificar;
    }
}