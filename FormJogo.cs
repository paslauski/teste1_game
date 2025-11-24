using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace teste1
{
    public partial class FormJogo : Form
    {

        string palavraSecreta = "";
        string dica = "";
        int tempoMaximo = 0;
        int tentativasMax = 0;

        int tempoRestante = 0;
        int tentativasRestantes = 0;

        List<char> letrasUsadas = new List<char>();
        Random rnd = new Random();

        public static string nivel = "medio";

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        
        public FormJogo()
        {
            InitializeComponent();
        }

        public FormJogo(string nivelEscolhido)
        {
            InitializeComponent();
            nivel = nivelEscolhido;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CarregarPalavra()
        {
            string[] linhas = File.ReadAllLines("PALAVRAS.txt");

            List<int> indices = new List<int>();
            for (int i = 0; i < linhas.Length - 3; i += 4)
                indices.Add(i);

            int idx = rnd.Next(indices.Count);
            int inicio = indices[idx];

            palavraSecreta = linhas[inicio].Trim();
            dica = linhas[inicio + 1].Trim();
            tempoMaximo = int.Parse(linhas[inicio + 2].Trim());
            tentativasMax = int.Parse(linhas[inicio + 3].Trim());


            // Ajustes conforme o nível
            if (nivel == "facil")
            {
                tempoMaximo += 20;
                tentativasMax += 3;
            }
            else if (nivel == "medio")
            {
                // mantém o padrão
            }
            else if (nivel == "dificil")
            {
                tempoMaximo -= 20;
                tentativasMax -= 3;

                if (tempoMaximo < 10) tempoMaximo = 10;
                if (tentativasMax < 3) tentativasMax = 3;
            }


            tempoRestante = tempoMaximo;
            tentativasRestantes = tentativasMax;

            AtualizarTelaInicial();

            // 👉 ADICIONE ESTA LINHA ⬇⬇⬇
            AtualizarBoneco();  // mostra forca0.png ao iniciar o jogo
        }


        private void AtualizarTelaInicial()
        {
            // dica
            lblDica.Text = dica;

            // palavra escondida com "_"
            lblPalavra.Text = "";
            foreach (char c in palavraSecreta)
                lblPalavra.Text += "_ ";

            // tentativas
            lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;

            // tempo
            lblTempo.Text = "TEMPO: " + tempoRestante;

            // letras já usadas
            lblLetrasUsadas.Text = "LETRAS USADAS: ";
        }


        private void FormJogo_Load(object sender, EventArgs e)
        {
            CarregarPalavra();
            // Configurar timer
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempoRestante--;

            lblTempo.Text = "TEMPO: " + tempoRestante;

            if (tempoRestante <= 0)
            {
                timer.Stop();
                MessageBox.Show("O TEMPO ACABOU! VOCÊ PERDEU!\nA palavra era: " + palavraSecreta);
                this.Close();
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtLetra.Text.Trim() == "")
            {
                MessageBox.Show("Digite uma letra!");
                return;
            }

            char letra = char.ToUpper(txtLetra.Text[0]);

            // evita caracteres inválidos
            if (!char.IsLetter(letra))
            {
                MessageBox.Show("Digite apenas letras.");
                return;
            }

            // evita repetição
            if (letrasUsadas.Contains(letra))
            {
                MessageBox.Show("Você já usou essa letra!");
                return;
            }


            letrasUsadas.Add(letra);
            AtualizarLetrasUsadas();

            bool acertou = false;

            // monta a nova palavra revelada
            StringBuilder novaPalavra = new StringBuilder();

            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (char.ToUpper(palavraSecreta[i]) == letra)
                {
                    novaPalavra.Append(letra + " ");
                    acertou = true;
                }
                else
                {
                    novaPalavra.Append(lblPalavra.Text.Split(' ')[i] + " ");
                }
            }

            lblPalavra.Text = novaPalavra.ToString();

            if (!acertou)
            {
                tentativasRestantes--;
                lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;
            }
            AtualizarBoneco();

            // checar vitória
            if (!lblPalavra.Text.Contains("_"))
            {
                timer.Stop();
                MessageBox.Show("PARABÉNS! VOCÊ GANHOU!");
                this.Close();
            }

            // checar derrota
            if (tentativasRestantes <= 0)
            {
                timer.Stop();
                MessageBox.Show("QUE PENA! VOCÊ PERDEU!\nA palavra era: " + palavraSecreta);
                this.Close();
            }


            txtLetra.Text = "";
        }

        private void AtualizarLetrasUsadas()
        {
            lblLetrasUsadas.Text = "LETRAS USADAS: " + string.Join(", ", letrasUsadas);
        }

        private void AtualizarBoneco()
        {
            int erros = tentativasMax - tentativasRestantes;

            if (erros < 0) erros = 0;
            if (erros > 6) erros = 6;

            pbForca.Image = Image.FromFile($"imagens/forca{erros}.png");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
        "Tem certeza que deseja voltar ao menu?\nSeu progresso será perdido.",
        "Confirmar saída",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            if (resposta == DialogResult.Yes)
            {
                FormMenu menu = new FormMenu();
                menu.Show();
                this.Close();
            }
        }
    }
}
