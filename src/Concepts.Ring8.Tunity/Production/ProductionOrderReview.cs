/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionOrderReview.cs#3 $
      $DateTime: 2008/12/16 10:06:38 $
      $Change: 17570 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;
using Concepts.Ring8.Tunity;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductionOrderReview : Something
    {
        public ProductionOrderReview()
        {
             _Created = DateTime.Now;
        }

       
        //From something, Name, Description and Quantity is used)
        
        /// <summary>
        /// The order row that owns this review.
        /// </summary>
        public ProductionOrderRow OrderRow;

        /// <summary>
        /// DateTime created.
        /// </summary>
        private DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }
        
        /// <summary>
        /// Message from creator.
        /// </summary>
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        /// <summary>
        /// Document from .
        /// </summary>
        private Document _File;
        public Document File
        {
            get { return _File; }
            set { _File = value; }
        }
        
        /// <summary>
        /// Type/result of review
        /// </summary>
        private ReviewType _Type;
        public ReviewType Type
        {
            get { return _Type; }
            set { _Type = value; }
        } 
        
        
    }

    public enum ReviewType
    {
        /// <summary>
        /// Indicating that this is just a notice
        /// </summary>
        Notice = 0,
        /// <summary>
        /// Indicating that this is ok.
        /// </summary>
        Yes = 1,
        /// <summary>
        /// Indicating that this is not ok.
        /// </summary>
        No = 2,
        /// <summary>
        /// Indicates that this should be corrected.
        /// </summary>
        Review = 3
    }

}
