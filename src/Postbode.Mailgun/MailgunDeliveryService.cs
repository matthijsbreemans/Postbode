using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Postbode.Client;
using Postbode.Exceptions;
using Postbode.Interfaces;

namespace Postbode.Mailgun
{
    public class MailgunDeliveryService : IDeliveryService
    {
        public string Domain { get; set; }

        public string Apikey { get; set; }

        public MailgunDeliveryService()
        {
            
        }

        //public MailgunDeliveryService(string domain = null, string apikey = null)
        //{
        //    if (domain != null)
        //        Domain = domain;
        //    if (apikey != null)
        //        Apikey = apikey;

        //}

        public async Task<IResponse> SendAsync(IPostbode postbode)
        {

            if (postbode.Mail.Content.IsMime)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("api" + ":" + Apikey)));


                var mail = postbode.Mail;

                var form = new Dictionary<string, string>();
                form["from"] = mail.From.ToString();
                form["to"] = string.Join(",", mail.To.Select(x => x.ToString()));
                form["subject"] = mail.Subject;
                form["text"] = mail.Content.Content;

                foreach (var keyValuePair in postbode.Mail.Headers)
                {
                    if (!form.ContainsKey(keyValuePair.Key))
                    {
                        form.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                }

                var response = await client.PostAsync("https://api.mailgun.net/v2/" + Domain + "/messages", new FormUrlEncodedContent(form));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new Response(true, response.ReasonPhrase);
                }
                return new Response(false, response.ReasonPhrase);
            }
            throw new NoMimeDeliverySetException();
        }

        public string Name => "Mailgun";
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public static class MailgunDeliveryServiceExtension
    {

        public static IPostbode UseMailgun(this IPostbode postbode, string domain = null, string apikey = null)
        {
            postbode.Use(new MailgunDeliveryService());
            return postbode;
        }
    }
}
