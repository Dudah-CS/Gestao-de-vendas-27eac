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
    public partial class frmClientes : Form
    {
        BLL.Cliente cli = new BLL.Cliente();
        DAL.ClienteDAL cliDAL = new DAL.ClienteDAL();
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = cliDAL.ConsultarTodos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmAddClientes add = new frmAddClientes();
            add.ShowDialog();
            dgvConsulta.DataSource = cliDAL.ConsultarTodos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dgvConsulta.RowCount > 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?","Excluir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cli.Codcliente = Convert.ToInt32(dgvConsulta[0,dgvConsulta.CurrentRow.Index].Value);
                    cliDAL.Excluir(cli);
                    dgvConsulta.DataSource = cliDAL.ConsultarTodos();//atualizando a tabela
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                frmAddClientes add = new frmAddClientes();
                add.codcliente = Convert.ToInt32(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                add.ShowDialog(); //abrir o form
                dgvConsulta.DataSource = cliDAL.ConsultarTodos();//atualizando a tabela
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            cli.Nome = txtPesquisar.Text;
            dgvConsulta.DataSource = cliDAL.FiltrarPorNome(cli);
        }
    }
}
