namespace Mensageiro.Dominio.Interfaces
{
    public interface IMensageiroUnitOfWork
    {
        IUsuarioRepositorio Usuarios { get; }
        IConversaRepositorio Conversas { get; }
        IMensagemRepositorio Mensagens { get; }

        void Salvar();
        void Dispose();
    }
}