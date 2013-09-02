using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Concepts.Ring2;


namespace Concepts.Ring8.Tunity
{
    public class NotificationRecipient : MessageRecipient
    {
        public NotificationRecipient(Notification notification, Something recipient)
        {
            SetParticipant(recipient);
            SetToWhat(notification);
            Rd_SendTime = notification.BeginTime;
        }

       
        /// <summary>
        /// SendTime for the notification. This is renduntant with the notifications 
        /// BeginTime. It's here for faster access in searches.
        /// </summary>
        public DateTime Rd_SendTime;
    }
}

