using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postbode.Interfaces;

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

    /// <summary>
    /// Extension class for the Smtp delivery service
    /// </summary>
    public static class SmtpDeliveryServiceExtension
    {

        public static IPostbode UseSmtp(this IPostbode postbode)
        {
            postbode.Use(new SmtpDeliveryService());
            return postbode;
        }
    }
}
