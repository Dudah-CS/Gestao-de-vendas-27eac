using ProjetoGestaoVendas.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoGestaoVendas.UI
{
    public partial class frmLogin : Form
    {
        BLL.Usuario usu = new BLL.Usuario();
        DAL.UsuarioDAL usuDAL = new DAL.UsuarioDAL();
        public static string nome;
        public static int codusuario;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                usu.Nomeusuario = txtUsuario.Text;
                usu.Senha = txtSenha.Text;
                var resultado = usuDAL.Logar(usu);

                if (resultado.Sucesso)
                {
                    codusuario = resultado.Usuario.Codusuario;
                    nome = resultado.Usuario.Nome;
                    Close();
                }
                else
                {
                    MessageBox.Show(resultado.Mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { btnEntrar.PerformClick(); }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
