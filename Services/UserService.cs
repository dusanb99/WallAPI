using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Repositories;
using WallAPI.Repositories.Interface;
using WallAPI.Services.Interfaces;

namespace WallAPI.Services
{
    public class UserService : IUserService
    {

        public readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly string _secretKey;

        public UserService(IUserRepository userRepository, IConfiguration config, IMapper mapper)
        {
            _userRepository = userRepository;
            _secretKey = config.GetSection("SecretKey").Value;
            _mapper = mapper;

        }

        public async Task<UserOutDTO> Register(UserRegisterDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);
            if (await _userRepository.GetUser(user.Username) != null
                || await _userRepository.GetUserByEmail(user.Email) != null)
            {
                return null;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);


            _userRepository.AddUser(user);

            UserOutDTO userOutDTO = new UserOutDTO();
            userOutDTO.Username = user.Username;
            return userOutDTO;
        }

        public async Task<TokenDTO> Login(UserLoginDTO loginDTO)
        {
            TokenDTO retVal = new TokenDTO();
            User userFromDb = await _userRepository.GetUser(loginDTO.Username);

            if (userFromDb != null)
            {
                retVal.Error = "-1";
                //return null;
            }

            if (BCrypt.Net.BCrypt.Verify(loginDTO.Password, userFromDb.Password))
            {
                List<Claim> claims = new List<Claim>();


                

                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:31210",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials
                );
                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return new TokenDTO()
                {
                    Value = tokenString
                };
            }
            else
            {
                retVal.Error += "-2";
            }

            return retVal;
        }

    }
}
