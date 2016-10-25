namespace Postbode
{
    public class TextContent : IContent
    {
        public string Type => "text/plain";
        public string Content { get; set; }
        public bool IsMime => false;
        public TextContent(string content = null)
        {
            Content = content;
        }
    }

    public static class TextContentExtension
    {
        public static IPostbode SetTextContent(this IPostbode postbode, string content)
        {
            postbode.SetContent(new TextContent(content));
            return postbode;
        }
    }
}
