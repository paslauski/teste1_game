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
using System.Globalization;

namespace teste1
{
    public partial class FormJogo : Form
    {
        // palavra
        string palavraSecreta = ""; // guarda a palavra sorteada
        char[] palavraRevelada; // guarda as letras reveladas ou _
        string dica = ""; 
        int tempoMaximo = 0; // tempo total vindo do arquivo
        int tentativasMax = 0; // tentativas totais calculadas

        // estados do jogo
        int tempoRestante = 0; // tempo que vai diminuindo
        int tentativasRestantes = 0; 
        int acertosCount = 0; 
        int errosCount = 0;   
        int pontos = 0; 

        // controle de letras tentadas
        List<char> letrasUsadas = new List<char>(); // armazena letras já usadas
        Random rnd = new Random(); // gera num aleatórios para sortear palavras

        public static string nivel = "medio"; // nível inicial padrão

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // timer do jogo

        // max de erros permitidos
        const int MAX_ERROS = 6; // quantidade de imagens da forca pq só vai até 7

        public FormJogo()
        {
            InitializeComponent(); 
        }

        public FormJogo(string nivelEscolhido)
        {
            InitializeComponent(); 
            nivel = nivelEscolhido;
        }

        private void FormJogo_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // centraliza janela e tal cheia
            this.WindowState = FormWindowState.Maximized; 

            this.AcceptButton = btnVerificar; // enter aciona o botão verificar

            CarregarPalavra(); // carrega palavra e configura jogo

            timer.Interval = 1000; // timer de 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start(); // inicia

            this.Resize += (s, ev) => CentralizarControles(); // ao redimensionar, centraliza
            CentralizarControles(); // centraliza ao abrir
        }

