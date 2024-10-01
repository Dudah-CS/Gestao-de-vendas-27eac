namespace ProjetoGestaoVendas.UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlform = new System.Windows.Forms.Panel();
            this.seja_bemVindo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTrocaUsuario = new System.Windows.Forms.Button();
            this.btnFechamentoCaixa = new System.Windows.Forms.Button();
            this.lblLogado = new System.Windows.Forms.Label();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlform.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlform);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 617);
            this.panel1.TabIndex = 0;
            // 
            // pnlform
            // 
            this.pnlform.BackColor = System.Drawing.Color.Transparent;
            this.pnlform.BackgroundImage = global::ProjetoGestaoVendas.Properties.Resources.background2;
            this.pnlform.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlform.Controls.Add(this.seja_bemVindo);
            this.pnlform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlform.Location = new System.Drawing.Point(260, 44);
            this.pnlform.Name = "pnlform";
            this.pnlform.Size = new System.Drawing.Size(856, 571);
            this.pnlform.TabIndex = 2;
            // 
            // seja_bemVindo
            // 
            this.seja_bemVindo.AutoSize = true;
            this.seja_bemVindo.BackColor = System.Drawing.Color.White;
            this.seja_bemVindo.Font = new System.Drawing.Font("Swis721 BlkCn BT", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seja_bemVindo.ForeColor = System.Drawing.Color.Coral;
            this.seja_bemVindo.Location = new System.Drawing.Point(226, 390);
            this.seja_bemVindo.Name = "seja_bemVindo";
            this.seja_bemVindo.Size = new System.Drawing.Size(0, 42);
            this.seja_bemVindo.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSair);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(260, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(856, 44);
            this.panel3.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(810, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(46, 44);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "X";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateBlue;
            this.panel2.Controls.Add(this.btnTrocaUsuario);
            this.panel2.Controls.Add(this.btnFechamentoCaixa);
            this.panel2.Controls.Add(this.lblLogado);
            this.panel2.Controls.Add(this.btnVendas);
            this.panel2.Controls.Add(this.btnProdutos);
            this.panel2.Controls.Add(this.btnCategorias);
            this.panel2.Controls.Add(this.btnClientes);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 615);
            this.panel2.TabIndex = 0;
            // 
            // btnTrocaUsuario
            // 
            this.btnTrocaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrocaUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnTrocaUsuario.Image = global::ProjetoGestaoVendas.Properties.Resources.trocaFuncionario;
            this.btnTrocaUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrocaUsuario.Location = new System.Drawing.Point(133, 523);
            this.btnTrocaUsuario.Name = "btnTrocaUsuario";
            this.btnTrocaUsuario.Size = new System.Drawing.Size(42, 41);
            this.btnTrocaUsuario.TabIndex = 7;
            this.btnTrocaUsuario.Text = "\r\n";
            this.btnTrocaUsuario.UseVisualStyleBackColor = true;
            this.btnTrocaUsuario.Click += new System.EventHandler(this.btnTrocaUsuario_Click);
            // 
            // btnFechamentoCaixa
            // 
            this.btnFechamentoCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechamentoCaixa.ForeColor = System.Drawing.Color.Black;
            this.btnFechamentoCaixa.Image = global::ProjetoGestaoVendas.Properties.Resources.pdf2;
            this.btnFechamentoCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechamentoCaixa.Location = new System.Drawing.Point(67, 523);
            this.btnFechamentoCaixa.Name = "btnFechamentoCaixa";
            this.btnFechamentoCaixa.Size = new System.Drawing.Size(42, 41);
            this.btnFechamentoCaixa.TabIndex = 6;
            this.btnFechamentoCaixa.Text = "\r\n";
            this.btnFechamentoCaixa.UseVisualStyleBackColor = true;
            this.btnFechamentoCaixa.Click += new System.EventHandler(this.btnFechamentoCaixa_Click);
            // 
            // lblLogado
            // 
            this.lblLogado.AutoSize = true;
            this.lblLogado.ForeColor = System.Drawing.Color.Black;
            this.lblLogado.Location = new System.Drawing.Point(7, 586);
            this.lblLogado.Name = "lblLogado";
            this.lblLogado.Size = new System.Drawing.Size(67, 21);
            this.lblLogado.TabIndex = 0;
            this.lblLogado.Text = "Usuário:";
            // 
            // btnVendas
            // 
            this.btnVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendas.ForeColor = System.Drawing.Color.Black;
            this.btnVendas.Image = global::ProjetoGestaoVendas.Properties.Resources.vendas;
            this.btnVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendas.Location = new System.Drawing.Point(11, 276);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(241, 50);
            this.btnVendas.TabIndex = 5;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.ForeColor = System.Drawing.Color.Black;
            this.btnProdutos.Image = global::ProjetoGestaoVendas.Properties.Resources.produtos;
            this.btnProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutos.Location = new System.Drawing.Point(11, 220);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(241, 50);
            this.btnProdutos.TabIndex = 4;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.ForeColor = System.Drawing.Color.Black;
            this.btnCategorias.Image = global::ProjetoGestaoVendas.Properties.Resources.caixa;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(11, 164);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(241, 50);
            this.btnCategorias.TabIndex = 3;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = global::ProjetoGestaoVendas.Properties.Resources.cliente;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(11, 108);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(241, 50);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjetoGestaoVendas.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(187, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SlateBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestão Vendas";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 617);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.pnlform.ResumeLayout(false);
            this.pnlform.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel pnlform;
        private System.Windows.Forms.Label lblLogado;
        private System.Windows.Forms.Label seja_bemVindo;
        private System.Windows.Forms.Button btnFechamentoCaixa;
        private System.Windows.Forms.Button btnTrocaUsuario;
    }
}