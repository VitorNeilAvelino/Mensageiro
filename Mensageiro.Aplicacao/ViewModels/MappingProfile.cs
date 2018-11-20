using Mensageiro.Dominio.Entidades;

namespace Mensageiro.Aplicacao.ViewModels
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<MensagemReadModel, MensagemViewModel>()
                .ForMember(
                    dest => dest.Horario,
                    opt => opt.MapFrom(src => src.Horario.ToString("HH:mm")));

            CreateMap<ContatoReadModel, ContatoViewModel>()
                .ForMember(
                    dest => dest.DataUltimaMensagem,
                    opt => opt.MapFrom(src => src.DataUltimaMensagem.HasValue ?
                    src.DataUltimaMensagem.Value.ToString("HH:mm") : null));
        }
    }
}