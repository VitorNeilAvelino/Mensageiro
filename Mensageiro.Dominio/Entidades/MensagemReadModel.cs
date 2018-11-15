using System;

namespace Mensageiro.Dominio.Entidades
{
    public class MensagemReadModel
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime Horario { get; set; }
        public string RemetenteId { get; set; }
        public string DestinatarioId { get; set; }
    }
}