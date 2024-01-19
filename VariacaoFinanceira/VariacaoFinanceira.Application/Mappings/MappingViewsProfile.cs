using AutoMapper;
using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application.Mappings;

public class MappingViewsProfile : Profile
{
    public MappingViewsProfile() 
    { 
        CreateMap<Variacao, VariacaoAnaliticaDTO>().ReverseMap();
        CreateMap<Variacao, VariacaoDTO>().ReverseMap();
        CreateMap<Variacao, VariacaoResponseDTO>().ReverseMap();
    }
}
