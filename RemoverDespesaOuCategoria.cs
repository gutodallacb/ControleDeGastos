using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleDeGastos1.Ações
{
    public partial class RemoverDespesaOuCategoria : Form
    {
        public RemoverDespesaOuCategoria()
        {
            InitializeComponent();

            comboBox1.Items.Add("Despesa");
            comboBox1.Items.Add("Categoria");

            comboBox1.Text = "Despesa";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string tipo;
            int ID;

            try
            {
                tipo = comboBox1.Text;
                ID = int.Parse(textBox2.Text);

                if (tipo == "Despesa")
                {
                    BancoDeDados.RemoverDespesaECategoria(ID, 1);
                    MessageBox.Show("Categoria removida com sucesso!");
                }
                else 
                {
                    BancoDeDados.RemoverDespesaECategoria(ID, 2);
                    MessageBox.Show("Categoria removida com sucesso!");
                }

                textBox2.Text = "";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void RemoverDespesaOuCategoria_Load(object sender, EventArgs e)
        {

        }

        private void RemoverDespesaOuCategoria_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
