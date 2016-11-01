using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Postbode.Content;
using Postbode.Smtp;
using Xunit;

namespace Postbode.Test
{

    public class TestSmtp
    {
        [Fact]
        public async void TestSmtpDelivery()
        {
            var postbode = new PostbodeClient().SetSender("test@test.nl").SetRecipient("test2@test2.nl", type: RecipientType.Cc)
                .SetTextContent("test").Use(new SmtpDeliveryService());
            await Assert.ThrowsAsync<NotImplementedException>(() => postbode.SendAsync());
        }

        [Fact]
        public void SmtpNameTest()
        {
            var client = new PostbodeClient().UseSmtp();

            Assert.Equal(client.DeliveryService.Name.ToLowerInvariant(), "system.net.smtp");
        }
    }
}
