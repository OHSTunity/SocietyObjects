/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeActions/Revision.cs#1 $
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
    /// Revision is an action where a processor has approved an already approved object.
    /// </summary>
    public class Revision : Approve
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
