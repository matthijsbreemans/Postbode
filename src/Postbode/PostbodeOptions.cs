using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode
{
    /// <summary>
    /// Class to map the configuration options
    /// </summary>
    public class PostbodeOptions
    {
        /// <summary>
        /// Set the default email address where to send from
        /// </summary>
        public string DefaultFromAddress { get; set; }
    }
}
