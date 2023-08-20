using AutoMapper;
using Server.DTOs;
using Server.Models;

namespace Server.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, Products_DTO>();
            CreateMap<Products_DTO, Products>();
        }
    }
}
