using System;

namespace Mensageiro.Dominio.Entidades
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime Horario { get; set; } = DateTime.Now;
        public Usuario Remetente { get; set; }
        public Usuario Destinatario { get; set; }
    }
}