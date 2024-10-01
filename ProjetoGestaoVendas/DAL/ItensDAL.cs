using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoGestaoVendas.DAL
{
    internal class ItensDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Itens itens)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Itens 
            VALUES (@CodProduto, @CodVenda, @Quantidade,@Preco)";
            cmd.Parameters.AddWithValue("@CodProduto", itens.Codproduto);
            cmd.Parameters.AddWithValue("@CodVenda", itens.Codvenda);
            cmd.Parameters.AddWithValue("@Quantidade", itens.Quantidade);
            cmd.Parameters.AddWithValue("@Preco", itens.Preco);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }
    }
}
