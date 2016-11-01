using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Postbode.Interfaces;

namespace Postbode.Test
{
    public class TestHttpClient : IHttpHandler
    {
        public HttpResponseMessage Get(string url)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return Task.Run(() => new HttpResponseMessage(HttpStatusCode.OK));
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return Task.Run(() => generateResponseMessage());
        }

        private HttpResponseMessage generateResponseMessage()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.OK);
            msg.Content = new StringContent("[{}]", Encoding.UTF8, "application/json");
            return msg;
        }
        public HttpRequestHeaders DefaultRequestHeaders => new HttpClient().DefaultRequestHeaders;
    }
}
