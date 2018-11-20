using AutoMapper;
using Mensageiro.Aplicacao.ViewModels;
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

        public List<ContatoViewModel> ObterContatos(string id)
        {
            var contatosReadModel = db.Usuarios.ObterContatos(id);

            return Mapper.Map<List<ContatoReadModel>, List<ContatoViewModel>>(contatosReadModel);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}