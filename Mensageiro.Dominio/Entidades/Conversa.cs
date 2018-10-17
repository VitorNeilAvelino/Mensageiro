using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades
{
    public class Conversa
    {
        public int Id { get; set; }
        public List<Usuario> Interlocutores { get; set; }
        public List<Mensagem> Mensagems { get; set; }
    }
}