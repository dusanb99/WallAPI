using System.ComponentModel.DataAnnotations;

namespace WallAPI.DTO
{
    public class CommentGetAllDTO
    {

        [Required]
        public int OriginPostId { get; set; }
    }
}
