using AutoMapper;
using ClienteAPI.Data.Dtos;
using ClienteAPI.Models;

namespace FilmesApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>();
    }
}
