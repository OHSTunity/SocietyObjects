using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;



namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  A system message sent to user
    /// </summary>
    public class NotificationMessage : Notification
    {
        private String _message;
        private String _header;

        public NotificationMessage(String message, Person sender) :
            base(NotificationType.Message, sender)
        {
            _message = message;
            _header = "";// ResourceManager.GetString("Notifications.Message.Header");
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public override String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public override String Header
        {
            get { return _header; }
            set { _header = value; }
        }
    }
}
