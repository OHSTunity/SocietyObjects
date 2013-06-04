#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// The contact person of the seller in a trade event.
    /// </summary>
    public class SellerContact : Participant
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Participant.Kind"/>
        public new class Kind : Participant.Kind { }
    }
}
