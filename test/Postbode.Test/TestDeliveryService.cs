using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postbode.Client;
using Postbode.Interfaces;

namespace Postbode.Test
{
    public class TestDeliveryService : IDeliveryService
    {

        public Task<IResponse> SendAsync(IPostbode service = null)
        {
            return Task.FromResult<IResponse>(new Response(true, service.Mail.Content.Content));
        }

        public string Name => "Test";
    }
}
