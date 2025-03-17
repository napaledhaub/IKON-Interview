namespace interview.Models
{
    public class Placeholder
    {
        public int UserId {  get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PlaceholderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
