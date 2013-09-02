/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Attributes/ReminderTime.cs#3 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring8.Tunity
{

    /// <summary>
    /// Simple attribute class for storing String Values
    /// </summary>
    public class DefaultNotificationSetting : System.Attribute, INotificationSetting
    {
        /// <summary>
        /// Creates a new <see cref="StringValueAttribute"/> instance.
        /// </summary>
        /// <param name="value">Value.</param>
        public DefaultNotificationSetting(Boolean rss, Boolean mail, Boolean visible)
        {
            _rss = rss;
            _sendMail = mail;
            _visible = visible;
        }

        private Boolean _rss = false;
        public Boolean Rss
        {
            get { return _rss; }
            set { _rss = value; }
        }

        private Boolean _visible = false;
        public Boolean Visisble
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private Boolean _sendMail = false;
        public Boolean SendMail
        {
            get { return _sendMail; }
            set { _sendMail = value; }
        }
      
        public Person Person
        {
            get { return null; }
        }

        private NotificationType _type = NotificationType.None;
        public NotificationType Type
        {
            get { return _type; }
            set { _type = value; }
        }


    }
}
