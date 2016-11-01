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
using Postbode.Utils;

namespace Postbode.Sendgrid
{
    public class SendgridDeliveryService : IDeliveryService
    {
        public string ApiKey { get; set; }


        private IHttpHandler _httpClient { get; }


        public SendgridDeliveryService(string apikey = null, IOptions<PostbodeSendgridOptions> options = null, IHttpHandler httpClient = null)
        {
            if (apikey != null)
                ApiKey = apikey;

            _httpClient = httpClient ?? new HttpHandler();
        }

        public SendgridDeliveryService()
        {
        }

        public async Task<IResponse> SendAsync(IPostbode postbode)
        {
            if (!postbode.Mail.Content.IsMime)
            {

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

                //nasty way to prevent external json lib dependecy
                var data = "{\"personalizations\": " + generatePersJson(postbode) + "," +
                           " \"from\": {\"email\": \"" + postbode.Mail.From + "\"}," +
                           " \"content\": [{\"type\": \"" + postbode.Mail.Content.Type + "\", \"value\": \"" + postbode.Mail.Content.Content + "\"}]" +
                           "}";


                var result = await _httpClient.PostAsync("https://api.sendgrid.com/v3/mail/send", new StringContent(data, Encoding.UTF8, "application/json"));

                var resultContent = await result.Content.ReadAsStringAsync();

                return new Response(result.IsSuccessStatusCode, resultContent);

            }
            throw new NoMimeDeliverySetException();
        }

        private string generatePersJson(IPostbode postbode)
        {

            return "[{\"to\": [" + string.Join(",", postbode.Mail.To.Select(x => "{\"email\": \"" + x.Email + "\"}")) + "],\"subject\": \"" + postbode.Mail.Subject + "\"}]";
        }

        public string Name => "Sendgrid";

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
