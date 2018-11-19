using Mensageiro.Dominio.Interfaces;
using System;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensageiroUnitOfWork : IDisposable, IMensageiroUnitOfWork
    {
        private MensageiroDbContext dbContext = new MensageiroDbContext();
        private IUsuarioRepositorio usuarios;
        private IConversaRepositorio conversas;
        private IMensagemRepositorio mensagens;

        public IUsuarioRepositorio Usuarios { get { return usuarios ?? (usuarios = new UsuarioRepositorio(dbContext)); } }
        public IConversaRepositorio Conversas { get { return conversas ?? (conversas = new ConversaRepositorio(dbContext)); } }
        public IMensagemRepositorio Mensagens { get { return mensagens ?? (mensagens = new MensagemRepositorio(dbContext)); } }

        public void Salvar()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}