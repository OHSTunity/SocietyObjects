using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

using System.Reflection;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Setting for one person on how a notification should be delivered
    /// </summary>
    public class NotificationSetting : Concepts.Ring1.Attribute, INotificationSetting
    {
        public NotificationSetting(NotificationType type, Person person)
        {
            Name = Enum.GetName(typeof(NotificationType), type);
            SetOwner(person);
            Reset();
        }

        public Person Person
        {
            get { return Value as Person; }
        }

        public NotificationType Type
        {
            get 
            {
                try
                {
                    NotificationType type = (NotificationType)Enum.Parse(typeof(NotificationType), Name, true);
                    return type;
                }
                catch
                {
                    return NotificationType.None;
                }
            }
        }


        
        public String DescriptionString
        {
            get
            {
                try
                {
                    return "";// ResourceManager.GetString("Notifications." +
                         //System.Enum.GetName(typeof(NotificationType), Type) + ".Description");
                }
                catch
                {
                    return "";
                }
            }
        }


        public String ClearName
        {
            get
            {
                try
                {
                    return "";// ResourceManager.GetString("Notifications." +
                         //System.Enum.GetName(typeof(NotificationType), Type));
                }
                catch
                {
                    return "";
                }
            }
        }

        // Should a mail be sent?
        private Boolean _sendMail;
        public Boolean SendMail
        {
            get { return _sendMail; }
            set { _sendMail = value; }
        }

        // Should it be delivered at all?
        private Boolean _rss;
        public Boolean Rss
        {
            get { return _rss; }
            set { _rss = value; }
        }

        /// <summary>
        /// Resets the values to default settings
        /// </summary>
        /// <param name="type"></param>
        public void Reset()
        {
            DefaultNotificationSetting setting = new DefaultNotificationSetting(false, false, false);
            try
            {
                FieldInfo fi = Type.GetType().GetField(Type.ToString());
                DefaultNotificationSetting[] attrs = fi.GetCustomAttributes(typeof(DefaultNotificationSetting), false) as DefaultNotificationSetting[];
                if (attrs.Length > 0)
                {
                    setting = attrs[0];
                }
            }
            catch{}
            Rss = setting.Rss;
            SendMail = setting.SendMail;
        }
    }
}

