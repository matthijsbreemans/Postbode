using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode
{
    public interface IDeliveryService : IDisposable
    {
        IPostbode Postbode { get; set; }

        Task SendAsync(IPostbode service = null);

        string Name { get; }
    }


}
