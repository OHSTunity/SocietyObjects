using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Interface for all notifications
    /// </summary>
    public interface INotificationSetting
    {
        /// <summary>
        /// Type of notification
        /// </summary>
        NotificationType Type { get; }
       
        /// <summary>
        /// Should a mail be sent?
        /// </summary>
        Boolean SendMail { get; }

        /// <summary>
        /// Should we send it at all?
        /// </summary>
        Boolean Rss { get; }

        /// <summary>
        /// Sender/Trigger of the message
        /// </summary>
        Person Person { get; }

    }
}

