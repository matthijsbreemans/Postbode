using Postbode.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Postbode.Interfaces;
using Postbode.Sendgrid;
using Xunit;

namespace Postbode.Test
{
    public class TestSendgrid
    {
        [Fact]
        public async void SendgridTest()
        {
            var sendgridClient = new SendgridDeliveryService(apikey: "0x000", httpClient: new TestHttpClient(HttpStatusCode.OK, ""));
            IPostbode postbode = new PostbodeClient();
            postbode =
                postbode.Use(sendgridClient)
                    .SetRecipient("to@example.org")
                    .SetSender("sender@example.org")
                    .SetSubject("test")
                    .SetTextContent("HALLLOOOO");

            postbode.Mail.Headers = new Dictionary<string, string>() { { "test-key", "test-value" } };

            var result = await postbode.SendAsync();

            Assert.True(result.Succes);
        }

        [Fact]
        public async void SendgridFailTest()
        {
            var sendgridClient = new SendgridDeliveryService(apikey: "0x000", httpClient: new TestHttpClient(HttpStatusCode.BadRequest, ""));
            IPostbode postbode = new PostbodeClient();
            postbode =
                postbode.Use(sendgridClient)
                    .SetRecipient("to@example.org")
                    .SetSender("sender@example.org")
                    .SetSubject("test")
                    .SetTextContent("HALLLOOOO");

            postbode.Mail.Headers = new Dictionary<string, string>() { { "test-key", "test-value"}};

            var result = await postbode.SendAsync();

            Assert.False(result.Succes);
        }
    }
}
