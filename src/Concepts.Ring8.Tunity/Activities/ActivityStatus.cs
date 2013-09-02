using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// The different possible statuses for activities
    /// </summary>
    public enum ActivityStatus
    {
        [DescriptionValue("ActivityStatus.Active")]
        Active = 1,
        [DescriptionValue("ActivityStatus.Finished")]
        Finished = 2,
        [DescriptionValue("ActivityStatus.Rejected")]
        Rejected = 3,
    }

}

