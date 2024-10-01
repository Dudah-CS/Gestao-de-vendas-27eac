using ProjetoGestaoVendas.BLL;
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
    public partial class frmAddVenda : Form
    {
        DAL.ClienteDAL cliDAL = new DAL.ClienteDAL();
        DAL.ProdutoDAL prodDAL = new DAL.ProdutoDAL();
        BLL.Produto prod = new BLL.Produto();

        Venda venda = new Venda();
        VendaDAL vendaDAL = new VendaDAL();

        Itens itens = new Itens();
        ItensDAL itensDAL = new ItensDAL();
        
        public frmAddVenda()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddVenda_Load(object sender, EventArgs e)
        {
            cmbClientes.DataSource = cliDAL.ConsultarTodos();
            cmbClientes.DisplayMember = "Nome";
            cmbClientes.ValueMember = "Código";

            cmbProduto.DataSource = prodDAL.ConsultarTodos();
            cmbProduto.DisplayMember = "Produto";
            cmbProduto.ValueMember = "Código";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cmbProduto.SelectedValue) <= 0 && txtQuantidade.Value <= 0) return;
            prod.Codproduto = Convert.ToInt16(cmbProduto.SelectedValue);
            prod = prodDAL.Retornar(prod);
            int quantidade = Convert.ToInt32(txtQuantidade.Value);
            double subtotal = prod.Preco * quantidade;
            if (prod.Quantidade < quantidade)
            {
                MessageBox.Show("Estoque insuficiente", "Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                if (Convert.ToInt32(dgvItens[0, i].Value) == Convert.ToInt32(cmbProduto.SelectedValue))
                {
                    quantidade += Convert.ToInt32(dgvItens[2, i].Value);
                    if (prod.Quantidade < quantidade)
                    {
                        MessageBox.Show("Estoque insuficiente", "Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    subtotal = prod.Preco * quantidade;
                    dgvItens[2, i].Value = quantidade;
                    dgvItens[4, i].Value = subtotal;
                    calcularTotal();
                    return;
                }
            }

            dgvItens.Rows.Add(cmbProduto.SelectedValue.ToString(),cmbProduto.Text, txtQuantidade.Text,prod.Preco.ToString("n"), subtotal.ToString("n"));
            calcularTotal();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if(dgvItens.RowCount > 0)
            {
                dgvItens.Rows.Remove(dgvItens.CurrentRow);
            }
            calcularTotal();
        }

        public void calcularTotal()
        {
            double total = 0;
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                total += Convert.ToDouble(dgvItens[4,i].Value);
            }
            lblTotal.Text = "Total: R$ " + total.ToString("n");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(dgvItens.RowCount <= 0 || Convert.ToInt16(cmbClientes.SelectedValue) <= 0 || cmbForma.Text.Trim() == "")
            {
                MessageBox.Show("Preencha corretamente as informações","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            venda.Datavenda = DateTime.Now;
            venda.Codcliente = Convert.ToInt32(cmbClientes.SelectedValue);
            venda.Formapagto = cmbForma.Text;
            venda.Codusuario = frmLogin.codusuario;
            itens.Codvenda = vendaDAL.Cadastrar(venda);
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                itens.Codproduto = Convert.ToInt32(dgvItens[0,i].Value);
                itens.Quantidade = Convert.ToInt32(dgvItens[2, i].Value);
                itens.Preco = Convert.ToDouble(dgvItens[3, i].Value);
                itensDAL.Cadastrar(itens);
            }
            MessageBox.Show("Dados gravados com sucesso!", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            dgvItens.Rows.Clear(); //limpar grid
        }
    }
}
