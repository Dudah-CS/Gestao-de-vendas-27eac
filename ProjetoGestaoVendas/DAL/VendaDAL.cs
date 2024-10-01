using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoGestaoVendas.DAL
{
    internal class VendaDAL
    {
        Conexao con = new Conexao();

        public int Cadastrar(BLL.Venda v)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Venda (DataVenda, FormaPagto, CodCliente,CodUsuario)
            VALUES (@DataVenda, @FormaPagto, @CodCliente, @CodUsuario);SELECT SCOPE_IDENTITY();";
            cmd.Parameters.AddWithValue("@DataVenda", v.Datavenda);
            cmd.Parameters.AddWithValue("@FormaPagto", v.Formapagto);
            cmd.Parameters.AddWithValue("@CodCliente", v.Codcliente);
            cmd.Parameters.AddWithValue("@CodUsuario", v.Codusuario);
            cmd.Connection = con.Conectar();//abrir a conexão
            int id = Convert.ToInt16(cmd.ExecuteScalar());
            con.Desconectar();
            return id;
        }


        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodVenda AS Código, DataVenda AS Data, FormaPagto AS [Forma de Pagamento], Cliente.Nome AS Cliente, Usuario.Nome AS Funcionário,
            (SELECT SUM(Itens.Preco * Itens.Quantidade) FROM Itens WHERE Itens.CodVenda = Venda.CodVenda) AS Total
            FROM Venda JOIN Cliente ON Cliente.CodCliente = Venda.CodCliente
            JOIN Usuario ON Usuario.CodUsuario = Venda.CodUsuario", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable QuantidadeVendas()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT Nome AS Cliente, COUNT(Cliente.CodCliente) AS [Quantidade de Compras] 
            FROM Venda JOIN Cliente ON Cliente.CodCliente = Venda.CodCliente
            GROUP BY Nome", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable FiltrarPorNome(BLL.Cliente cli)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodVenda AS Código, DataVenda AS Data, FormaPagto AS [Forma de Pagamento], Cliente.Nome AS Cliente, Usuario.Nome AS Funcionário,
            (SELECT SUM(Itens.Preco * Itens.Quantidade) FROM Itens WHERE Itens.CodVenda = Venda.CodVenda) AS Total
            FROM Venda JOIN Cliente ON Cliente.CodCliente = Venda.CodCliente
            JOIN Usuario ON Usuario.CodUsuario = Venda.CodUsuario
            WHERE Cliente.Nome LIKE @Nome", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@Nome", cli.Nome + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public void Excluir(BLL.Venda v)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM Itens WHERE CodVenda = @CodVenda;
            DELETE FROM Venda WHERE CodVenda = @CodVenda";
            cmd.Parameters.AddWithValue("@CodVenda", v.Codvenda);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }
    }
}
