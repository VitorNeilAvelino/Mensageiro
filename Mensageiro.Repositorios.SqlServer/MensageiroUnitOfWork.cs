using Mensageiro.Dominio.Interfaces;
using System;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensageiroUnitOfWork : IDisposable, IMensageiroUnitOfWork
    {
        private MensageiroDbContext dbContext = new MensageiroDbContext();
        private UsuarioRepositorio usuarios;

        public IUsuarioRepositorio Usuarios { get { return usuarios ?? (usuarios = new UsuarioRepositorio(dbContext)); } }

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