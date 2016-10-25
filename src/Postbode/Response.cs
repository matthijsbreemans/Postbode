using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postbode.Interfaces;

namespace Postbode
{
    public class Response : IResponse
    {
        public bool Succes { get; }
        public string Message { get; }

        public Response(bool succes, string message)
        {
            Succes = succes;
            Message = message;
        }
    }
}
