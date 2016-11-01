using System;
using Postbode.Test;
using Xunit;
using Postbode;
using Postbode.Content;

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
    }
}
