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
    public enum ProofEmail
    {
        [DescriptionValue("ProofEmail.AllNewComments")]
        AllNewComments = 1,
        [DescriptionValue("ProofEmail.Replies")]
        Replies = 2,
        [DescriptionValue("ProofEmail.DailySummary")]
        DailySummary = 3,
        [DescriptionValue("ProofEmail.HourlySummary")]
        HourlySummary = 4,
        [DescriptionValue("ProofEmail.DecisionsOnly")]
        DecisionsOnly = 5,
        [DescriptionValue("ProofEmail.FinalDecision")]
        FinalDecisions = 6,
        [DescriptionValue("ProofEmail.Disabled")]
        Disabled = 9,
    }

}