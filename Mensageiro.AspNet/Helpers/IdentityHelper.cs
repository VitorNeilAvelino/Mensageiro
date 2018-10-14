using System.Security.Claims;
using System.Security.Principal;

namespace Mensageiro.AspNet.Helpers
{
    public static class IdentityHelper
    {
        public static string ObterNome(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst("Nome").Value;
        }

        public static string ObterId(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}