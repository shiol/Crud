using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}
