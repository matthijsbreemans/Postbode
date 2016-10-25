﻿using System;
using System.Threading.Tasks;
using Postbode.Exceptions;

namespace Postbode
{
    public class Postbode : IPostbode, IDisposable
    {
        public Postbode(IDeliveryService service = null, IMail mail = null)
        {
            DeliveryService = service;
            Mail = mail;
        }

        public IDeliveryService DeliveryService { get; set; }

        public IMail Mail { get; set; }

        public IPersonalisation Personalisation { get; set; }


        public IPostbode Use(IDeliveryService deliveryService)
        {
            DeliveryService = deliveryService;
            return this;
        }

        public IPostbode SetSubject(string subject)
        {
            if (Mail == null) Mail = new Mail();

            Mail.Subject = subject;

            return this;
        }

        public IPostbode SetRecipient(string email, string name = null, RecipientType type = RecipientType.To)
        {
            if (Mail == null) Mail = new Mail();

            switch (type)
            {
                case RecipientType.To:
                    Mail.To = new IRecipient[] { new Recipient(email, name) };
                    break;
                case RecipientType.Bcc:
                    Mail.Bcc = new IRecipient[] { new Recipient(email, name) };
                    break;
                case RecipientType.Cc:
                    Mail.Cc = new IRecipient[] { new Recipient(email, name) };
                    break;
            }

            return this;
        }

        public IPostbode SetRecipients(IRecipient[] recipients, RecipientType type = RecipientType.To)
        {
            if (Mail == null) Mail = new Mail();

            switch (type)
            {
                case RecipientType.To:
                    Mail.To = recipients;
                    break;
                case RecipientType.Bcc:
                    Mail.Bcc = recipients;
                    break;
                case RecipientType.Cc:
                    Mail.Cc = recipients;
                    break;
            }
            return this;
        }

        public IPostbode SetSender(string email)
        {
            if (Mail == null) Mail = new Mail();

            Mail.From = new Recipient(email);

            return this;
        }

        public IPostbode SetContent(IContent content)
        {
            if (Mail == null) Mail = new Mail();

            Mail.Content = content;

            return this;
        }

        public async Task SendAsync(IDeliveryService deliveryService = null)
        {
            if (deliveryService != null)
            {
                await deliveryService.SendAsync(this);
            }
            else if (DeliveryService != null)
            {
                await DeliveryService.SendAsync(this);
            }
            else
            {
                throw new NoDeliveryServiceSetException();
            }

        }

        public void Dispose()
        {
            
        }
    }
}