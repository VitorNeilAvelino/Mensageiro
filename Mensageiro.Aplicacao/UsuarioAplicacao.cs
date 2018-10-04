using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Mensageiro.Aplicacao
{
    public class UsuarioAplicacao : IDisposable
    {
        private readonly IMensageiroUnitOfWork db;

        public UsuarioAplicacao(IMensageiroUnitOfWork mensageiroUnitOfWork)
        {
            db = mensageiroUnitOfWork;
        }

        public List<Usuario> Obter()
        {
            return db.Usuarios.Obter();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}