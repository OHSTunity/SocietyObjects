using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// The different possible right settings
    /// </summary>
    public enum QuoteStatus
    {
        [DescriptionValue("QuoteStatus.New")]
        New,
        [DescriptionValue("QuoteStatus.Locked")]
        Locked,
        [DescriptionValue("QuoteStatus.Rejected")]
        Rejected,
        [DescriptionValue("QuoteStatus.Accepted")]
        Accepted
    }

}

