using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring4
{
    /// <summary>
    /// 
    /// </summary>
    [Database]
    public class ProjectEvent : Event
    {
        
        /// <summary>
        /// The numeric representation of the color to use when displaying the project in e.g. the Gantt Scheme.
        /// </summary>
        public int Color;

        /// <summary>
        /// An ProjectID to identify project with, normally a project number or such.
        /// </summary>
        public string ProjectID;
    }

    public enum ProjectRelation
    {
        CanHave,
        MustHave,
        CannotHave
    }
}
