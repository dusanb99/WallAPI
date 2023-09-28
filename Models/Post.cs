namespace WallAPI.Models
{
    public class Post
    {

        public int Id { get; set; }

        public int UserId { get; set; }
        public string CreatorUsername { get; set; }

        public User User { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public List <Comment> Comments { get; set; }
    }
}
