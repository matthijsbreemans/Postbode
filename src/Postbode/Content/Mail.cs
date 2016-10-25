using System.Collections.Generic;
using Postbode.Interfaces;

namespace Postbode.Content
{
    public class Mail : IMail
    {
        public string Subject { get; set; }

        public IContent Content { get; set; }
        public IRecipient From { get; set; }

        public ITemplate Template { get; set; }
        public IRecipient[] To { get; set; }
        public IRecipient[] Cc { get; set; }
        public IRecipient[] Bcc { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}