using System;

namespace Mensageiro.Dominio.Entidades
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime Horario { get; set; } = DateTime.Now;
        public virtual Usuario Remetente { get; set; }
        public virtual Usuario Destinatario { get; set; }
        public virtual Conversa Conversa { get; set; }
    }
}