using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mensageiro.Repositorios.SqlServer
{
    public class ConversaRepositorio : IConversaRepositorio
    {
        private readonly MensageiroDbContext contexto;

        public ConversaRepositorio(MensageiroDbContext mensageiroDbContext)
        {
            contexto = mensageiroDbContext;
        }

        public void Inserir(Conversa conversa)
        {
            contexto.Conversas.Add(conversa);
        }

        public Conversa Obter(int id)
        {
            return contexto.Conversas.Find(id);
        }

        public List<MensagemReadModel> ObterMensagens(string userIdentity, string destinatarioId)
        {
            return contexto.Conversas
                .SelectMany(c => c.Mensagens)
                .Where(m => m.Remetente.Id == userIdentity && m.Destinatario.Id == destinatarioId
                    || m.Remetente.Id == destinatarioId && m.Destinatario.Id == userIdentity)
                .OrderBy(c => c.Horario)
                .Select(m => new MensagemReadModel
                {
                    Conteudo = m.Conteudo,
                    DestinatarioId = m.Destinatario.Id,
                    Horario = m.Horario,
                    Id = m.Id,
                    RemetenteId = m.Remetente.Id
                })
                .ToList();
        }
    }
}