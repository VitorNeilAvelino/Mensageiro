namespace Mensageiro.Aplicacao.ViewModels
{
    public class MensagemViewModel
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public string Horario { get; set; }
        public string RemetenteId { get; set; }
        public string DestinatarioId { get; set; }
        public bool EhDestinatario { get; set; }
    }
}