using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Interface for all notifications
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Type of notification
        /// </summary>
        NotificationType Type { get; }

        /// <summary>
        /// Message for notification
        /// </summary>
        String TypeString { get; }

        /// <summary>
        /// Header for notification
        /// </summary>
        String Header { get; }

        /// <summary>
        /// Message for notification
        /// </summary>
        String Message { get; }

        /// <summary>
        /// Sender/Trigger of the message
        /// </summary>
        T GetSender<T>() where T : Something;

        /// <summary>
        /// Recipient of the message
        /// 
        /// </summary>
        IEnumerable<T> GetRecipients<T>() where T : Something;

        Boolean HasRecipient(Something something);

        /// <summary>
        /// Link (internal) to the notification
        /// </summary>
        /// <returns></returns>
        String Link { get; }

        /// <summary>
        /// Time when this was created
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// Returns whether this notification can be replaced by another one
        /// of the same type with same reciever
        /// </summary>
        Boolean Replaceable { get; }
    }
}

