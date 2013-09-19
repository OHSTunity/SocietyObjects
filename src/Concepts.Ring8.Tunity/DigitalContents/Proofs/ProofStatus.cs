using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// The different possible statuses for activities
    /// </summary>
    public enum ProofStatus
    {
        [DescriptionValue("ProofStatus.Started")]
        Started = 0,
        [DescriptionValue("ProofStatus.Commented")]
        Commented = 1,
        [DescriptionValue("ProofStatus.Accepted")]
        Finished = 2,
        [DescriptionValue("ProofStatus.Rejected")]
        Rejected = 3,
    }

}