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
        private HttpStatusCode code;
        private string content;

        public TestHttpClient(HttpStatusCode code, string content)
        {
            this.code = code;
            this.content = content;
        }
        public HttpResponseMessage Get(string url)
        {
            return new HttpResponseMessage(code);
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return new HttpResponseMessage(code);
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return Task.Run(() => new HttpResponseMessage(code));
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return Task.Run(() => generateResponseMessage());
        }

        private HttpResponseMessage generateResponseMessage()
        {
            var msg = new HttpResponseMessage(code);
            msg.Content = new StringContent(content, Encoding.UTF8, "application/json");
            return msg;
        }
        public HttpRequestHeaders DefaultRequestHeaders => new HttpClient().DefaultRequestHeaders;
    }
}
