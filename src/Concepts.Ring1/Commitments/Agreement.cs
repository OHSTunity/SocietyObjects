/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #
 * Implementation approval:     pending
 * Introduced by:               Joachim Wester
 * Authors:                     Joachim Wester
 * 
 * Status: Release candidate
 */

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
#endregion

namespace Concepts.Ring1
{
    /// <summary>
    /// An agreement is when two or more somebodies agrees to something
    /// or are working on comming to an agreement of something (such as when
    /// one party offers the other an agreement).
    /// Each participant can have different commitments to the agreement. I.e.
    /// a quotation may have a binding commitment from the seller, while there
    /// is no commitment from the buyer.
    /// </summary>
    /// <seealso cref="Party.Commitment"/>
    /// <ontology>
    /// <equal>sumo:Promise</equal>
    /// <equal>wordnet17:05518505</equal>
    /// <equal>wordnet17:05325309</equal>
    /// </ontology>
    public class Agreement : Event
    {
    }
}
