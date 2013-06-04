/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/DeliveryMethod.cs#3 $
      $DateTime: 2007/07/19 13:38:11 $
      $Change: 4943 $
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
    /// Represents one type of delivery method.
    /// 
    /// </summary>
    // TODO, move to the correct ring in SocietyObjects.
    public class DeliveryMethod : Something
    {
        public new class Kind : Something.Kind
        {
        }
    }
}
