using System;
using System.Windows.Forms;

namespace ControleDeGastos1.Ações
{
    public partial class CadastrarNovaCategoria : Form
    {
        public CadastrarNovaCategoria()
        {
            InitializeComponent();

            comboBox1.Items.Add("1 - Baixa");
            comboBox1.Items.Add("2 - Média");
            comboBox1.Items.Add("3 - Alta");
        }

        private void button10_Click(object sender, EventArgs e) //Cadastrar
        {
            try
            {
                string nome = textBox2.Text;
                string prioridade = comboBox1.Text;
                int primeiroDigito = 1;

                if (!string.IsNullOrEmpty(prioridade) && char.IsDigit(prioridade[0]))
                {
                    // Obter o primeiro caractere e converter para inteiro
                    primeiroDigito = int.Parse(prioridade[0].ToString());
                }

                BancoDeDados.InserirCategoria(nome, primeiroDigito);

                MessageBox.Show($"Categoria cadastrada com sucesso!");

                textBox2.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro");
            }
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
