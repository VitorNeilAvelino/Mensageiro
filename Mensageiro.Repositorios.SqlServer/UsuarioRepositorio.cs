using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mensageiro.Repositorios.SqlServer
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MensageiroDbContext contexto;

        public UsuarioRepositorio(MensageiroDbContext mensageiroDbContext)
        {
            contexto = mensageiroDbContext;
        }

        public Usuario Obter(string id)
        {
            return contexto.Usuarios.Find(id);
        }

        public List<ContatoReadModel> ObterContatos(string id)
        {
            return contexto.Usuarios
                .Where(u => u.Id != id)
                .Select(u => new ContatoReadModel
                {
                    ConteudoUltimaMensagem = u.Conversas
                            .SelectMany(c => c.Mensagens)
                            .Where(m => m.Destinatario.Id == id || m.Remetente.Id == id)
                            .OrderByDescending(m => m.Horario)
                            .FirstOrDefault().Conteudo,
                    DataUltimaMensagem = u.Conversas
                            .SelectMany(c => c.Mensagens)
                            .Where(m => m.Destinatario.Id == id || m.Remetente.Id == id)
                            .OrderByDescending(m => m.Horario)
                            .FirstOrDefault().Horario,
                    ConversaId = u.Conversas
                            .FirstOrDefault(c => c.Interlocutores.Any(i => i.Id == id)).Id,
                    UsuarioId = u.Id,
                    Nome = u.Nome
                })
                .OrderByDescending(c => c.DataUltimaMensagem)
                .ToList();
        }
    }
}