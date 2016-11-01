using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode.Mailgun
{
    /// <summary>
    /// Class to map the configuration options
    /// </summary>
    public class PostbodeMailgunConfig
    {
        /// <summary>
        /// The domain 
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The Api Key used to connect to mailgun, can be obtained from the mailgun website
        /// </summary>
        public string ApiKey { get; set; }
    }
}
