using Mensageiro.Dominio.Entidades;
using System.Collections.Generic;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> ObterContatos(string id);
    }
}