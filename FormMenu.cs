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
            InitializeComponent(); // inicializa os componentes gráficos da tela do menu
        }


        private void BTN_JOGAR_Click(object sender, EventArgs e)
        {
            FormJogo jogo = new FormJogo(); // cria nova tela do jogo
            jogo.Show(); // abre o jogo
            this.Hide(); // esconde o menu (não fecha)
        }

        private void BTN_NIVEIS_Click_1(object sender, EventArgs e)
        {
            FormNiveis niveis = new FormNiveis(); // abre tela de seleção de níveis
            niveis.Show(); // mostra a tela
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
