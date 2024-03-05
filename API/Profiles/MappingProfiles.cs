using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Main
        CreateMap<Pelicula, PeliculaDto>().ReverseMap();
        //JWT
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
