using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetoGestaoVendas.DAL
{
    internal class Conexao
    {
        SqlConnection con = new SqlConnection("Data Source=COLOCAR O NOME DA SUA CONEXAO DO BANCO;Initial Catalog=BDGESTAOVENDAS;Integrated Security=True;Encrypt=False");
        public SqlConnection Conectar()
        {
            if(con.State == ConnectionState.Closed) { con.Open(); } 
            return con;
        }

        public void Desconectar()
        {
            if(con.State == ConnectionState.Open) { con.Close(); }
        }

    }
}
