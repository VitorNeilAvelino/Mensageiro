using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades.Interfaces
{
    public interface IUsuario
    {
        string Id { get; set; }
        List<Mensagem> Mensagens { get; set; }
        string Nome { get; set; }
    }
}