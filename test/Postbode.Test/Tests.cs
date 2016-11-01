using System;
using Microsoft.Extensions.Options;
using Postbode.Test;
using Xunit;
using Postbode;
using Postbode.Content;
using Postbode.Interfaces;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public async void SimpelTest()
        {
            var response = await new Postbode.PostbodeClient().SetTextContent("test").Use(new TestDeliveryService()).SendAsync();

            Assert.True(response.Succes);

            Assert.Equal("test", response.Message);
        }
        [Fact]
        public void TestHtmlContent()
        {
            var response = new PostbodeClient().SetHtmlContent("<h1>Test</h1>");

            Assert.Equal("text/html", response.Mail.Content.Type);
        }

        [Fact]
        public void RecipientTest()
        {
            var postbode = new PostbodeClient()
                .SetRecipients(new IRecipient[] {new Recipient("test@test.nl", "test"), new Recipient("test2@test.nl", "test2")},
                    RecipientType.To)
                .SetRecipients(new IRecipient[] {new Recipient("test@test.nl", "test"), new Recipient("test2@test.nl", "test2")},
                    RecipientType.Cc)
                .SetRecipients(new IRecipient[] {new Recipient("test@test.nl", "test"), new Recipient("test2@test.nl", "test2")},
                    RecipientType.Bcc);

            Assert.Equal(2, postbode.Mail.To.Length);
            Assert.Equal(2, postbode.Mail.Cc.Length);
            Assert.Equal(2, postbode.Mail.Bcc.Length);
        }

        [Fact]
        public void DefaultFromTest()
        {

           var options =  Options.Create(new PostbodeOptions()
            {
               DefaultFromAddress = "test@test.nl",
               DefaultFromName = "test"
            });
            var postbode = new PostbodeClient(options);
            


            Assert.Equal(postbode.Mail.From.Email, options.Value.DefaultFromAddress);

            Assert.Equal(postbode.Mail.From.Name, options.Value.DefaultFromName);
        }
    }
}
