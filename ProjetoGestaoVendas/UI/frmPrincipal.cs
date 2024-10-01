
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ProjetoGestaoVendas.BLL;
using ProjetoGestaoVendas.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ESSAS SAO AS BIBLIOTECAS QUE DEVEREMOS ADICIONAR EM NOSSO PROJETO
using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS

using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENÇÕES
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)
using System.Windows.Forms;

namespace ProjetoGestaoVendas.UI
{
    public partial class frmPrincipal : Form
    {


        public frmPrincipal()
        {
            InitializeComponent();
        }



        public void Zerar()
        {
            btnClientes.BackColor = Color.SlateBlue;
            btnCategorias.BackColor = Color.SlateBlue;
            btnProdutos.BackColor = Color.SlateBlue;
            btnVendas.BackColor = Color.SlateBlue;
        }



        private void btnClientes_Click(object sender, EventArgs e)
        {
            Zerar();
            btnClientes.BackColor = Color.Gray;
            pnlform.Controls.Clear();
            frmClientes cli = new frmClientes();
            cli.TopLevel = false;
            cli.AutoScroll = true;
            pnlform.Controls.Add(cli);
            cli.Dock = DockStyle.Fill;
            cli.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            Zerar();
            btnCategorias.BackColor = Color.Gray;
            pnlform.Controls.Clear();
            frmCategorias cat = new frmCategorias();
            cat.TopLevel = false;
            cat.AutoScroll = true;
            pnlform.Controls.Add(cat);
            cat.Dock = DockStyle.Fill;
            cat.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Zerar();
            btnProdutos.BackColor = Color.Gray;
            pnlform.Controls.Clear();
            frmProdutos prod = new frmProdutos();
            prod.TopLevel = false;
            prod.AutoScroll = true;
            pnlform.Controls.Add(prod);
            prod.Dock = DockStyle.Fill;
            prod.Show();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Zerar();
            btnVendas.BackColor = Color.Gray;// cor muda quando clica no botao
            pnlform.Controls.Clear();
            frmVendas vendas = new frmVendas();
            vendas.TopLevel = false;
            vendas.AutoScroll = true;
            pnlform.Controls.Add(vendas);
            vendas.Dock = DockStyle.Fill;
            vendas.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
            if (frmLogin.codusuario <= 0) Close();
            lblLogado.Text = "Usuário: " + frmLogin.nome;
            seja_bemVindo.Text = " " + frmLogin.nome;

        }


        private void btnTrocaUsuario_Click(object sender, EventArgs e)
        {

            Zerar();
            btnTrocaUsuario.BackColor = Color.Gray;// cor muda quando clica no botao
            pnlform.Controls.Clear();
            frmLogin trocaConta = new frmLogin();
            trocaConta.ShowDialog();

            if (frmLogin.codusuario <= 0) Close();
            lblLogado.Text = "Usuário: " + frmLogin.nome;
            Label seja_bemVindo = new Label();
            // Definindo a fonte do controle seja_bemVindo
            seja_bemVindo.Font = new System.Drawing.Font("Swis721 BlkCn BT", 30); // Use 'f' para especificar que é um float
            // Define a fonte, tamanho e estilo
            seja_bemVindo.AutoSize = true;
            seja_bemVindo.ForeColor = Color.Coral;
            seja_bemVindo.Location = new Point(226, 390);  // Define a localização do rótulo dentro do painel
            seja_bemVindo.Text = "" + frmLogin.nome;

            pnlform.Controls.Add(seja_bemVindo);


        }

        private void btnFechamentoCaixa_Click(object sender, EventArgs e)
        {
            carreagrDados dados = new carreagrDados();
            var produtos = dados.ObterProdutos();

            // Criar instância da classe GerarPDF
            GerarPDF gerarPDF = new GerarPDF();
            // Ajuste o caminho conforme necessário
          
            gerarPDF.PDF(produtos);

            MessageBox.Show("PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
    
}
