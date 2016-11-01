using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Postbode;
using Postbode.Exceptions;
using Postbode.Interfaces;

namespace Postbode.Sendgrid
{
    public class SendgridDeliveryService : IDeliveryService
    {
        public string ApiKey { get; set; }

        public SendgridDeliveryService(string apikey = null, IOptions<PostbodeSendgridOptions> options = null)
        {
            if (apikey != null)
                ApiKey = apikey;
        }

        public SendgridDeliveryService()
        {
        }

        public async Task<IResponse> SendAsync(IPostbode postbode)
        {
            if (!postbode.Mail.Content.IsMime)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.sendgrid.com");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

                    //nasty way to prevent external json lib dependecy
                    var data = "{\"personalizations\": " + generatePersJson(postbode) + "," +
                               " \"from\": {\"email\": \"" + postbode.Mail.From + "\"}," +
                               " \"content\": [{\"type\": \"" + postbode.Mail.Content.Type + "\", \"value\": \"" + postbode.Mail.Content.Content + "\"}]" +
                               "}";


                    var result = await client.PostAsync("v3/mail/send", new StringContent(data, Encoding.UTF8, "application/json"));

                    string resultContent = await result.Content.ReadAsStringAsync();

                    return new Response(result.IsSuccessStatusCode, resultContent);

                }
            }
            throw new NoMimeDeliverySetException();
        }

        private string generatePersJson(IPostbode postbode)
        {

            return "[{\"to\": [" + string.Join(",", postbode.Mail.To.Select(x => "{\"email\": \"" + x.Email + "\"}")) + "],\"subject\": \"" + postbode.Mail.Subject + "\"}]";
        }

        public string Name => "Sendgrid";

        private class SendgridMail
        {

        }
    }

    public static class SendgridDeliveryServiceExtension
    {

        public static IPostbode UseSendgrid(this IPostbode postbode, string apikey = null)
        {
            postbode.Use(new SendgridDeliveryService(apikey));
            return postbode;
        }
    }
}
