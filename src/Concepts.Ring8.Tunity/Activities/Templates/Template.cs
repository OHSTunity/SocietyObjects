/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// A template for ProjectEvents, since it is a normal event it can contain the same properties
    /// </summary>
    public class Template : Event
    {
       
        /// <summary>
        /// The lenght/duration of the event
        /// </summary>
        public TimeSpan DefaultDuration;

        /// <summary>
        /// If the template should be visisble in the gantt or not
        /// </summary>
        public Boolean Hidden;

        /// <summary>
        /// The numeric representation of the color to use when displaying the project in e.g. the Gantt Scheme.
        /// </summary>
        public int Color;

        /// <summary>
        /// Comments for the event
        /// </summary>
        public String Comments;     

        /// <summary>
        /// How far in advance before event ends shall a reminder be sent.
        /// </summary>
        public ulong StopReminderTime;

        /// <summary>
        /// How far in advance before event ends shall a reminder be sent.
        /// </summary>
        public ulong StartReminderTime;  


        public Template Parent;

        //Timespan offset to parent
        public TimeSpan ParentOffset;
        public Boolean NegativeParentOffset; //True if ParentOffset is a negative offset, no support id db for negative timespan

        public IEnumerable<Template> Children
        {
            get
            {
                return Db.SQL<Template>("SELECT a FROM Template a WHERE a.Parent=?", this);
            }
        }
    }
}
