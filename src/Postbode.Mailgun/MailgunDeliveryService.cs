using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Postbode;
using Postbode.Exceptions;
using Postbode.Interfaces;
using Postbode.Utils;

namespace Postbode.Mailgun
{
    public class MailgunDeliveryService : IDeliveryService
    {


        public string Domain { get; set; }

        public string ApiKey { get; set; }


        private IHttpHandler _httpClient { get; }

        public MailgunDeliveryService(string domain = null, string apikey = null, IOptions<PostbodeMailgunOptions> options = null, IHttpHandler httpClient = null)
        {
            if (domain != null)
                Domain = domain;
            if (apikey != null)
                ApiKey = apikey;
            if (options?.Value != null)
            {
                Domain = options.Value.Domain;
                ApiKey = options.Value.ApiKey;
            }
            _httpClient = httpClient ?? new HttpHandler();
        }

        public async Task<IResponse> SendAsync(IPostbode postbode)
        {

            if (!postbode.Mail.Content.IsMime)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("api" + ":" + ApiKey)));


                var mail = postbode.Mail;

                var form = new Dictionary<string, string>();
                form["from"] = mail.From.ToString();
                form["to"] = string.Join(",", mail.To.Select(x => x.ToString()));
                form["subject"] = mail.Subject;
                form["text"] = mail.Content.Content;

                if (postbode.Mail.Headers != null)
                {
                    foreach (var keyValuePair in postbode.Mail.Headers)
                    {
                        if (!form.ContainsKey(keyValuePair.Key))
                        {
                            form.Add(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                }
                var response = await _httpClient.PostAsync("https://api.mailgun.net/v2/" + Domain + "/messages", new FormUrlEncodedContent(form));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new Response(true, response.ReasonPhrase);
                }
                return new Response(false, response.ReasonPhrase);
            }
            throw new NoMimeDeliverySetException();
        }

        public string Name => "Mailgun";
    }

    public static class MailgunDeliveryServiceExtension
    {

        public static IPostbode UseMailgun(this IPostbode postbode, string domain = null, string apikey = null)
        {
            return postbode.Use(new MailgunDeliveryService(domain, apikey));
        }
    }
}
