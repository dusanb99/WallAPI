namespace WallAPI.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public string Message { get; set; }

        public string CreatorUsername { get; set; }

        public Post OriginPost { get; set; }

        public int OriginPostId { get; set; }


    }
}
