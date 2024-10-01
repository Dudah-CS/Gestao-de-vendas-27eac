using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Categoria
    {
        int codcategoria;
        string nomecategoria;

        public int Codcategoria { get => codcategoria; set => codcategoria = value; }
        public string Nomecategoria { get => nomecategoria; set => nomecategoria = value; }
    }
}
