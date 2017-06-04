namespace Blog.Unit.Tests.Models
{
    public class Article
    {
        public Article(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }
    }
}
