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
    public partial class frmVendas : Form
    {
        BLL.Produto prod = new BLL.Produto();
        DAL.ProdutoDAL prodDAL = new DAL.ProdutoDAL();

        BLL.Venda venda = new BLL.Venda();
        DAL.VendaDAL vendaDAL = new DAL.VendaDAL();

        BLL.Cliente cli = new BLL.Cliente();
        public frmVendas()
        {
            InitializeComponent();
        }

        private void btnQuantidade_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = vendaDAL.QuantidadeVendas();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmAddVenda add = new frmAddVenda();
            add.ShowDialog();
            dgvConsulta.DataSource = vendaDAL.ConsultarTodos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dgvConsulta.RowCount > 0 && MessageBox.Show("Deseja realmente excluir?","Excluir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                venda.Codvenda = Convert.ToInt32(dgvConsulta[0,dgvConsulta.CurrentRow.Index].Value);
                vendaDAL.Excluir(venda);
                dgvConsulta.DataSource = vendaDAL.ConsultarTodos();
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            cli.Nome = txtPesquisar.Text;
            dgvConsulta.DataSource = vendaDAL.FiltrarPorNome(cli);
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = vendaDAL.ConsultarTodos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = vendaDAL.ConsultarTodos();
        }
    }
}
