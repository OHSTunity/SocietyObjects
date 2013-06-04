/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeActions/Cancel.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Ring2
{
    /// <summary>
    /// Cancel is an action where a processor has cancelled an object.
    /// </summary>
    public class Cancel : TradeAction
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
