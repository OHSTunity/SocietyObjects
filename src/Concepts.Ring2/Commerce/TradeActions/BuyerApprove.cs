/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeActions/BuyerApprove.cs#1 $
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
    /// BuyerApprove is an action where a buyer (processor) has approved an object.
    /// </summary>
    public class BuyerApprove : Approve
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Approve.Kind"/>
        public new class Kind : Approve.Kind { }
        #endregion       
    }
}
