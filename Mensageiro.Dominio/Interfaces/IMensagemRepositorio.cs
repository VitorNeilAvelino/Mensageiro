using Mensageiro.Dominio.Entidades;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IMensagemRepositorio
    {
        void Inserir(Mensagem mensagem);
    }
}