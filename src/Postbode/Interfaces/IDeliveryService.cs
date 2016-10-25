using System;
using System.Threading.Tasks;

namespace Postbode.Interfaces
{
    public interface IDeliveryService
    {
        Task<IResponse> SendAsync(IPostbode service = null);

        string Name { get; }
    }


}
