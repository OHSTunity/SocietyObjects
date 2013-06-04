/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/Subscription.cs#2 $
      $DateTime: 2007/10/15 17:27:58 $
      $Change: 6421 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring2
{
    public class Subscription : TradeOffer
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="TradeOffer.Kind"/>
        public new class Kind : TradeOffer.Kind { }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Vendible Vendible;
    }
}
