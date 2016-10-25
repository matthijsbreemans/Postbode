using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postbode.Interfaces;

namespace Postbode
{
    public interface IDeliveryService : IDisposable
    {
        Task<IResponse> SendAsync(IPostbode service = null);

        string Name { get; }
    }


}
