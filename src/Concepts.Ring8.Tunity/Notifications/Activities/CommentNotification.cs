using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring8.Tunity
{
    //A comment has been added to a Version
    public class NotificationComment : Notification
    {
       
        private Comment _comment;

        public NotificationComment(Comment comment) :
            base(NotificationType.Comment, comment.CommentBy)
        {
            _comment = comment;
        }

        private Version Version
        {
            get
            {
                if (_comment != null)
                {
                    return _comment.GetTarget<Version>();
                }
                return null;
            }
        }

        private String VersionNr
        {
            get
            {
                if (Version != null)
                {
                    return Version.VersionNumber.ToString();
                }
                return "";
            }
        }

        private Document Document
        {
            get
            {
                if (Version != null)
                {
                    return Version.Owner;
                }
                return null;
            }
        }

        private String DocumentName
        {
            get
            {
                if (Document != null)
                {
                    return Document.Name;
                }
                return "";
            }
        }

        private TunityActivity Activity
        {
            get
            {
                if (Document != null)
                {
                    return Document.GetOwner<TunityActivity>();
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

        private String CommentContent
        {
            get
            {
                if (_comment != null)
                {
                    return _comment.TheComment;
                }
                return "";
            }
        }

        private String PersonName
        {
            get
            {
                if ((Sender != null) && (Sender is Person))
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
                   //ResourceManager.GetString("Notifications.Comment.NewCommentOnDoc{0}, Act{1}"),
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
                string content = "";//"";// String.Format(
                          //ResourceManager.GetString(
                          //"Notifications.Comment.Person{0}HasCommentedDoc{1}Ver{2}BelongingToActivity{3}"),
                           //  PersonName, DocumentName, VersionNr, ActivityName);
                content += ":\n";
                content += CommentContent;
                return content;
            }
        }

        /// <summary>
        ///  Direct link to comment (internal organizer link)
        /// </summary>
        public override String Link
        {
            get
            {
                if (_comment != null)
                {
                    return "com|" + DbHelper.GetObjectID(_comment);
                }
                return "";
            }
        }


    }
}
