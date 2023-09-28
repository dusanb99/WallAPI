using System.ComponentModel.DataAnnotations;

namespace WallAPI.DTO
{
    public class CommentDTO
    {

        [Required]
        public string Message { get; set; }


        [Required]
        public string CreatorUsername { get; set; }

        [Required]
        public int OriginPostId { get; set; }



    }
}
