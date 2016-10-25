using System;
using System.Threading.Tasks;

namespace Postbode.Interfaces
{
    public interface IDeliveryService : IDisposable
    {
        Task<IResponse> SendAsync(IPostbode service = null);

        string Name { get; }
    }


}
