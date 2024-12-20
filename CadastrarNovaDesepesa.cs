using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleDeGastos1.Ações
{
    public partial class CadastrarNovaDesepesa : Form
    {
        public CadastrarNovaDesepesa()
        {
            InitializeComponent();

            List<string> categorias = new List<string>();

            categorias = BancoDeDados.RetornaCategorias();

            foreach (string categoria in categorias)
            {
                comboBox1.Items.Add($"{categoria}");
            }

        }

            private void CadastrarNovaDesepesa_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000"; // Define a máscara para data (dia/mês/ano)
            maskedTextBox1.ValidatingType = typeof(DateTime); // Define que a validação será para tipo DateTime
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string descricao, dataAux, categoria;
            double valor;

            try
            {
                categoria = comboBox1.Text;
                descricao = textBox2.Text; 
                dataAux = maskedTextBox1.Text;

                if (!double.TryParse(textBox3.Text, out valor))
                {
                    MessageBox.Show("O valor informado é inválido. Digite um número válido.", "Erro");
                    return;
                }

                int ID = (BancoDeDados.RetornaIDCategoria(categoria));

                BancoDeDados.InserirDespesa(descricao, ID, valor, dataAux);

                MessageBox.Show("Despesa cadastrada com sucesso!", "Sucesso");

                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                maskedTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
