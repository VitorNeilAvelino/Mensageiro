using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }
    }
}