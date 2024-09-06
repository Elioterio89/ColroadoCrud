using AutoMapper;
using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Domain.Entities;

namespace ColoradoCrud.Api.Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {          
            CreateMap<Cliente, ClienteDto>()
                .ReverseMap(); 
            CreateMap<Telefone, TelefoneDto>()
                .ReverseMap(); 
            CreateMap<TipoTelefone, TipoTelefoneDto>()
                .ReverseMap(); 
        }
    }
}
