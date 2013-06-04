/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/Participants/Seller.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
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
