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
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.lblLetrasUsadas = new System.Windows.Forms.Label();
            this.pbForca = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblDica = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbForca)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloDica
            // 
            this.lblTituloDica.AutoSize = true;
            this.lblTituloDica.Location = new System.Drawing.Point(25, 34);
            this.lblTituloDica.Name = "lblTituloDica";
            this.lblTituloDica.Size = new System.Drawing.Size(41, 16);
            this.lblTituloDica.TabIndex = 0;
            this.lblTituloDica.Text = "DICA:";
            this.lblTituloDica.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(492, 66);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(58, 16);
            this.lblTempo.TabIndex = 1;
            this.lblTempo.Text = "TEMPO:";
            this.lblTempo.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblPalavra
            // 
            this.lblPalavra.AutoSize = true;
            this.lblPalavra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPalavra.Location = new System.Drawing.Point(52, 120);
            this.lblPalavra.Name = "lblPalavra";
            this.lblPalavra.Size = new System.Drawing.Size(16, 17);
            this.lblPalavra.TabIndex = 2;
            this.lblPalavra.Text = "_";
            // 
            // lblDigite
            // 
            this.lblDigite.AutoSize = true;
            this.lblDigite.Location = new System.Drawing.Point(25, 151);
            this.lblDigite.Name = "lblDigite";
            this.lblDigite.Size = new System.Drawing.Size(134, 16);
            this.lblDigite.TabIndex = 3;
            this.lblDigite.Text = "DIGITE UMA LETRA:";
            // 
            // txtLetra
            // 
            this.txtLetra.Location = new System.Drawing.Point(171, 148);
            this.txtLetra.MaxLength = 1;
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(100, 22);
            this.txtLetra.TabIndex = 4;
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(289, 151);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(102, 23);
            this.btnVerificar.TabIndex = 5;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Location = new System.Drawing.Point(492, 34);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(181, 16);
            this.lblTentativas.TabIndex = 6;
            this.lblTentativas.Text = "TENTATIVAS RESTANTES:";
            // 
            // lblLetrasUsadas
            // 
            this.lblLetrasUsadas.AutoSize = true;
            this.lblLetrasUsadas.Location = new System.Drawing.Point(492, 95);
            this.lblLetrasUsadas.Name = "lblLetrasUsadas";
            this.lblLetrasUsadas.Size = new System.Drawing.Size(122, 16);
            this.lblLetrasUsadas.TabIndex = 7;
            this.lblLetrasUsadas.Text = "LETRAS USADAS:";
            // 
            // pbForca
            // 
            this.pbForca.BackColor = System.Drawing.Color.Transparent;
            this.pbForca.Location = new System.Drawing.Point(28, 196);
            this.pbForca.Name = "pbForca";
            this.pbForca.Size = new System.Drawing.Size(534, 213);
            this.pbForca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbForca.TabIndex = 8;
            this.pbForca.TabStop = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(13, 415);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(157, 23);
            this.btnVoltar.TabIndex = 9;
            this.btnVoltar.Text = "VOLTAR AO MENU";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblDica
            // 
            this.lblDica.Location = new System.Drawing.Point(28, 65);
            this.lblDica.Name = "lblDica";
            this.lblDica.Size = new System.Drawing.Size(420, 46);
            this.lblDica.TabIndex = 10;
            this.lblDica.Text = "label1";
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.lblDica);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.pbForca);
            this.Controls.Add(this.lblLetrasUsadas);
            this.Controls.Add(this.lblTentativas);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.txtLetra);
            this.Controls.Add(this.lblDigite);
            this.Controls.Add(this.lblPalavra);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblTituloDica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PALAVRA SECRETA - JOGO";
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
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label lblTentativas;
        private System.Windows.Forms.Label lblLetrasUsadas;
        private System.Windows.Forms.PictureBox pbForca;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblDica;
    }
}