using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Venda
    {
        int codvenda;
        DateTime datavenda;
        string formapagto;
        int codcliente;
        int codusuario;

        public int Codvenda { get => codvenda; set => codvenda = value; }
        public DateTime Datavenda { get => datavenda; set => datavenda = value; }
        public string Formapagto { get => formapagto; set => formapagto = value; }
        public int Codcliente { get => codcliente; set => codcliente = value; }
        public int Codusuario { get => codusuario; set => codusuario = value; }
    }
}
