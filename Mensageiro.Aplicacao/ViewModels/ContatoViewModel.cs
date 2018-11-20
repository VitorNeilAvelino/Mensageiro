namespace Mensageiro.Aplicacao.ViewModels
{
    public class ContatoViewModel
    {
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string DataUltimaMensagem { get; set; }
        public string ConteudoUltimaMensagem { get; set; }
        public int? ConversaId { get; set; }
    }
}