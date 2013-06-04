/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/PaymentTerms.cs#5 $
      $DateTime: 2009/05/13 03:03:57 $
      $Change: 21724 $
      $Author: freblo $
      =========================================================
*/

#region Using directives
		using System;
using Concepts.Ring1;
using Starcounter; 
	#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// Represents one the payment terms set for a transfer to be valid.
    /// </summary>
    public class PaymentTerms : Something
    {
       
        /// <summary>
        /// Number of days until due date from start date.
        /// </summary>
        public int ExpirationDays;

        /// <summary>
        /// Discount if payed before end of FastPaymentExpiration
        /// </summary>
        public Decimal FastPaymentDiscount;

        /// <summary>
        /// Number of days until fast payment discuount due date.
        /// </summary>
        public int FastPaymentExpirationDays;


    }
}