        private void CentralizarControles()
        {
            try
            {
                if (this.Controls.ContainsKey("lblPalavra"))
                {
                    Label lbl = this.Controls["lblPalavra"] as Label;
                    lbl.Left = (this.ClientSize.Width - lbl.Width) / 2; // centraliza palavra
                }

                if (this.Controls.ContainsKey("pbForca"))
                {
                    PictureBox pb = this.Controls["pbForca"] as PictureBox;
                    pb.Left = (this.ClientSize.Width - pb.Width) / 2; // centraliza imagem
                }

                if (this.Controls.ContainsKey("txtLetra"))
                {
                    Control txt = this.Controls["txtLetra"];
                    txt.Left = (this.ClientSize.Width - txt.Width) / 2; // centraliza textbox
                }
            }
            catch
            {
                // evita que trave caso não tenha
            }
        }
        private void CarregarPalavra()
        {
            string caminho = "PALAVRAS.txt"; 

            if (!File.Exists(caminho)) // verifica se arquivo existe
            {
                MessageBox.Show("Arquivo PALAVRAS.txt não encontrado!");
                this.Close(); // fecha jogo
                return;
            }

            string[] linhas = File.ReadAllLines(caminho); // lê todas as linhas

            if (linhas.Length < 4) // as 4 linhas mínimas lá do escopo do mendelek
            {
                MessageBox.Show("PALAVRAS.txt inválido (menos de 4 linhas).");
                this.Close();
                return;
            }

            // cria lista com índices que representam blocos de 4 linhas
            List<int> indices = new List<int>();
            for (int i = 0; i <= linhas.Length - 4; i += 4)
                indices.Add(i);

            int idx = rnd.Next(indices.Count); // sorteia um bloco
            int inicio = indices[idx]; // pega início do bloco

            palavraSecreta = linhas[inicio].Trim().ToUpper(); 

            dica = linhas[inicio + 1].Trim(); // pega dica

            int tempoArquivo = 60; // valores padrão
            int tentativasArquivo = 10;

            if (!int.TryParse(linhas[inicio + 2].Trim(), out tempoArquivo))
                tempoArquivo = 60; // fallback caso parse falhe

            if (!int.TryParse(linhas[inicio + 3].Trim(), out tentativasArquivo))
                tentativasArquivo = 10;

            int letrasValidas = palavraSecreta.Count(c => !char.IsWhiteSpace(c)); // quantidade de letras

            int tentativasBase = Math.Max(letrasValidas + 3, tentativasArquivo); // calcula tentativas

            tempoMaximo = tempoArquivo; // define tempo vindo do arquivo
            tentativasMax = tentativasBase; // define tentativas totais

            if (nivel == "facil")
            {
                tempoMaximo += 20; // aumenta tempo
                tentativasMax += 3; // aumenta tentativas
            }
            else if (nivel == "dificil")
            {
                tempoMaximo = Math.Max(10, tempoMaximo - 20); // reduz tempo
                tentativasMax = Math.Max(3, tentativasMax - 2); // reduz tentativas
            }

            palavraRevelada = new char[palavraSecreta.Length]; // cria array da palavra revelada

            for (int i = 0; i < palavraSecreta.Length; i++)
                palavraRevelada[i] = char.IsWhiteSpace(palavraSecreta[i]) ? ' ' : '_'; // substitui por _

            acertosCount = 0; // zera contagem
            errosCount = 0;
            pontos = 0;
            letrasUsadas.Clear(); // limpa letras usadas

            tempoRestante = tempoMaximo; // inicia valores
            tentativasRestantes = tentativasMax;

            AtualizarTelaInicial(); // atualiza labels
            AtualizarBoneco(); // carrega imagem forca0
        }
        private void AtualizarTelaInicial()
        {
            if (this.Controls.ContainsKey("lblDica")) lblDica.Text = dica; // mostra dica

            AtualizarLabelPalavra(); // mostra palavra com _

            if (this.Controls.ContainsKey("lblTentativas")) lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;
            if (this.Controls.ContainsKey("lblTempo")) lblTempo.Text = "TEMPO: " + tempoRestante;
            if (this.Controls.ContainsKey("lblLetrasUsadas")) lblLetrasUsadas.Text = "LETRAS USADAS: ";
            if (this.Controls.ContainsKey("lblAcertos")) lblAcertos.Text = "ACERTOS: " + acertosCount;
            if (this.Controls.ContainsKey("lblErros")) lblErros.Text = "ERROS: " + errosCount;
            if (this.Controls.ContainsKey("lblPontos")) lblPontos.Text = "PONTOS: " + pontos;
        }

