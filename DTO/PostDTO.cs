using System.ComponentModel.DataAnnotations;

namespace WallAPI.DTO
{
    public class PostDTO
    {


        [Required]
        public string CreatorUsername { get; set; }


        [Required]
        public string Message { get; set; }

        
    }
}
