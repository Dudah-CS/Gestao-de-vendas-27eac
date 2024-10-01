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
    public partial class frmProdutos : Form
    {
        BLL.Produto prod = new BLL.Produto();
        DAL.ProdutoDAL prodDAL = new DAL.ProdutoDAL();
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmAddProdutos add = new frmAddProdutos();
            add.ShowDialog();
            dgvConsulta.DataSource = prodDAL.ConsultarTodos();
        }        

        private void btnCaros_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = prodDAL.MaisBaratos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                frmAddProdutos add = new frmAddProdutos();
                add.codproduto = Convert.ToInt32(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                add.ShowDialog(); //abrir o form
                dgvConsulta.DataSource = prodDAL.ConsultarTodos();//atualizando a tabela
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prod.Codproduto = Convert.ToInt32(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                    prodDAL.Excluir(prod);
                    dgvConsulta.DataSource = prodDAL.ConsultarTodos();//atualizando a tabela
                }
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            prod.Nomeproduto = txtPesquisar.Text;
            dgvConsulta.DataSource = prodDAL.FiltrarPorNome(prod);
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = prodDAL.ConsultarTodos();
        }
    }
}
