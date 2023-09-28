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

            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<PostOutDTO, Post>().ReverseMap();

            CreateMap<CommentDTO, Comment>().ReverseMap();
            

        }
    }
}
