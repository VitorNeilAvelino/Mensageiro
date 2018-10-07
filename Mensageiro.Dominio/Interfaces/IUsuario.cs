using System.Collections.Generic;

namespace Mensageiro.Dominio.Entidades.Interfaces
{
    public interface IUsuario
    {
        List<Mensagem> Mensagens { get; set; }
        string Nome { get; set; }
    }
}