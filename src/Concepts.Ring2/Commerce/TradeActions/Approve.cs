/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeActions/Approve.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Ring1;

namespace Ring2
{
    /// <summary>
    /// Approve is an action where a processor has approved an object.
    /// </summary>
    public class Approve : TradeAction
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="TradeAction.Kind"/>
        public new class Kind : TradeAction.Kind { }
        #endregion       
    }
}
