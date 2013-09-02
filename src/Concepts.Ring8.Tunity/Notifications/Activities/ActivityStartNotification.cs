using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring4;



namespace Concepts.Ring8.Tunity
{
    //A comment has been added to a Version
    public class NotificationActivityStart : Notification
    {
       
        TunityActivity _ev;

        public NotificationActivityStart(TunityActivity ev) :
            base(NotificationType.ActivityStart, null)
        {
            _ev = ev;
        }

        /// <summary>
        /// Header to give to user
        /// </summary>
        public override String Header
        {
            get { return "";}// ResourceManager.GetString("Notifications.ActivityStart.Header"); }
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public override String Message
        {
            get
            {
                return ""//String.Format(ResourceManager.GetString("Notifications.ActivityStart.Message_Ev{0}Start{1}"),
               ;// _ev.Name, _ev.BeginTime.ToShortDateString());
            }
        }

        /// <summary>
        ///  Direct link to activity (internal organizer link)
        /// </summary>
        public override String Link
        {
            get
            {
                if (_ev != null)
                {
                    return "act|" + _ev.ObjectID.ToString();
                }
                return "";
            }
        }
      


    }
}
