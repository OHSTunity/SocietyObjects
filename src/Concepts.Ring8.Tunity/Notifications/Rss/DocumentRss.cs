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
    public class DocumentRss : BaseRss
    {
        private Person _person;
        private Document _doc;
        private Version _version;

        public DocumentRss(DateTime time, Person person, Document doc)
        {
            Time = time;
            _doc = doc;
            _version = doc.LatestVersion;
            _person = person;
        }

        public Person Sender
        {
            get
            {
                return _person;
            }
        }

        public Document Doc
        {
            get
            {
                return _doc;
            }
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


        public TunityActivity Activity
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
                return ""; //String.Format(
                    //ResourceManager.GetString("Rss.Document.NewDoc{0}InAct{1}"),
                    //DocumentName, ActivityName); 
            }
        }

        /// <summary>
        ///  Content of the rss
        /// </summary>
        public override String GetContent(int verboseLevel)
        {
            return "";//"";// String.Format(
                //ResourceManager.GetString(
                //"Rss.Document.Person{0}HasAddedDoc{1}Ver{2}ToActivity{3}"),
                //PersonName, DocumentName, VersionNr, ActivityName);
        }

        /// <summary>
        ///  Direct link to document (internal organizer link)
        /// </summary>
        public override String Link
        {
            get 
            {
                if (_doc != null)
                {
                    return "doc|"+DbHelper.GetObjectID(_doc);
                }
                return "";
            }
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


    }
}

