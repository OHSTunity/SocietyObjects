#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// A buyer contect is the contact person of a buyer in a trade event.
    /// </summary>
    public class BuyerContact : Participant
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Participant.Kind"/>
        public new class Kind : Participant.Kind { }
    }
}
