using AutoMapper;
using MyWebAPI.Models;
using MyWebAPI.DTOs;
namespace MyWebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source -> Destination
            //From API to Database
            CreateMap<LaptopCreateDTO, Laptop>();
            CreateMap<LaptopUpdateDTO, Laptop>();

            //From Database to API
            CreateMap<Laptop, LaptopReadDTO>();

            //If you want to support both directions(Create/Update):
            //CreateMap<LaptopCreateDto, Laptop>().ReverseMap();
        }
    }
}