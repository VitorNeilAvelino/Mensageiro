using Mensageiro.Dominio.Interfaces;
using Mensageiro.Repositorios.SqlServer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Mensageiro.AspNet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IMensageiroUnitOfWork, MensageiroUnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}