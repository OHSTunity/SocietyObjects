/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Participant/Seller.cs#1 $
      $DateTime: 2007/05/17 10:45:19 $
      $Change: 3859 $
      $Author: freblo $
      =========================================================
*/

#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// </summary>
    public class Seller : Participant
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Participant.Kind"/>
        public new class Kind : Participant.Kind { }

        /// <summary>
        /// Notes that the seller has regarding the Event he is participating in.
        /// </summary>
        public string Notes;
    }
}
