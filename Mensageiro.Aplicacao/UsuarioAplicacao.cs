using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using Mensageiro.Repositorios.SqlServer;
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

        public UsuarioAplicacao()
        {
            db = new MensageiroUnitOfWork();
        }

        public List<ContatoReadModel> ObterContatos(string id)
        {
            return db.Usuarios.ObterContatos(id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}