/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/IParticipantChangedLogicHandler.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// Logic interface for performing tasks on participant changes.
    /// 
    /// E.g. could be implemented by a pricehandling class that needs
    /// to recalculate the price on an order when the customer has changed.
    /// </summary>
    public interface IParticipantChangedLogicHandler
    {
        /// <summary>
        /// Called when a participant has been changed on an Event.
        /// The participant is of type Something because it might be 
        /// a consumer (or a subclas there of).
        /// </summary>
        /// <param name="something"></param>
        void ParticipantChanged(Event theEvent, Something participant);
    }
}
