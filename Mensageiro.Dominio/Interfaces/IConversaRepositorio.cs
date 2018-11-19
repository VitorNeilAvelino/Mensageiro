using Mensageiro.Dominio.Entidades;
using System.Collections.Generic;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IConversaRepositorio
    {
        Conversa Obter(int id);
        void Inserir(Conversa conversa);
        List<MensagemReadModel> ObterMensagens(string userIdentity, string destinatarioId);
    }
}