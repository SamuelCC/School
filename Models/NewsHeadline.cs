namespace School.Models
{
    public class NewsHeadline
    {
        public required string Title { get; set; }
        public required string Url { get; set; }
        public string Source { get; set; } = "MSN";
        public DateTime PublishedDate { get; set; }
    }
}
