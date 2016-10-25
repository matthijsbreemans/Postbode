namespace Postbode.Interfaces
{
    public interface IResponse
    {
        bool Succes { get; }

        string Message { get; }
    }
}
