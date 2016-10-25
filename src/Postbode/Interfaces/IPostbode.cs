using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postbode
{
    public interface IPostbode
    {

        IDeliveryService DeliveryService { get; set; }

        IMail Mail { get; set; }
        IPersonalisation Personalisation { get; set; }

        IPostbode Use(IDeliveryService deliveryService);

        IPostbode SetSubject(string subject);

        IPostbode SetRecipient(string email, string name = null, RecipientType type = RecipientType.To);

        IPostbode SetRecipients(IRecipient[] recipients, RecipientType type = RecipientType.To);

        IPostbode SetSender(string email);

        IPostbode SetContent(IContent content);

        Task SendAsync(IDeliveryService deliveryService = null);

    
    }
}