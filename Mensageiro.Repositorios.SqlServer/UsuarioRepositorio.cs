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

        public List<ContatoReadModel> ObterContatos(string id)
        {
            return contexto.Usuarios
                .Where(u => u.Id != id)
                .Select(u => new ContatoReadModel
                {
                    ConteudoUltimaMensagem = u.Conversas
                            .SelectMany(c => c.Mensagems)
                            .Where(m => m.Destinatario.Id == id)
                            .OrderByDescending(m => m.Horario)
                            .FirstOrDefault().Conteudo,
                    DataUltimaMensagem = u.Conversas
                            .SelectMany(c => c.Mensagems)
                            .Where(m => m.Destinatario.Id == id)
                            .OrderByDescending(m => m.Horario)
                            .FirstOrDefault().Horario,
                    Id = u.Id,
                    Nome = u.Nome
                })
                .ToList();
        }

        public List<Mensagem> ObterMensagens(string userIdentity, string destinatarioId)
        {
            return contexto.Conversas
                .SelectMany(c => c.Mensagems)
                .Where(m => m.Remetente.Id == userIdentity && m.Destinatario.Id == destinatarioId
                    || m.Remetente.Id == destinatarioId && m.Destinatario.Id == userIdentity)
                .OrderBy(c => c.Horario)
                .ToList();
        }
    }
}