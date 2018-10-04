namespace Mensageiro.Dominio.Interfaces
{
    public interface IMensageiroUnitOfWork
    {
        IUsuarioRepositorio Usuarios { get; }
        void Salvar();
        void Dispose();
    }
}