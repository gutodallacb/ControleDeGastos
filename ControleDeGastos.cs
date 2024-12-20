using ControleDeGastos1.Ações;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace ControleDeGastos1
{
    public partial class ControleDeGastos : Form
    {
        public static int ID_master;

        public ControleDeGastos()
        {
            InitializeComponent();
            DefiniarPropriedadesGrid();
            ConfigurarDataGridView(1);
            AdicionarImagem();
        }

        private void AdicionarImagem()
        {
            PictureBox pictureBox = new PictureBox
            {
                Width = 175,
                Height = 200,
                SizeMode = PictureBoxSizeMode.Zoom // Ajusta o tamanho da imagem ao PictureBox
            };

            // Carrega a imagem de um arquivo
            pictureBox1.Image = Image.FromFile("C:\\Users\\gutod\\OneDrive\\Área de Trabalho\\User.jpg");

            // Adiciona o PictureBox ao formulário
            this.Controls.Add(pictureBox);
        }

        private void ConfigurarDataGridView(int tipo)
        {
            // Limpa colunas e linhas existentes
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (tipo == 1)
            {
                // Define as colunas
                dataGridView1.Columns.Add("colID", "ID");
                dataGridView1.Columns.Add("colDescricao", "Descrição");
                dataGridView1.Columns.Add("colCategoria", "Categoria");
                dataGridView1.Columns.Add("colValor", "Valor");
                dataGridView1.Columns.Add("colData", "Data");

                // Ajusta o tamanho da coluna "ID"
                dataGridView1.Columns["colID"].Width = 50;
                dataGridView1.Columns["colValor"].Width = 150;
                dataGridView1.Columns["colData"].Width = 120;
                dataGridView1.Columns["colCategoria"].Width = 170;

                // Define alinhamento para valores numéricos
                dataGridView1.Columns["colValor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (tipo == 2)
            {
                // Define as colunas
                dataGridView1.Columns.Add("colID", "ID");
                dataGridView1.Columns.Add("colCategoria", "Categoria");
                dataGridView1.Columns.Add("colPrioridade", "Prioridade");

                // Ajusta o tamanho da coluna "ID"
                dataGridView1.Columns["colID"].Width = 30;
                dataGridView1.Columns["colCategoria"].Width = 170;
                dataGridView1.Columns["colPrioridade"].Width = 100;
            }
            else if (tipo == 3)
            {
                dataGridView1.Columns.Add("colID", "ID");
                dataGridView1.Columns.Add("colDescricao", "Descrição");
                dataGridView1.Columns.Add("colValor", "Valor");
                dataGridView1.Columns.Add("colData", "Data");

                dataGridView1.Columns["colID"].Width = 50;
                dataGridView1.Columns["colValor"].Width = 150;
                dataGridView1.Columns["colData"].Width = 120;

                // Define alinhamento para valores numéricos
                dataGridView1.Columns["colValor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (tipo == 4)
            {
                dataGridView1.Columns.Add("colDescricao", "Descrição");
                dataGridView1.Columns.Add("colValor", "Valor");
                dataGridView1.Columns.Add("colPrioridade", "Prioridade");
                dataGridView1.Columns.Add("colData", "Data");

                dataGridView1.Columns["colValor"].Width = 160;
                dataGridView1.Columns["colData"].Width = 130;
                dataGridView1.Columns["colPrioridade"].Width = 150;
                dataGridView1.Columns["colDescricao"].Width = 500;

                // Define alinhamento para valores numéricos
                dataGridView1.Columns["colValor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Adiciona eventos de formatação
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellParsing += DataGridView1_CellParsing;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatação da coluna "Valor" como moeda
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colValor" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.Value = valor.ToString("C2", CultureInfo.CurrentCulture);
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            // Parsing de entrada na coluna "Valor"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colValor" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal valor))
                {
                    e.Value = valor;
                    e.ParsingApplied = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarNovaDesepesa prompt = new CadastrarNovaDesepesa();

            prompt.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastrarNovaCategoria prompt = new CadastrarNovaCategoria();

            prompt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridView(1);
            ListarDespesas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridView(2);
            ListarCategorias();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridView(3);
            ListarDespesasPorFiltroCategoria();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridView(4);
            ListarDespesasPorPrioridade();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e) //Cadastrar
        {
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RemoverDespesaOuCategoria prompt = new RemoverDespesaOuCategoria();

            prompt.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void DefiniarPropriedadesGrid()
        {
            //dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray; // Cor de fundo padrão
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Cor para linhas alternadas
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10); // Fonte das células
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Ajusta o cabeçalho
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Colunas ocupam o espaço disponível
            dataGridView1.AllowUserToAddRows = false; // Impede que o usuário adicione linhas diretamente
            dataGridView1.ReadOnly = true; // Permite edição nas células
            dataGridView1.BackgroundColor = Color.White;
        }

        public void ListarDespesas()
        {
            string ConnectionString = "Data Source=gastos.db;Version=3;";

            using (var conexao = new SQLiteConnection(ConnectionString))
            {
                conexao.Open();

                string comandoSQL = "SELECT ID, Descricao, (Select Nome from Categorias where CAtegorias.ID = Despesas.Categoria) as Categoria, Valor, Data FROM Despesas order by Data Desc";
                string comandoSQL2 = "SELECT sum(Valor) FROM Despesas";

                using (var comando = new SQLiteCommand(comandoSQL, conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    {

                        while (leitor.Read())
                        {
                            dataGridView1.Rows.Add(
                                leitor["ID"].ToString(),
                                leitor["Descricao"].ToString(),
                                leitor["Categoria"].ToString(),
                                Convert.ToDecimal(leitor["Valor"]).ToString("C2"), // Formata como moeda
                                DateTime.Parse(leitor["Data"].ToString()).ToString("dd/MM/yyyy") // Formata a data
                                // ou -> Convert.ToDateTime(leitor["Data"]).ToString("dd/MM/yyyy")
                            );
                        }
                    }
                }

                using (var comando = new SQLiteCommand(comandoSQL2, conexao))
                {
                    object resultado = comando.ExecuteScalar();
                    decimal soma = (resultado != DBNull.Value) ? Convert.ToDecimal(resultado) : 0;
                
                    MessageBox.Show($"Valor Total: {soma}");
                }
            }
        }

        void ListarCategorias()
        {
            string ConnectionString = "Data Source=gastos.db;Version=3;";

            using (var conexao = new SQLiteConnection(ConnectionString))
            {
                conexao.Open();

                string comandoSQL = "SELECT * FROM Categorias order by ID";

                using (var comando = new SQLiteCommand(comandoSQL, conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    { 
                        while (leitor.Read())
                        {
                            string prioridade = leitor["Prioridade"].ToString();

                            if (prioridade == "1")
                            {
                                prioridade = "Baixa";
                            }
                            else if (prioridade == "2")
                            {
                                prioridade = "Média";
                            }
                            else if (prioridade == "3")
                            {
                                prioridade = "Alta";
                            }

                                dataGridView1.Rows.Add(
                                leitor["ID"].ToString(),
                                leitor["Nome"].ToString(),
                                prioridade
                            );
                        }
                    }
                }
            }
        }

        void ListarDespesasPorFiltroCategoria()
        {
            FiltroCategoria prompt = new FiltroCategoria();

            prompt.ShowDialog();

            int ID = ID_master;

            if (ID != 9999999)
            {

                string ConnectionString = "Data Source=gastos.db;Version=3;";

                using (var conexao = new SQLiteConnection(ConnectionString))
                {
                    conexao.Open();

                    string comandoSQL = $"SELECT ID, Descricao, Valor, Data FROM Despesas WHERE Despesas.Categoria = '{ID}' order by Data desc";
                    string comandoSQL3 = $"SELECT sum(Valor) FROM Despesas WHERE Despesas.Categoria = '{ID}'";

                    int count = 0;

                    using (var comando = new SQLiteCommand(comandoSQL, conexao))
                    {
                        using (var leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                dataGridView1.Rows.Add(
                                    leitor["ID"].ToString(),
                                    leitor["Descricao"].ToString(),
                                    leitor["Valor"].ToString(),
                                    Convert.ToDateTime(leitor["Data"]).ToString("dd/MM/yyyy")
                                );

                                count++;
                            }
                        }

                        if (count == 0)
                        {
                            MessageBox.Show("Não foi encontrado nenhuma despesa com essa categoria!");
                        }
                    }

                    using (var comando = new SQLiteCommand(comandoSQL3, conexao))
                    {
                        object resultado = comando.ExecuteScalar();
                        decimal soma = (resultado != DBNull.Value) ? Convert.ToDecimal(resultado) : 0;
                    }
                }
            }
        }

        void ListarDespesasPorPrioridade()
        {
            string ConnectionString = "Data Source=gastos.db;Version=3;";

            using (var conexao = new SQLiteConnection(ConnectionString))
            {
                conexao.Open();

                // Obter prioridades
                string comandoSQL1 = "SELECT DISTINCT Prioridade FROM Categorias ORDER BY Prioridade DESC";
                string comandoSQL2 = "SELECT SUM(Valor) FROM Despesas";

                using (var comando = new SQLiteCommand(comandoSQL1, conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            string PrioridadeNro = $"{leitor["Prioridade"]}";
                            string Prioridade;

                            if (PrioridadeNro == "3")
                            {
                                Prioridade = "Alta";
                            }
                            else if (PrioridadeNro == "2")
                            {
                                Prioridade = "Média";
                            }
                            else if (PrioridadeNro == "1")
                            {
                                Prioridade = "Baixa";
                            }
                            else Prioridade = "";

                            // Consulta despesas por prioridade
                            string comandoSQL = @"
                        SELECT 
                            Descricao, 
                            Valor, 
                            Data
                        FROM 
                            Despesas
                        WHERE 
                            Categoria IN (
                                SELECT ID FROM Categorias WHERE Prioridade = @prioridade
                            )
                        ORDER BY 
                            Data";

                            using (var comando2 = new SQLiteCommand(comandoSQL, conexao))
                            {
                                // Adicionando o parâmetro da prioridade
                                comando2.Parameters.AddWithValue("@prioridade", leitor["Prioridade"]);

                                using (var leitor2 = comando2.ExecuteReader())
                                {
                                    while (leitor2.Read()) // Verifique se há linhas para iterar
                                    {
                                        dataGridView1.Rows.Add(
                                            leitor2["Descricao"].ToString(),
                                            leitor2["Valor"].ToString(),
                                            Prioridade,
                                            Convert.ToDateTime(leitor2["Data"]).ToString("dd/MM/yyyy")
                                        );
                                    }
                                }
                            }
                        }
                    }
                }

                // Soma total de despesas
                using (var comando = new SQLiteCommand(comandoSQL2, conexao))
                {
                    object resultado = comando.ExecuteScalar();
                    decimal soma = (resultado != DBNull.Value) ? Convert.ToDecimal(resultado) : 0;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
