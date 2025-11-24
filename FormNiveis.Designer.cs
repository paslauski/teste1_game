namespace teste1
{
    partial class FormNiveis
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFacil = new System.Windows.Forms.Button();
            this.btnMedio = new System.Windows.Forms.Button();
            this.btnDificil = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(212, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECIONE O NÍVEL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnFacil
            // 
            this.btnFacil.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFacil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnFacil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFacil.Location = new System.Drawing.Point(232, 186);
            this.btnFacil.Name = "btnFacil";
            this.btnFacil.Size = new System.Drawing.Size(274, 62);
            this.btnFacil.TabIndex = 5;
            this.btnFacil.Text = "FACIL";
            this.btnFacil.UseVisualStyleBackColor = false;
            this.btnFacil.Click += new System.EventHandler(this.btnFacil_Click);
            // 
            // btnMedio
            // 
            this.btnMedio.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnMedio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMedio.Location = new System.Drawing.Point(232, 249);
            this.btnMedio.Name = "btnMedio";
            this.btnMedio.Size = new System.Drawing.Size(274, 69);
            this.btnMedio.TabIndex = 4;
            this.btnMedio.Text = "MEDIO";
            this.btnMedio.UseVisualStyleBackColor = false;
            this.btnMedio.Click += new System.EventHandler(this.btnMedio_Click);
            // 
            // btnDificil
            // 
            this.btnDificil.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDificil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnDificil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDificil.Location = new System.Drawing.Point(232, 319);
            this.btnDificil.Name = "btnDificil";
            this.btnDificil.Size = new System.Drawing.Size(274, 62);
            this.btnDificil.TabIndex = 3;
            this.btnDificil.Text = "DIFICIL";
            this.btnDificil.UseVisualStyleBackColor = false;
            this.btnDificil.Click += new System.EventHandler(this.btnDificil_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(27, 405);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(85, 27);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // FormNiveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnFacil);
            this.Controls.Add(this.btnMedio);
            this.Controls.Add(this.btnDificil);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormNiveis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PALAVRA SECRETA - NIVEIS";
            this.Load += new System.EventHandler(this.FormNiveis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFacil;
        private System.Windows.Forms.Button btnMedio;
        private System.Windows.Forms.Button btnDificil;
        private System.Windows.Forms.Button btnVoltar;
    }
}