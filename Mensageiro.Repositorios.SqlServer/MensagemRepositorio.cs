using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensagemRepositorio : IMensagemRepositorio
    {
        private readonly MensageiroDbContext contexto;

        public MensagemRepositorio(MensageiroDbContext mensageiroDbContext)
        {
            contexto = mensageiroDbContext;
        }

        public void Inserir(Mensagem mensagem)
        {
            contexto.Mensagens.Add(mensagem);
        }
    }
}