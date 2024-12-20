using System;
using System.Collections.Generic;
using System.Data.SQLite;

class BancoDeDados
{
    // Caminho do banco de dados
    private const string ConnectionString = "Data Source=gastos.db;Version=3;";

    // Método para criar o banco e a tabela
    public static void CriarTabela()
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();

            string comandoSQL = @"
                CREATE TABLE IF NOT EXISTS Despesas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descricao TEXT NOT NULL,
                    Categoria TEXT NOT NULL,
                    Valor REAL NOT NULL,
                    Data DATETIME NOT NULL,
                    Apenasdata TEXT NOT NULL
                );";

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                comando.ExecuteNonQuery();
            }

            Console.WriteLine("Tabela 'Despesas' criada/verificada com sucesso.");

            string comandoSQL2 = @"
                CREATE TABLE IF NOT EXISTS Categorias (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Prioridade INTEGER NOT NULL
                );";

            using (var comando = new SQLiteCommand(comandoSQL2, conexao))
            {
                comando.ExecuteNonQuery();
            }

            Console.WriteLine("Tabela 'Categorias' criada/verificada com sucesso.");
        }
    }

    // Método para inserir uma despesa
    public static void InserirDespesa(string descricao, int IDcategoria, double valor, string data)
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();

            DateTime datatime = DateTime.Parse(data);

            string comandoSQL = @"
                INSERT INTO Despesas (Descricao, Categoria, Valor, Data, Apenasdata)
                VALUES (@Descricao, @Categoria, @Valor, @Data, @Apenasdata);";

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                comando.Parameters.AddWithValue("@Descricao", descricao);
                comando.Parameters.AddWithValue("@Categoria", IDcategoria);
                comando.Parameters.AddWithValue("@Valor", valor);
                comando.Parameters.AddWithValue("@Data", datatime);
                comando.Parameters.AddWithValue("@Apenasdata", "01/01/2024");

                comando.ExecuteNonQuery();
            }
        }
    }

    public static Decimal RetornaValorTotal()
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            decimal valorTotal = 0;

            conexao.Open();

            string comandoSQL = $"SELECT sum(Valor) as ValorTotal FROM Despesas";

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                object resultado = comando.ExecuteScalar();
                valorTotal = (resultado != DBNull.Value) ? Convert.ToDecimal(resultado) : 0;
            }

            return valorTotal;
        }
    }

    public static void InserirCategoria(string nome, int prioridade)
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();

            string comandoSQL = "INSERT INTO Categorias (Nome,Prioridade) VALUES (@nome, @prioridade);";

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@prioridade", prioridade);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Categoria inserida com sucesso!");
    }

    // Método para remover uma despesa
    public static void RemoverDespesaECategoria(int id, int tipo)
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();

            if (tipo == 1)
            {
                string comandoSQL = "DELETE FROM Despesas WHERE Id = @Id";

                using (var comando = new SQLiteCommand(comandoSQL, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    Console.WriteLine(linhasAfetadas > 0 ? "Despesa removida com sucesso!" : "Despesa não encontrada.");
                }
            }
            else
            {
                string comandoSQL2 = "DELETE FROM Categorias WHERE Id = @Id";

                using (var comando = new SQLiteCommand(comandoSQL2, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    Console.WriteLine(linhasAfetadas > 0 ? "Categoria removida com sucesso!" : "Categoria não encontrada.");
                }
            }

        }
    }

    public static void GraficoCompletoDespesas()
    {
        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();
            Console.Clear();
            Console.WriteLine("8. Grafico completo das despesas.");
            Console.WriteLine("");

            string comandoSQL = "SELECT sum(valor) as valor, categoria FROM Despesas group by categoria order by valor desc";

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        int categoria = int.Parse(($"{leitor["Categoria"]}"));

                        string comandoSQL2 = $"SELECT Nome FROM Categorias WHERE Categorias.ID = '{categoria}'";
                        string nomeCategoria = "";
                        decimal valorTotal = BancoDeDados.RetornaValorTotal();
                        decimal valorCategoria = Convert.ToDecimal(leitor["Valor"]);

                        using (var comando2 = new SQLiteCommand(comandoSQL2, conexao))
                        {
                            using (var leitor2 = comando2.ExecuteReader())
                            {
                                while (leitor2.Read())
                                {
                                    nomeCategoria = ($"{leitor2["Nome"]}");
                                }
                            }
                        }

                        double valor = double.Parse(($"{leitor["Valor"]}"));

                        string grafico = "";
                        double valorAux = valor;

                        while (valorAux > 0)
                        {
                            valorAux = (valorAux - 35);
                            grafico = (grafico + "#");
                        }

                        decimal porcentagem = ((valorCategoria / valorTotal) * 100);

                        Console.Write($"{nomeCategoria,-13}");
                        Console.Write($"R$ {leitor["Valor"],-10:F2}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{grafico} {porcentagem:F2}%");
                        Console.ResetColor();
                        Console.WriteLine("");
                    }
                }
            }
        }
    }

    public static List<string> RetornaCategorias()
    {
        List<string> categorias = new List<string>();

        string comandoSQL = $"Select Nome from Categorias order by ID";

        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();

            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        categorias.Add($"{leitor["Nome"]}");
                    }
                }

            }
        }

        return categorias;
    }
    public static int RetornaIDCategoria(string categoria)
    {
        string comandoSQL = $"Select ID from Categorias where Nome = '{categoria}'";

        using (var conexao = new SQLiteConnection(ConnectionString))
        {
            conexao.Open();
            using (var comando = new SQLiteCommand(comandoSQL, conexao))
            {
                object resultado = comando.ExecuteScalar();

                int ID = (resultado != DBNull.Value) ? Convert.ToInt16(resultado) : 0;

                return ID;
            }
        }
    }
}

