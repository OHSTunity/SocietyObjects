using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;



namespace Concepts.Ring8.Tunity
{
    //A comment has been added to a Version
    public class NotificationDocument : Notification
    {
        private Document _doc;
        private Version _version;

        public NotificationDocument(Person uploader, Document doc) :
            base(NotificationType.DocumentAdded, uploader)
        {
            _doc = doc;
            _version = doc.LatestVersion;
        }

        private String VersionNr
        {
            get
            {
                if (_version != null)
                {
                    return _version.VersionNumber.ToString();
                }
                return "";
            }
        }

        private String DocumentName
        {
            get
            {
                if (_doc != null)
                {
                    return _doc.Name;
                }
                return "";
            }
        }


        private TunityActivity Activity
        {
            get
            {
                if (_doc != null)
                {
                    return _doc.GetOwner<TunityActivity>();
                }
                return null;
            }
        }

        private String ActivityName
        {
            get
            {
                if (Activity != null)
                {
                    return Activity.Name;
                }
                return "";
            }
        }

        private String PersonName
        {
            get
            {
                if (Sender != null && (Sender is Person))
                {
                    return (Sender as Person).FullName;
                }
                return "NN";
            }
        }
        /// <summary>
        /// Header to give to user
        /// </summary>
        public override String Header
        {
            get
            {
                return "";//"";// String.Format(
                    // ResourceManager.GetString("Notifications.DocumentAdded.NewDoc{0}InAct{1}"),
                     //DocumentName, ActivityName); 
            }
        }


        /// <summary>
        /// Message to give to user
        /// </summary>
        public override String Message
        {
            get
            {
                return "";//"";// String.Format(
                   // ResourceManager.GetString(
                    //"Notifications.DocumentAdded.Person{0}HasAddedDoc{1}Ver{2}ToActivity{3}"),
                    //PersonName, DocumentName, VersionNr, ActivityName);
            }
        }

        /// <summary>
        ///  Direct link to comment (internal organizer link)
        /// </summary>
        public override String Link
        {
            get
            {
                if (_doc != null)
                {
                    return "doc|" + _doc.ObjectID.ToString();
                }
                return "";
            }
        }


    }
}
