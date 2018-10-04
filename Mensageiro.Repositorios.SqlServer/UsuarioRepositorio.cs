using Mensageiro.Dominio.Entidades;
using Mensageiro.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mensageiro.Repositorios.SqlServer
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MensageiroDbContext contexto;

        public UsuarioRepositorio(MensageiroDbContext mensageiroDbContext)
        {
            contexto = mensageiroDbContext;
        }

        public List<Usuario> Obter()
        {
            return contexto.Usuarios.ToList();
        }
    }
}