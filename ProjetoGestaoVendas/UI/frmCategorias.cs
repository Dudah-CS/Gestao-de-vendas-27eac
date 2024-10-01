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
    public partial class frmCategorias : Form
    {
        BLL.Categoria cat = new BLL.Categoria();
        DAL.CategoriaDAL catDAL = new DAL.CategoriaDAL();
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmAddCategoria add = new frmAddCategoria();
            add.ShowDialog();
            dgvConsulta.DataSource = catDAL.ConsultarTodos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cat.Codcategoria = Convert.ToInt32(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                    catDAL.Excluir(cat);
                    dgvConsulta.DataSource = catDAL.ConsultarTodos();//atualizando a tabela
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvConsulta.RowCount > 0)
            {
                frmAddCategoria add = new frmAddCategoria();
                add.codcategoria = Convert.ToInt32(dgvConsulta[0, dgvConsulta.CurrentRow.Index].Value);
                add.ShowDialog(); //abrir o form
                dgvConsulta.DataSource = catDAL.ConsultarTodos();//atualizando a tabela
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            cat.Nomecategoria = txtPesquisar.Text;
            dgvConsulta.DataSource = catDAL.FiltrarPorNome(cat);
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = catDAL.ConsultarTodos();
        }
    }
}