        private void AtualizarLabelPalavra()
        {
            StringBuilder sb = new StringBuilder(); // monta string com espaços

            for (int i = 0; i < palavraRevelada.Length; i++)
            {
                sb.Append(palavraRevelada[i]); // adc letra ou _
                if (i < palavraRevelada.Length - 1) sb.Append(' '); // separa com espaço
            }

            if (this.Controls.ContainsKey("lblPalavra")) lblPalavra.Text = sb.ToString(); // exibe palavra
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempoRestante--; // diminui tempo
            if (this.Controls.ContainsKey("lblTempo")) lblTempo.Text = "TEMPO: " + tempoRestante;

            if (tempoRestante <= 0) // tempo acabou
            {
                timer.Stop(); // para timer
                MostrarFim("TEMPO ESGOTADO! VOCÊ PERDEU!"); // mostra fim
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (!this.Controls.ContainsKey("txtLetra")) // garante que controle existe
            {
                MessageBox.Show("Controle txtLetra não encontrado.");
                return;
            }

            string entrada = txtLetra.Text.Trim(); // pega texto digitado

            if (string.IsNullOrEmpty(entrada)) // campo vazio
            {
                MessageBox.Show("Digite uma letra!");
                return;
            }

            char letra = entrada[0]; // pega a letra digitada

            letra = char.ToUpper(letra); // deixa maiúscula

            if (!char.IsLetter(letra)) // valida letra
            {
                MessageBox.Show("Digite apenas letras.");
                txtLetra.Text = "";
                txtLetra.Focus();
                return;
            }

            if (letrasUsadas.Contains(letra)) // já tentada
            {
                MessageBox.Show("Você já usou essa letra!");
                txtLetra.Text = "";
                txtLetra.Focus();
                return;
            }

            letrasUsadas.Add(letra); // registra letra
            tentativasRestantes--; // reduz tentativa

            if (this.Controls.ContainsKey("lblTentativas"))
                lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;

            AtualizarLetrasUsadas(); // mostra letras usadas

            int encontrados = 0; // conta quantas vezes a letra aparece

            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (char.ToUpper(palavraSecreta[i]) == letra && palavraRevelada[i] == '_')
                {
                    palavraRevelada[i] = letra; // revela letra
                    encontrados++;
                }
            }

            if (encontrados > 0) // acertou
            {
                acertosCount += encontrados;
                pontos += 10 * encontrados; // soma pontos
            }
            else // errou
            {
                errosCount++;
                pontos -= 5; // perde pontos
            }

            AtualizarBoneco(); 
            AtualizarLabelPalavra(); // mostra palavra atualizada
            AtualizarContadoresNaTela(); // atualiza contadores

            if (!palavraRevelada.Contains('_')) // vitória
            {
                timer.Stop();
                MostrarFim("PARABÉNS! VOCÊ GANHOU!");
                return;
            }

            if (errosCount >= MAX_ERROS || tentativasRestantes <= 0) // perdeu
            {
                timer.Stop();
                MostrarFim("QUE PENA! VOCÊ PERDEU!");
                return;
            }

            txtLetra.Text = ""; // limpa input
            txtLetra.Focus(); // volta foco
        }
        private void AtualizarLetrasUsadas()
        {
            if (this.Controls.ContainsKey("lblLetrasUsadas"))
                lblLetrasUsadas.Text = "LETRAS USADAS: " + string.Join(", ", letrasUsadas); // mostra letras usadas
        }

        private void AtualizarContadoresNaTela()
        {
            if (this.Controls.ContainsKey("lblAcertos")) lblAcertos.Text = "ACERTOS: " + acertosCount;
            if (this.Controls.ContainsKey("lblErros")) lblErros.Text = "ERROS: " + errosCount;
            if (this.Controls.ContainsKey("lblPontos")) lblPontos.Text = "PONTOS: " + pontos;
            if (this.Controls.ContainsKey("lblTentativas")) lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;
        }

        private void AtualizarBoneco()
        {
            int errosParaImagem = errosCount; // escolhe imagem do boneco
            if (errosParaImagem < 0) errosParaImagem = 0;
            if (errosParaImagem > MAX_ERROS) errosParaImagem = MAX_ERROS;

            string caminho = Path.Combine("imagens", $"forca{errosParaImagem}.png"); // monta caminho da imagem

            if (File.Exists(caminho))
            {
                try
                {
                    using (FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs); // carrega imagem
                        if (this.Controls.ContainsKey("pbForca"))
                        {
                            pbForca.Image = new Bitmap(img); // mostra imagem
                        }
                    }
                }
                catch
                {
                    // se der erro ao carregar imagem, ignora
                }
            }
            else
            {
                if (this.Controls.ContainsKey("pbForca"))
                    pbForca.Image = null; // limpa se nao existir imagem
            }
        }

        private void MostrarFim(string mensagem)
        {
            string palavraOriginal = palavraSecreta; // salva palavra original

            string resumo =
                $"{mensagem}\n\nPalavra: {palavraOriginal}\nAcertos: {acertosCount}\nErros: {errosCount}\nTentativas restantes: {tentativasRestantes}\nPontos: {pontos}";

            MessageBox.Show(resumo, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information); // mostra resultado

            try
            {
                FormMenu menu = new FormMenu(); // volta ao menu
                menu.Show();
            }
            catch
            {
                // se não conseguir abrir menu, só fecha jogo
            }

            this.Close(); // fecha janela atual
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
                try
                {
                    FormMenu menu = new FormMenu(); // abre menu
                    menu.Show();
                }
                catch { }

                this.Close(); // fecha jogo
            }
        }
    }
}
