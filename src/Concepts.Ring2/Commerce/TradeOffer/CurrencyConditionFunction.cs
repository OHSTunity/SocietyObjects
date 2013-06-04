/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/CurrencyConditionFunction.cs#2 $
      $DateTime: 2007/05/30 13:49:56 $
      $Change: 4219 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyConditionFunction : TradeConditionFunction
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// (seealso cref="TradeOfferFuncion.Kind"/)
        public new class Kind : TradeConditionFunction.Kind { }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Currency CurrencyKind
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
