/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/QuotationCharge.cs#2 $
      $DateTime: 2008/01/07 10:54:39 $
      $Change: 8713 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    public class QuotationCharge : CompensationProvision
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="CompensationProvision.Kind"/>
        public new class Kind : CompensationProvision.Kind { }
        #endregion

        public decimal OfferedQuantity;
        public decimal UsedQuantity;
    }
}
