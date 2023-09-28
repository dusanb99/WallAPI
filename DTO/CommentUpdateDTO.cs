namespace WallAPI.DTO
{
    public class CommentUpdateDTO
    {

        public int Id { get; set; } 
        public int OriginPostId { get; set; }

        public string CreatorUsername { get; set; }

        public string Message { get; set; }
    }
}
