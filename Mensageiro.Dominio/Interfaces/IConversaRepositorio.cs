using Mensageiro.Dominio.Entidades;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IConversaRepositorio
    {
        Conversa Obter(int id);
        void Inserir(Conversa conversa);
    }
}