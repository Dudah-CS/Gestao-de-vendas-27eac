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
    public partial class frmAddCategoria : Form
    {
        BLL.Categoria cat = new BLL.Categoria();
        DAL.CategoriaDAL catDAL = new DAL.CategoriaDAL();

        public int codcategoria { get; set; }

        public frmAddCategoria()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            cat.Nomecategoria = txtNomeCategoria.Text;

            if (codcategoria > 0)
                catDAL.Atualizar(cat);
            else
                catDAL.Cadastrar(cat);

            MessageBox.Show("Dados gravados com sucesso!");
            Close();
        }

        private void frmAddCategoria_Load(object sender, EventArgs e)
        {
            if (codcategoria > 0) //editar
            {
                cat.Codcategoria = codcategoria;
                cat = catDAL.Retornar(cat);
                txtNomeCategoria.Text = cat.Nomecategoria;
            }
        }
    }
}
