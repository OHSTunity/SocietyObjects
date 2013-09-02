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
    public class SystemMessageNotification : NonPersistentNotification
    {
        private String _message;
        private String _header;

        public SystemMessageNotification(String message, Person sender, Person recipient) :
            base(NotificationType.SystemMessage, sender, recipient)
        {
            _message = message;
            _header = "";//ResourceManager.GetString("Notifications.SystemMessage.Header");
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
