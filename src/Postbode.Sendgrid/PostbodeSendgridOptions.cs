using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode.Sendgrid
{
    /// <summary>
    /// Class to map the configuration options
    /// </summary>
    public class PostbodeSendgridOptions
    {
        /// <summary>
        /// The Api Key used to connect to mailgun, can be obtained from the Sendgrid website
        /// </summary>
        public string ApiKey { get; set; }
    }
}
