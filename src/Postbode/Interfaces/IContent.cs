namespace Postbode.Interfaces
{
    public interface IContent
    {
        string Type { get; }

        string Content { get; set; }

        bool IsMime { get; }
    }
}
