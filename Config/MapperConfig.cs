using AutoMapper;
using WallAPI.DTO;
using WallAPI.Models;

namespace WallAPI.Config
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
           
            CreateMap<UserRegisterDTO, User>().ReverseMap();
        }
    }
}
