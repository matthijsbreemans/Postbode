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
            var response = await new Postbode.Client.Postbode().SetTextContent("test").Use(new TestDeliveryService()).SendAsync();

            Assert.True(response.Succes);

            Assert.Equal("test", response.Message);
        }
    }
}
