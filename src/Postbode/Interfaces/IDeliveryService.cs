using System;
using System.Threading.Tasks;

namespace Postbode.Interfaces
{
    public interface IDeliveryService
    {
        Task<IResponse> SendAsync(IPostbode postbode);

        string Name { get; }
    }


}
