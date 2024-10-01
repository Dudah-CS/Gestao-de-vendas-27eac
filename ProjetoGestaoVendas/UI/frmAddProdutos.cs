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
    public partial class frmAddProdutos : Form
    {
        BLL.Produto prod = new BLL.Produto();
        DAL.ProdutoDAL prodDAL = new DAL.ProdutoDAL();

        BLL.Categoria cat = new BLL.Categoria();
        DAL.CategoriaDAL catDAL = new DAL.CategoriaDAL();
        public int codproduto { get; set; }
        public frmAddProdutos()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            prod.Nomeproduto = txtNomeProduto.Text;
            prod.Preco = double.Parse(txtPreco.Text);
            prod.Quantidade = int.Parse(txtQuantidade.Text);
            prod.Datavalidade = txtDataValidade.Value;
            prod.Codcategoria = Convert.ToInt16(cmbCategoria.SelectedValue);
            prod.Unidade = cmbUnidade.Text;

            if (codproduto > 0)
                prodDAL.Atualizar(prod);
            else
                prodDAL.Cadastrar(prod);

            MessageBox.Show("Dados gravados com sucesso!");
            Close();
        }

        private void frmAddProdutos_Load(object sender, EventArgs e)
        {
            cmbCategoria.DataSource = catDAL.ConsultarTodos();
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "Código";

            if (codproduto > 0) //editar
            {
                prod.Codproduto = codproduto;
                prod = prodDAL.Retornar(prod);
                txtNomeProduto.Text     = prod.Nomeproduto;
                txtDataValidade.Value   = prod.Datavalidade;
                txtPreco.Text           = prod.Preco.ToString();
                txtQuantidade.Text      = prod.Quantidade.ToString();
                cmbUnidade.Text         = prod.Unidade;
                cmbCategoria.SelectedValue = prod.Codcategoria;
            }
        }
    }
}
