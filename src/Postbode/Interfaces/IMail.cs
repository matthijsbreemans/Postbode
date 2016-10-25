using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postbode.Interfaces;

namespace Postbode
{
    public interface IMail
    {
        string Subject { get; set; }

        IContent Content { get; set; }

        IRecipient From { get; set; }

        ITemplate Template { get; set; }

        IRecipient[] To { get; set; }

        IRecipient[] Cc { get; set; }

        IRecipient[] Bcc { get; set; }

        Dictionary<string, string> Headers { get; set; }
    }
}
