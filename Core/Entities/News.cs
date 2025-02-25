namespace Core.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        public string? SourceUrl { get; set; }
    }
}