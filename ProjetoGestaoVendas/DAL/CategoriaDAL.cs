using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoGestaoVendas.DAL
{
    internal class CategoriaDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Categoria cat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Categoria (NomeCategoria) VALUES (@NomeCategoria)";
            cmd.Parameters.AddWithValue("@NomeCategoria", cat.Nomecategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Atualizar(BLL.Categoria cat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Categoria SET NomeCategoria = @NomeCategoria
            WHERE CodCategoria = @CodCategoria";
            cmd.Parameters.AddWithValue("@NomeCategoria", cat.Nomecategoria);
            cmd.Parameters.AddWithValue("@CodCategoria", cat.Codcategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Excluir(BLL.Categoria cat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Categoria WHERE CodCategoria = @CodCategoria";
            cmd.Parameters.AddWithValue("@CodCategoria", cat.Codcategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodCategoria AS Código, 
            NomeCategoria AS Categoria FROM Categoria ORDER BY NomeCategoria", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable FiltrarPorNome(BLL.Categoria cat)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodCategoria AS Código, 
            NomeCategoria AS Categoria FROM Categoria
            WHERE NomeCategoria LIKE @NomeCategoria", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@NomeCategoria", cat.Nomecategoria + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public BLL.Categoria Retornar(BLL.Categoria cat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Categoria WHERE CodCategoria = @CodCategoria";
            cmd.Parameters.AddWithValue("@CodCategoria", cat.Codcategoria);
            cmd.Connection = con.Conectar();//abrir a conexão
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cat.Codcategoria = Convert.ToInt16(dr["CodCategoria"]);
                cat.Nomecategoria = dr["NomeCategoria"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return cat;
        }
    }
}
