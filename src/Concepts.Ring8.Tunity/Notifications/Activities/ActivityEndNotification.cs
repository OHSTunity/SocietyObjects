using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring4;
using Starcounter;


namespace Concepts.Ring8.Tunity
{
    //A comment has been added to a Version
    public class NotificationActivityEnd : Notification
    {
        
        TunityActivity _ev;

        public NotificationActivityEnd(TunityActivity ev) :
            base(NotificationType.ActivityEnd, null)
        {
            _ev = ev;
        }

        /// <summary>
        /// Header to give to user
        /// </summary>
        public override String Header
        {
            get { return "";} //ResourceManager.GetString("Notifications.ActivityEnd.Header"); }
        }

        /// <summary>
        /// Message to give to user
        /// </summary>
        public override String Message
        {
            get
            {
                return "";//String.Format(ResourceManager.GetString("Notifications.ActivityEnd.Message_Ev{0}Stop{1}"),
                //_ev.Name, _ev.EndTime.ToShortDateString());
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
                    return "act|" + DbHelper.GetObjectID(_ev);;
                }
                return "";
            }
        }


    }
}
