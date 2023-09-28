using System.ComponentModel.DataAnnotations;

namespace WallAPI.DTO
{
    public class UserLoginDTO
    {

        [Required]

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
