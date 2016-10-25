using Postbode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postbode.Smtp
{
    public class SmtpDeliveryService : IDeliveryService
    {
        public string Name => "System.Net.Smtp";

        public Task<IResponse> SendAsync(IPostbode service = null)
        {
            throw new NotSupportedException("Waiting for .NET Core 1.2.0");
        }
    }
}
