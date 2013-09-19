using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  A Basic notification
    ///  (Name == Type)
    /// </summary>
    public abstract class BaseRss : Something
    {
        private DateTime _time;
        private String _title;
        private String _content;
        private String _link;

        public BaseRss()
        {
        }

        public BaseRss(DateTime time, String title, String content, String link)
        {
            _time = time;
            _title = title;
            _content = content;
            _link = link;
        }

        /// <summary>
        ///  Time of the rss
        /// </summary>
        public virtual DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public String TimeAsString
        {
            get
            {
                return _time.ToString();
            }
        }

        /// <summary>
        ///  Title of the rss
        /// </summary>
        public virtual String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        ///  Title of the rss
        /// </summary>
        public virtual String GetContent(int verboseLevel)
        {
            return _content;
        }

        /// <summary>
        ///  Title of the rss
        /// </summary>
        public virtual String Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public virtual Boolean AvailableFor(Person person)
        {
            return true;
        }
    }
}

