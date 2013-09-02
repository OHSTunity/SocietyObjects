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
    public enum TodoStatus
    {
        [DescriptionValue("TodoStatus.Active")]
        Active = 1,
        [DescriptionValue("TodoStatus.Finished")]
        Finished = 2,
        [DescriptionValue("TodoStatus.Rejected")]
        Rejected = 3,
    }

}

