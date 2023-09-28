using WallAPI.DTO;

namespace WallAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<TokenDTO> Login(UserLoginDTO loginDTO);
        Task<UserOutDTO> Register(UserRegisterDTO userDto);
    }
}
