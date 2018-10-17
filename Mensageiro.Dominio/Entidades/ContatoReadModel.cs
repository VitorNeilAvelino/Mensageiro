using System;

namespace Mensageiro.Dominio.Entidades
{
    public class ContatoReadModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataUltimaMensagem { get; set; }
        public string ConteudoUltimaMensagem { get; set; }
    }
}