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
    public enum ProofRole
    {
        [DescriptionValue("ProofRole.ReadOnly")]
        ReadOnly = 1,
        [DescriptionValue("ProofRole.Reviewer")]
        Reviewer = 3,
        [DescriptionValue("ProofRole.Approver")]
        Approver = 4,
        [DescriptionValue("ProofRole.ReviewerAndApprover")]
        ReviewerAndApprover = 5,
        [DescriptionValue("ProofRole.Author")]
        Author = 6,
        [DescriptionValue("ProofRole.Moderator")]
        Moderator = 7,
    }

}