using Mensageiro.Dominio.Entidades.Interfaces;
using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades
{
    public class Usuario : IUsuario
    {
        //public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }
    }
}