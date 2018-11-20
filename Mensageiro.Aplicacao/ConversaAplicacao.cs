using AutoMapper;
using Mensageiro.Aplicacao.ViewModels;
using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using Mensageiro.Repositorios.SqlServer;
using System.Collections.Generic;

namespace Mensageiro.Aplicacao
{
    public class ConversaAplicacao
    {
        private readonly IMensageiroUnitOfWork db;

        public ConversaAplicacao(IMensageiroUnitOfWork mensageiroUnitOfWork)
        {
            db = mensageiroUnitOfWork;
        }

        public ConversaAplicacao()
        {
            db = new MensageiroUnitOfWork();
        }

        public List<MensagemViewModel> ObterMensagens(string remetenteId, string destinatarioId)
        {
            var mensagensReadModel = db.Conversas.ObterMensagens(remetenteId, destinatarioId);

            var mensagensViewModel = Mapper
                .Map<List<MensagemReadModel>, List<MensagemViewModel>>(mensagensReadModel);

            mensagensViewModel.ForEach(m => m.EhDestinatario = m.DestinatarioId == remetenteId);

            return mensagensViewModel;
        }

        public void AdicionarMensagem(string conteudo, int? conversaId, string remetenteId, string destinatarioId)
        {
            Conversa conversa;

            if (conversaId.HasValue)
            {
                conversa = db.Conversas.Obter(conversaId.Value);
            }
            else
            {
                conversa = new Conversa();

                conversa.Interlocutores.Add(db.Usuarios.Obter(destinatarioId));
                conversa.Interlocutores.Add(db.Usuarios.Obter(remetenteId));                
            }

            var mensagem = new Mensagem
            {
                Conteudo = conteudo,
                Destinatario = db.Usuarios.Obter(destinatarioId),
                Remetente = db.Usuarios.Obter(remetenteId),
                Conversa = conversa                
            };

            db.Mensagens.Inserir(mensagem);

            db.Salvar();
        }
    }
}