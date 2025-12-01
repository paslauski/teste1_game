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
    public partial class FormNiveis : Form
    {
        public FormNiveis()
        {
            InitializeComponent();
        }    

        private void btnFacil_Click(object sender, EventArgs e)
        {
            FormJogo.nivel = "facil";
            FormJogo jogo = new FormJogo();
            jogo.Show();
            this.Close(); // fecha tela de níveis
        }

        private void btnMedio_Click(object sender, EventArgs e)
        {
            FormJogo.nivel = "medio";
            FormJogo jogo = new FormJogo(); // abre jogo no nível escolhido
            jogo.Show();
            this.Close(); // fecha tela atual
        }

        private void btnDificil_Click(object sender, EventArgs e)
        {
            FormJogo.nivel = "dificil"; 
            FormJogo jogo = new FormJogo(); 
            jogo.Show();
            this.Close(); 
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(); // cria tela do menu
            menu.Show(); // abre o menu
            this.Close(); // fecha tela de níveis
        }
    }
}
