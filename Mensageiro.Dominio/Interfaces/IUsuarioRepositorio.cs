using Mensageiro.Dominio.Entidades;
using System.Collections.Generic;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<ContatoReadModel> ObterContatos(string id);
        List<MensagemReadModel> ObterMensagens(string userIdentity, string destinatarioId);
        Usuario Obter(string id);
    }
}