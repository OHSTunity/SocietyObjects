/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/TradeConditionExistsVendible.cs#1 $
      $DateTime: 2007/10/15 17:33:29 $
      $Change: 6422 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// Offer function for unique Goods or Services.
    /// </summary>
    public class TradeConditionExistsVendible : Concepts.Ring2.VendibleConditionFunction
    {
        #region Kind
        public new class Kind : VendibleConditionFunction.Kind { }
        #endregion


        /// <summary>
        /// This specific piece of goods must exist in the sale for the condition to be met.
        /// </summary>
        public Vendible VendibleMustExist;
    }
}
