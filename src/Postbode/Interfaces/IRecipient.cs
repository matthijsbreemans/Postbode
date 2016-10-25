using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode
{
    public interface IRecipient
    {
        string Name { get; set; }

        string Email { get; set; }

    }

}
