using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoGestaoVendas.DAL
{
    internal class ClienteDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Cliente cli)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spCadastrarCliente";
            cmd.CommandType = CommandType.StoredProcedure; //necessária
            cmd.Parameters.AddWithValue("@Nome", cli.Nome);
            cmd.Parameters.AddWithValue("@CPF", cli.Cpf);
            cmd.Parameters.AddWithValue("@Email", cli.Email);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Atualizar(BLL.Cliente cli)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"spAtualizarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cli.Nome);
            cmd.Parameters.AddWithValue("@CPF", cli.Cpf);
            cmd.Parameters.AddWithValue("@Email", cli.Email);
            cmd.Parameters.AddWithValue("@CodCliente", cli.Codcliente);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public void Excluir(BLL.Cliente cli)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Cliente WHERE CodCliente = @CodCliente";
            cmd.Parameters.AddWithValue("@CodCliente", cli.Codcliente);
            cmd.Connection = con.Conectar();//abrir a conexão
            cmd.ExecuteNonQuery();//executar o comando
            con.Desconectar();
        }

        public DataTable ConsultarTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodCliente AS Código,
            Nome, Cpf, Email AS [E-mail] FROM Cliente", con.Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable FiltrarPorNome(BLL.Cliente cli)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT CodCliente AS Código,
            Nome, Cpf, Email AS [E-mail] FROM Cliente
            WHERE Nome LIKE @Nome", con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@Nome",cli.Nome + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public BLL.Cliente Retornar(BLL.Cliente cli)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente WHERE CodCliente = @CodCliente";
            cmd.Parameters.AddWithValue("@CodCliente", cli.Codcliente);
            cmd.Connection = con.Conectar();//abrir a conexão
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                cli.Codcliente = Convert.ToInt16(dr["CodCliente"]);
                cli.Nome = dr["Nome"].ToString();
                cli.Cpf = dr["CPF"].ToString();
                cli.Email = dr["Email"].ToString();
            }
            dr.Close();
            con.Desconectar();
            return cli;
        }
    }
}
