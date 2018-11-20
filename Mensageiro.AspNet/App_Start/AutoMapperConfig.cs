using AutoMapper;
using Mensageiro.Aplicacao.ViewModels;

namespace Mensageiro.AspNet.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MappingProfile());                
            });
        }
    }
}