using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Mensageiro.Dominio.Entidades;

namespace Mensageiro.AspNet.Helpers
{
    public static class JsonCamelCaseHelper
    {
        public static JsonCamelCaseResult JsonCamelCase(this Controller controller, object data)
        {
            return new JsonCamelCaseResult
            {
                Data = data
            };
        }
    }
}