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
        // palavra e meta
        string palavraSecreta = "";
        char[] palavraRevelada; // guarda os caracteres revelados / '_' / ' '
        string dica = "";
        int tempoMaximo = 0;
        int tentativasMax = 0;

        // estado da partida
        int tempoRestante = 0;
        int tentativasRestantes = 0;
        int acertosCount = 0; // total de letras acertadas
        int errosCount = 0;   // total de erros (para o boneco)
        int pontos = 0;

        // controles auxiliares
        List<char> letrasUsadas = new List<char>();
        Random rnd = new Random();

        public static string nivel = "medio";

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        // número máximo de erros que compõem as 7 imagens (0..6)
        const int MAX_ERROS = 6; // forca0.png ... forca6.png

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
            // Tela cheia e centralizar
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Enter aciona btnVerificar
            this.AcceptButton = btnVerificar;

            // Carregar primeira palavra e estado
            CarregarPalavra();

            // Timer de jogo
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Ajustar centralização simples ao redimensionar (se quiser melhorar, posso ajustar)
            this.Resize += (s, ev) => CentralizarControles();
            CentralizarControles();
        }

        private void CentralizarControles()
        {
            // centraliza lblPalavra e pbForca num posicionamento básico
            try
            {
                if (this.Controls.ContainsKey("lblPalavra"))
                {
                    Label lbl = this.Controls["lblPalavra"] as Label;
                    lbl.Left = (this.ClientSize.Width - lbl.Width) / 2;
                }

                if (this.Controls.ContainsKey("pbForca"))
                {
                    PictureBox pb = this.Controls["pbForca"] as PictureBox;
                    // posiciona a forca acima da palavra se couber
                    pb.Left = (this.ClientSize.Width - pb.Width) / 2;
                }

                if (this.Controls.ContainsKey("txtLetra"))
                {
                    Control txt = this.Controls["txtLetra"];
                    txt.Left = (this.ClientSize.Width - txt.Width) / 2;
                }
            }
            catch
            {
                // se algo não existir no designer, não quebra
            }
        }

        private void CarregarPalavra()
        {
            string caminho = "PALAVRAS.txt";
            if (!File.Exists(caminho))
            {
                MessageBox.Show("Arquivo PALAVRAS.txt não encontrado!");
                this.Close();
                return;
            }

            string[] linhas = File.ReadAllLines(caminho);
            if (linhas.Length < 4)
            {
                MessageBox.Show("PALAVRAS.txt inválido (menos de 4 linhas).");
                this.Close();
                return;
            }

            // monta lista de índices (cada entrada ocupa 4 linhas)
            List<int> indices = new List<int>();
            for (int i = 0; i <= linhas.Length - 4; i += 4) indices.Add(i);

            int idx = rnd.Next(indices.Count);
            int inicio = indices[idx];

            // normaliza palavra (remove acentos) e converte para maiúsculas
            palavraSecreta = RemoverAcentos(linhas[inicio].Trim()).ToUpper();
            dica = linhas[inicio + 1].Trim();

            // valores do arquivo (fallback se parse falhar)
            int tempoArquivo = 60;
            int tentativasArquivo = 10;
            if (!int.TryParse(linhas[inicio + 2].Trim(), out tempoArquivo)) tempoArquivo = 60;
            if (!int.TryParse(linhas[inicio + 3].Trim(), out tentativasArquivo)) tentativasArquivo = 10;

            // calcula tentativas baseadas no tamanho da palavra (somente letras, sem espaços)
            int letrasValidas = palavraSecreta.Count(c => !char.IsWhiteSpace(c));
            // regra: pelo menos (letras + 3) tentativas, mas respeita o valor mínimo do arquivo
            int tentativasBase = Math.Max(letrasValidas + 3, tentativasArquivo);

            // ajusta por nível
            tempoMaximo = tempoArquivo;
            tentativasMax = tentativasBase;

            if (nivel == "facil")
            {
                tempoMaximo += 20;
                tentativasMax += 3;
            }
            else if (nivel == "dificil")
            {
                tempoMaximo = Math.Max(10, tempoMaximo - 20);
                // reduz um pouco o total de tentativas, mas nunca abaixo de 3
                tentativasMax = Math.Max(3, tentativasMax - 2);
            }

            // nota: o limite de ERROS para o boneco permanece fixo em MAX_ERROS (ex: 6 -> 7 imagens)
            // inicializa estados
            palavraRevelada = new char[palavraSecreta.Length];
            for (int i = 0; i < palavraSecreta.Length; i++)
                palavraRevelada[i] = char.IsWhiteSpace(palavraSecreta[i]) ? ' ' : '_';

            acertosCount = 0;
            errosCount = 0;
            pontos = 0;
            letrasUsadas.Clear();

            tempoRestante = tempoMaximo;
            tentativasRestantes = tentativasMax;

            AtualizarTelaInicial();
            AtualizarBoneco(); // exibe forca0.png inicialmente
        }

        private void AtualizarTelaInicial()
        {
            // dica / palavra / contadores
            if (this.Controls.ContainsKey("lblDica")) lblDica.Text = dica;
            AtualizarLabelPalavra();
            if (this.Controls.ContainsKey("lblTentativas")) lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;
            if (this.Controls.ContainsKey("lblTempo")) lblTempo.Text = "TEMPO: " + tempoRestante;
            if (this.Controls.ContainsKey("lblLetrasUsadas")) lblLetrasUsadas.Text = "LETRAS USADAS: ";
            if (this.Controls.ContainsKey("lblAcertos")) lblAcertos.Text = "ACERTOS: " + acertosCount;
            if (this.Controls.ContainsKey("lblErros")) lblErros.Text = "ERROS: " + errosCount;
            if (this.Controls.ContainsKey("lblPontos")) lblPontos.Text = "PONTOS: " + pontos;
        }

        private void AtualizarLabelPalavra()
        {
            // monta string com espaços entre os caracteres: "_ _ A _"
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < palavraRevelada.Length; i++)
            {
                sb.Append(palavraRevelada[i]);
                if (i < palavraRevelada.Length - 1) sb.Append(' ');
            }
            if (this.Controls.ContainsKey("lblPalavra")) lblPalavra.Text = sb.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempoRestante--;
            if (this.Controls.ContainsKey("lblTempo")) lblTempo.Text = "TEMPO: " + tempoRestante;

            if (tempoRestante <= 0)
            {
                timer.Stop();
                MostrarFim("TEMPO ESGOTADO! VOCÊ PERDEU!");
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            // validação básica
            if (!this.Controls.ContainsKey("txtLetra"))
            {
                MessageBox.Show("Controle txtLetra não encontrado.");
                return;
            }

            string entrada = txtLetra.Text.Trim();
            if (string.IsNullOrEmpty(entrada))
            {
                MessageBox.Show("Digite uma letra!");
                return;
            }

            char letra = RemoverAcentos(entrada)[0];
            letra = char.ToUpper(letra);

            if (!char.IsLetter(letra))
            {
                MessageBox.Show("Digite apenas letras.");
                txtLetra.Text = "";
                txtLetra.Focus();
                return;
            }

            if (letrasUsadas.Contains(letra))
            {
                MessageBox.Show("Você já usou essa letra!");
                txtLetra.Text = "";
                txtLetra.Focus();
                return;
            }

            // registra a tentativa: cada palpite reduz o total de tentativas (regra 7.3)
            letrasUsadas.Add(letra);
            tentativasRestantes--;
            if (this.Controls.ContainsKey("lblTentativas")) lblTentativas.Text = "TENTATIVAS: " + tentativasRestantes;
            AtualizarLetrasUsadas();

            // verifica se tem ocorrências
            int encontrados = 0;
            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (char.ToUpper(palavraSecreta[i]) == letra && palavraRevelada[i] == '_')
                {
                    palavraRevelada[i] = letra;
                    encontrados++;
                }
            }

            if (encontrados > 0)
            {
                acertosCount += encontrados;
                pontos += 10 * encontrados; // ganha pontos por letra correta
            }
            else
            {
                errosCount++;
                pontos -= 5; // penalidade por erro
            }

            // atualiza boneco, labels e verifica fim
            AtualizarBoneco();
            AtualizarLabelPalavra();
            AtualizarContadoresNaTela();

            // checa vitória (não existe '_' em palavraRevelada)
            if (!palavraRevelada.Contains('_'))
            {
                timer.Stop();
                MostrarFim("PARABÉNS! VOCÊ GANHOU!");
                return;
            }

            // checa derrota: por erros máximos ou tentativas esgotadas
            if (errosCount >= MAX_ERROS || tentativasRestantes <= 0)
            {
                timer.Stop();
                MostrarFim("QUE PENA! VOCÊ PERDEU!");
                return;
            }

            // prepara próximo input
            txtLetra.Text = "";
            txtLetra.Focus();
        }

        private void AtualizarLetrasUsadas()
        {
            if (this.Controls.ContainsKey("lblLetrasUsadas"))
                lblLetrasUsadas.Text = "LETRAS USADAS: " + string.Join(", ", letrasUsadas);
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
            int errosParaImagem = errosCount;
            if (errosParaImagem < 0) errosParaImagem = 0;
            if (errosParaImagem > MAX_ERROS) errosParaImagem = MAX_ERROS;

            string caminho = Path.Combine("imagens", $"forca{errosParaImagem}.png");
            if (File.Exists(caminho))
            {
                try
                {
                    // libera imagem anterior (para evitar lock) - recria a partir de stream
                    using (FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                        if (this.Controls.ContainsKey("pbForca"))
                        {
                            pbForca.Image = new Bitmap(img);
                        }
                    }
                }
                catch
                {
                    // se falhar ao carregar, ignora
                }
            }
            else
            {
                // se não existir imagem, limpa pb
                if (this.Controls.ContainsKey("pbForca")) pbForca.Image = null;
            }
        }

        private void MostrarFim(string mensagem)
        {
            // resumo final (7.2)
            string palavraOriginal = palavraSecreta; // palavra já sem acentos
            string resumo = $"{mensagem}\n\nPalavra: {palavraOriginal}\nAcertos: {acertosCount}\nErros: {errosCount}\nTentativas restantes: {tentativasRestantes}\nPontos: {pontos}";

            MessageBox.Show(resumo, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // volta ao menu
            try
            {
                FormMenu menu = new FormMenu();
                menu.Show();
            }
            catch
            {
                // se FormMenu não existir ou tiver outro construtor, apenas fecha
            }
            this.Close();
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
                    FormMenu menu = new FormMenu();
                    menu.Show();
                }
                catch { }
                this.Close();
            }
        }

        private void lblDica_Click(object sender, EventArgs e)
        {
            // vazio - se quiser mostrar ajuda ao clicar, implementa aqui
        }

        // Função para remover acentos e normalizar strings
        private string RemoverAcentos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return texto;
            string normalized = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void btnVerificar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
