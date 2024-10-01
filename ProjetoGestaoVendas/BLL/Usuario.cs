using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Usuario
    {
        int codusuario;
        string nome;
        string nomeusuario;
        string senha;

        public int Codusuario { get => codusuario; set => codusuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Nomeusuario { get => nomeusuario; set => nomeusuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
