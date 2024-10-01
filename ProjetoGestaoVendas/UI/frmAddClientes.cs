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
    public partial class frmAddClientes : Form
    {
        BLL.Cliente cli = new BLL.Cliente();
        DAL.ClienteDAL cliDAL = new DAL.ClienteDAL();

        public int codcliente { get; set; }
        public frmAddClientes()
        {
            InitializeComponent();

            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            cli.Nome = txtNome.Text;
            cli.Email = txtEmail.Text;
            cli.Cpf = txtCPF.Text;

            if (codcliente > 0)
                cliDAL.Atualizar(cli);
            else 
                cliDAL.Cadastrar(cli);

            MessageBox.Show("Dados gravados com sucesso!");
            Close();
        }

        private void frmAddClientes_Load(object sender, EventArgs e)
        {
            if (codcliente > 0) //editar
            {
                cli.Codcliente = codcliente;
                cli = cliDAL.Retornar(cli);
                txtNome.Text = cli.Nome;
                txtCPF.Text = cli.Cpf;
                txtEmail.Text = cli.Email;
            }
        }
    }
}
