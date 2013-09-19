/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Comment.cs#6 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/


using System;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;

namespace Concepts.Ring8.Tunity
{
    
    /// <summary>
    /// Handles a comment for a specific version
    /// </summary>
    public class QuoteRow : Something 
    {

        public QuoteRow()
        {
            UnitQuantity = 1;
        }

       
        public Quote Quote;
       

        private Decimal _unitPrice;
        public Decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public Decimal UnitQuantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                //Atleast 0
                //SetQuantificationQuantity(Math.Max(value, 0));
            }
        }

        public override T Clone<T>()
        {
            QuoteRow row = base.Clone<T>() as QuoteRow;
            row.UnitQuantity = UnitQuantity;
            row.UnitPrice = UnitPrice;
            row.Name = Name;
            row.Description = Description;
            row.Quote = Quote;
            return row as T;
        }

        public Decimal Sum
        {
            get
            {
                return UnitPrice * UnitQuantity;
            }
        }
        
        /// <summary>
        /// Remove the versions connected to this document.
        /// </summary>        
        protected override void OnDelete()
        {
            base.OnDelete();
        }

    }
}
