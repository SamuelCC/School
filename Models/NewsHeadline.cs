namespace School.Models
{
    public class NewsHeadline
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }
}
