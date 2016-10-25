using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode
{
    public interface IContent
    {
        string Type { get; }

        string Content { get; set; }

        bool IsMime { get; }
    }
}
