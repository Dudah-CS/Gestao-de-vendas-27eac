using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjetoGestaoVendas.BLL;

namespace ProjetoGestaoVendas.DAL
{
    internal class UsuarioDAL
    {
        Conexao con = new Conexao();

        public SucessoLogin Logar(BLL.Usuario usu)
        {
            var resultado = new SucessoLogin();

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario AND Senha = @Senha";
                cmd.Parameters.AddWithValue("@NomeUsuario", usu.Nomeusuario ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Senha", usu.Senha ?? (object)DBNull.Value);
                cmd.Connection = con.Conectar(); // Abrir a conexão

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usu.Codusuario = Convert.ToInt16(dr["CodUsuario"]);
                        usu.Nome = dr["Nome"].ToString();
                        usu.Nomeusuario = dr["NomeUsuario"].ToString();

                        resultado.Sucesso = true;
                        resultado.Usuario = usu;
                    }
                    else
                    {
                        resultado.Sucesso = false;
                        resultado.Mensagem = "Usuário ou senha inválidos.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = $"Erro: {ex.Message}";
            }
            finally
            {
                con.Desconectar();
            }

            return resultado;
        }
    }


}
