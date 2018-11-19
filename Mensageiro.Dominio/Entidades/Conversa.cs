using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades
{
    public class Conversa
    {
        public Conversa()
        {
            Interlocutores = new List<Usuario>();
            Mensagens = new List<Mensagem>();
        }

        public int Id { get; set; }
        public virtual List<Usuario> Interlocutores { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }
    }
}