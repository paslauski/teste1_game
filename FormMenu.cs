using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste1
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void BTN_NIVEIS_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void BTN_JOGAR_Click(object sender, EventArgs e)
        {
            FormJogo jogo = new FormJogo();
            jogo.Show();
            this.Hide();
        }

        private void BTN_NIVEIS_Click_1(object sender, EventArgs e)
        {
            FormNiveis niveis = new FormNiveis();
            niveis.Show();
            this.Hide();
        }

        private void BTN_SAIR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
