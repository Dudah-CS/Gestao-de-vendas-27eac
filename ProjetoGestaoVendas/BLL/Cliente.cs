using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoVendas.BLL
{
    internal class Cliente
    {
        int codcliente;
        string nome;
        string cpf;
        string email;

        public int Codcliente { get => codcliente; set => codcliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
    }
}
