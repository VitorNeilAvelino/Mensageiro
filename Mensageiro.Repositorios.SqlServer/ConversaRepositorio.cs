using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;

namespace Mensageiro.Repositorios.SqlServer
{
    public class ConversaRepositorio : IConversaRepositorio
    {
        private readonly MensageiroDbContext contexto;

        public ConversaRepositorio(MensageiroDbContext mensageiroDbContext)
        {
            contexto = mensageiroDbContext;
        }

        public void Inserir(Conversa conversa)
        {
            contexto.Conversas.Add(conversa);
        }

        public Conversa Obter(int id)
        {
            return contexto.Conversas.Find(id);
        }
    }
}