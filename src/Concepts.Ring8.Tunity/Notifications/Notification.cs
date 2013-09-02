using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Concepts.Ring2;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  A Basic notification
    ///  (Name == Type)
    /// </summary>
    public abstract class Notification : Message, INotification
    {
        private NotificationType _type;

        public Notification(NotificationType type, Person sender)
        {
            Sender = sender;
            BeginTime = DateTime.Now;
            EndTime = BeginTime;
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

        /// <summary>
        /// Type of notification
        /// </summary>
        public String TypeString
        {
            get
            {
                return Enum.GetName(typeof(NotificationType), Type);
            }
        }
        
        /// <summary>
        /// Internal link to object
        /// </summary>
        /// <returns></returns>
        public virtual String Link
        {
            get { return ""; }
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

        public DateTime Created
        {
            get { return BeginTime; }
            set { }
        }

        /// <summary>
        /// Returns whether this notification can be replaced by another one
        /// </summary>
        public Boolean Replaceable
        {
            get { return false; }
        }


        public T GetSender<T>() where T:Something
        {
            return Sender as T;
        }

        public IEnumerable<T> GetRecipients<T>() where T : Something
        {
            foreach (MessageRecipient recipient in Recipients)
            {
                if (recipient.WhatIs is T)
                {
                    yield return recipient.WhatIs as T;
                }
            }
        }

        public Boolean HasRecipient(Something something)
        {
            foreach (Something recipient in GetRecipients<Something>())
            {
                if (recipient == something)
                    return true;
            }
            return false;
        }

       
        public void AddRecipient(Something recipient)
        {
            if (recipient != null)
            {
                NotificationRecipient nr = new NotificationRecipient(this, recipient);
            }
        }

        public Boolean HaveRecipients()
        {
            foreach (Something something in Recipients)
            {
                return true;
            }
            return false;
        }
    }
}


