using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode.Interfaces
{
    public interface IResponse
    {
        bool Succes { get; }

        string Message { get; }
    }
}
