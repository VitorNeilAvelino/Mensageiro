using System;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensageiroUnitOfWork : IDisposable
    {
        private MensageiroDbContext dbContext = new MensageiroDbContext();
        private UsuarioRepositorio usuarios;

        public UsuarioRepositorio Usuarios { get { return usuarios ?? (usuarios = new UsuarioRepositorio(dbContext)); } }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}