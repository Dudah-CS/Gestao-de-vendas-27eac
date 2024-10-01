using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.DAL
{

    public class carreagrDados
    {
        private string connectionString;

        public carreagrDados()
        {
            // Ajuste a string de conexão conforme necessário
            connectionString = @"Data Source=WS-DANILO\TEW_SQLEXPRESS;Initial Catalog=BDGESTAOVENDAS;Integrated Security=True;Encrypt=False";
        }

        public List<(string NomeProduto, decimal Preco)> ObterProdutos()
        {
            List<(string NomeProduto, decimal Preco)> produtos = new List<(string, decimal)>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Certifique-se de que a conexão está sendo aberta corretamente
                string query = "SELECT NomeProduto, Preco FROM Produto"; // Ajuste o nome da tabela conforme necessário
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nomeProduto = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                            var preco = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                            produtos.Add((nomeProduto, preco));
                        }
                    }
                }
            }

            return produtos;
        }
    }
}
