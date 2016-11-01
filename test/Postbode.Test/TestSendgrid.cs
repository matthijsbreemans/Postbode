using Postbode.Content;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var sendgridClient = new SendgridDeliveryService(apikey: "0x000", httpClient: new TestHttpClient());
           var result = await  new PostbodeClient().Use(sendgridClient).SetRecipient("to@example.org").SetSender("sender@example.org").SetSubject("test").SetTextContent("HALLLOOOO").SendAsync();

            Assert.True(result.Succes);
        }
    }
}
