namespace teste1
{
    partial class FormMenu
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_SAIR = new System.Windows.Forms.Button();
            this.BTN_NIVEIS = new System.Windows.Forms.Button();
            this.BTN_JOGAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "PALAVRA SECRETA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BTN_SAIR
            // 
            this.BTN_SAIR.Location = new System.Drawing.Point(209, 307);
            this.BTN_SAIR.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_SAIR.Name = "BTN_SAIR";
            this.BTN_SAIR.Size = new System.Drawing.Size(267, 49);
            this.BTN_SAIR.TabIndex = 3;
            this.BTN_SAIR.Text = "SAIR";
            this.BTN_SAIR.UseVisualStyleBackColor = true;
            this.BTN_SAIR.Click += new System.EventHandler(this.BTN_SAIR_Click);
            // 
            // BTN_NIVEIS
            // 
            this.BTN_NIVEIS.Location = new System.Drawing.Point(209, 245);
            this.BTN_NIVEIS.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_NIVEIS.Name = "BTN_NIVEIS";
            this.BTN_NIVEIS.Size = new System.Drawing.Size(267, 49);
            this.BTN_NIVEIS.TabIndex = 2;
            this.BTN_NIVEIS.Text = "SELECIONAR NÍVEL";
            this.BTN_NIVEIS.UseVisualStyleBackColor = true;
            this.BTN_NIVEIS.Click += new System.EventHandler(this.BTN_NIVEIS_Click_1);
            // 
            // BTN_JOGAR
            // 
            this.BTN_JOGAR.Location = new System.Drawing.Point(209, 183);
            this.BTN_JOGAR.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_JOGAR.Name = "BTN_JOGAR";
            this.BTN_JOGAR.Size = new System.Drawing.Size(267, 49);
            this.BTN_JOGAR.TabIndex = 1;
            this.BTN_JOGAR.Text = "INICIAR JOGO";
            this.BTN_JOGAR.UseVisualStyleBackColor = true;
            this.BTN_JOGAR.Click += new System.EventHandler(this.BTN_JOGAR_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.BTN_SAIR);
            this.Controls.Add(this.BTN_NIVEIS);
            this.Controls.Add(this.BTN_JOGAR);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_SAIR;
        private System.Windows.Forms.Button BTN_NIVEIS;
        private System.Windows.Forms.Button BTN_JOGAR;
    }
}
