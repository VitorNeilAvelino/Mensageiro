using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using Mensageiro.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
