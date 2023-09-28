using WallAPI.Models;

namespace WallAPI.DTO
{
    public class PostOutDTO
    {
        public int Id { get; set; }
        public string CreatorUsername { get; set; }

        public string Message { get; set; } 

        public DateTime CreatedAt { get; set; }

        public List<Comment> Comments { get; set; }

       // public int NumberOfViews { get; set; }

    }
}
