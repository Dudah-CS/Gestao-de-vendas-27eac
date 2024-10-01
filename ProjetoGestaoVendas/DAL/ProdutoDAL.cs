using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoGestaoVendas.DAL
{
    internal class ProdutoDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Produto prod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spCadastraProduto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomeProduto", prod.Nomeproduto);
            cmd.Parameters.AddWithValue("@DataValidade", prod.Datavalidade);
            cmd.Parameters.AddWithValue("@Preco", prod.Preco);
            cmd.Parameters.AddWithValue("@Quantidade", prod.Quantidade);
            cmd.Parameters.AddWithValue("@Unidade", prod.Unidade);
            cmd.Parameters.AddWithValue("@CodCategoria", prod.Codcategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Atualizar(BLL.Produto prod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spAtualizaProduto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodProduto", prod.Codproduto);
            cmd.Parameters.AddWithValue("@NomeProduto", prod.Nomeproduto);
            cmd.Parameters.AddWithValue("@DataValidade", prod.Datavalidade);
            cmd.Parameters.AddWithValue("@Preco", prod.Preco);
            cmd.Parameters.AddWithValue("@Quantidade", prod.Quantidade);
            cmd.Parameters.AddWithValue("@Unidade", prod.Unidade);
            cmd.Parameters.AddWithValue("@CodCategoria", prod.Codcategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Excluir(BLL.Produto prod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spDeletaProduto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodProduto", prod.Codproduto);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"spConsultar", con.Conectar());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable MaisBaratos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"spBaratos", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable FiltrarPorNome(BLL.Produto prod)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"spFiltroNome", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@NomeProduto","%" + prod.Nomeproduto + '%');
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public BLL.Produto Retornar(BLL.Produto prod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spRetornar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodProduto", prod.Codproduto);
            cmd.Connection = con.Conectar();//abrir a conexão
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                prod.Codproduto = Convert.ToInt16(dr["CodProduto"]);
                prod.Nomeproduto = dr["NomeProduto"].ToString();
                prod.Unidade = dr["Unidade"].ToString();
                prod.Datavalidade = Convert.ToDateTime(dr["DataValidade"]);
                prod.Preco = Convert.ToDouble(dr["Preco"]);
                prod.Quantidade = Convert.ToInt16(dr["Quantidade"]);
                prod.Codcategoria = Convert.ToInt16(dr["CodCategoria"]);
            }
            dr.Close();
            con.Desconectar();
            return prod;
        }
    }
}
