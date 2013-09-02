using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class ExtraCustomerData : Something
    {
        public String Link;
    }

    /// <summary>
    /// A tunityevent. Used in TMC
    /// </summary>
    public class TunityEvent : Something
    {
       

        public DateTime Time;

        public Person Creator;
        public String Comments;
        public String Link;

        public VersionDataFile Document;
    }
}
