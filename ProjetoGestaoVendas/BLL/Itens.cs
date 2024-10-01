using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Itens
    {
        int coditem;
        int codproduto;
        int codvenda;
        int quantidade;
        double preco;

        public int Coditem { get => coditem; set => coditem = value; }
        public int Codproduto { get => codproduto; set => codproduto = value; }
        public int Codvenda { get => codvenda; set => codvenda = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
    }
}
