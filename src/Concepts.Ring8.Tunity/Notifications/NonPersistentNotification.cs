using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  A Base for NonPersistent (not db objects, can only be delivered to active users) Notification  
    /// </summary>
    public abstract class NonPersistentNotification : INotification
    {
        protected Something _sender; //null = system
        protected Person _recipient; //null = system
        protected NotificationType _type;
        protected DateTime _created;

        public NonPersistentNotification(NotificationType type, Person sender, Person recipient)
        {
            _recipient = recipient;
            _created = DateTime.Now;
            _type = type;
        }

        /// <summary>
        /// Type of notification
        /// </summary>
        public NotificationType Type
        {
            get
            {
                return _type;
            }
        }
        public String TypeString
        {
            get
            {
                return Enum.GetName(typeof(NotificationType), _type).ToLower();
            }
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public virtual String Header
        {
            get { return ""; }
            set { }
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public virtual String Message
        {
            get { return ""; }
            set { }
        }

        /// <summary>
        ///  The sender of the message
        /// </summary>
        public Something Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        /// <summary>
        ///  The sender of the message
        /// </summary>
        public Person Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public virtual String Link
        {
            get { return null; }
        }
        
        /// <summary>
        /// Returns whether this notification can be replaced by another one
        /// </summary>
        public Boolean Replaceable
        {
            get { return false; }
        }

        public T GetSender<T>() where T : Something
        {
            return Sender as T;
        }

        public IEnumerable<T> GetRecipients<T>() where T : Something
        {
            yield return Recipient as T;
        }

        public Boolean HasRecipient(Something something)
        {
            if (Recipient == something)
                return true;
            else
                return false;
        }

    }
}

