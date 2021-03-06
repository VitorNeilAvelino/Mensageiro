﻿using Mensageiro.Dominio.Entidades;
using System.Collections.Generic;

namespace Mensageiro.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<ContatoReadModel> ObterContatos(string id);
        Usuario Obter(string id);
    }
}