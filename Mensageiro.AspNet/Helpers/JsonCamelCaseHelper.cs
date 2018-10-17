using System.Web.Mvc;

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