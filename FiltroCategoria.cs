using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeGastos1.Ações
{
    public partial class FiltroCategoria : Form
    {
        public FiltroCategoria()
        {
            InitializeComponent();

            List<string> categorias = new List<string>();

            categorias = BancoDeDados.RetornaCategorias();

            foreach (string categoria in categorias)
            {
                comboBox1.Items.Add(categoria);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string categoria = comboBox1.Text;

            int ID = (BancoDeDados.RetornaIDCategoria(categoria));

            ControleDeGastos.ID_master = ID;

            this.Close();
        }

        private void Voltar_Click(object sender, EventArgs e)
        { 
            ControleDeGastos.ID_master = 9999999;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
