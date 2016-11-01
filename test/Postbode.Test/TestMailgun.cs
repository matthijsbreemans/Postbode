using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postbode.Content;
using Postbode.Mailgun;
using Postbode.Sendgrid;
using Xunit;

namespace Postbode.Test
{
    public class TestMailgun
    {
        [Fact]
        public async void MailgunTest()
        {
            var mailgunClient = new MailgunDeliveryService(domain: "test.nl" ,apikey: "0x000", httpClient: new TestHttpClient());
            var postbode = new PostbodeClient();
            var result = await postbode.Use(mailgunClient).SetRecipient("to@example.org").SetSender("sender@example.org").SetSubject("test").SetTextContent("HALLLOOOO").SendAsync();

            Assert.True(result.Succes);
        }
    }
}
