using System.ComponentModel.DataAnnotations;

namespace WallAPI.DTO
{
    public class UserRegisterDTO
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
