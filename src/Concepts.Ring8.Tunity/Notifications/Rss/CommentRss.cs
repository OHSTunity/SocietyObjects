using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;



namespace Concepts.Ring8.Tunity
{
    /// <summary>

    /// </summary>
    public class CommentRss : BaseRss
    {
        private Person _person;
        private Comment _comment;

        public CommentRss(DateTime time, Person person, Comment comment)
        {
            Time = time;
            _comment = comment;
            _person = person;
        }

        public Person Sender
        {
            get
            {
                return _person;
            }
        }

        public Comment comment
        {
            get
            {
                return _comment;
            }
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


        public TunityActivity Activity
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
                if (_person != null)
                {
                    return _person.FullName;
                }
                return "NN";
            }
        }
       
        /// <summary>
        ///  Title of the rss
        /// </summary>
        public override String Title
        {
            get 
            {
                return "";//"";// String.Format(
                     //ResourceManager.GetString("Rss.Comment.NewCommentOnDoc{0}, Act{1}"),
                     //DocumentName, ActivityName); 
            }
        }

        /// <summary>
        ///  Content of the rss
        /// </summary>
        public override String GetContent(int verboseLevel)
        {
            string content = "";//"";// String.Format(
                   // ResourceManager.GetString(
                    //"Rss.Comment.Person{0}HasCommentedDoc{1}Ver{2}BelongingToActivity{3}"),
                      // PersonName, DocumentName, VersionNr, ActivityName);
            if (verboseLevel > 0)
            {
                content += ":\n";
                content += CommentContent;
            }
            return content;
        }

        public override Boolean AvailableFor(Person person)
        {
            if (person == null)
                return false;

            TunityActivity activity = Activity;
            if (activity != null)
            {
                return (person.RelationTo<Participant>(activity) != null);
            }
            else
                return false;
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

