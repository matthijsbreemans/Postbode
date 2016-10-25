using Postbode.Interfaces;

namespace Postbode.Content
{
    public class HtmlContent : IContent
    {
        public string Type => "text/html";

        public string Content { get; set; }

        public bool IsMime => false;

        public HtmlContent(string content = null)
        {
            Content = content;
        }
    }

    public static class HtmlContentExtension
    {
        public static IPostbode SetHtmlContent(this IPostbode postbode, string html)
        {
            postbode.SetContent(new HtmlContent(html));
            return postbode;
        }
    }


}
