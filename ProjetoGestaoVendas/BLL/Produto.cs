using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Produto
    {
        int codproduto;
        string nomeproduto;
        DateTime datavalidade;
        double preco;
        int quantidade;
        string unidade;
        int codcategoria;

        public int Codproduto { get => codproduto; set => codproduto = value; }
        public string Nomeproduto { get => nomeproduto; set => nomeproduto = value; }
        public DateTime Datavalidade { get => datavalidade; set => datavalidade = value; }
        public double Preco { get => preco; set => preco = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public string Unidade { get => unidade; set => unidade = value; }
        public int Codcategoria { get => codcategoria; set => codcategoria = value; }
    }
}
