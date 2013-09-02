/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionOrderRow.cs#2 $
      $DateTime: 2008/12/09 13:00:04 $
      $Change: 17308 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductionOrderRow : Something
    {
     
        protected override void OnDelete()
        {
            base.OnDelete();
            foreach (ProductionOrderReview row in Reviews)
            {
                row.Delete();
            }
            foreach (ProductionOrderRowDetail row in OrderRowDetails)
            {
                row.Delete();
            }





        }

        public ProductionOrderRow()
        {
            _Status = ProductionOrderStatus.New;
        }

        //From something, Name, Description and Quantity is used)
        private ProductionOrderStatus _Status;


        /// <summary>
        /// The production that is ordered
        /// </summary>
        private Production _Production;
        public Production Production
        {
            get
            {
                return _Production;
            }
            set
            {
                _Production = value;
            }
        }
        
        /// <summary>
        /// The production that owns this order row.
        /// </summary>
        public ProductionOrder Order;

        public ProductionOrder SqlOrder
        {
            get
            {
                return Order;
            }
            set
            {
                Order = value;
            }
        }


        /// <summary>
        /// All production order proofs that belongs to this order row.
        /// </summary>
        public IEnumerable<ProductionOrderReview> Reviews
        {
            get
            {
                return Db.SQL<ProductionOrderReview>("SELECT a FROM ProductionOrderReview a WHERE a.OrderRow=?", this);
            }
        }


        public IEnumerable<ProductionOrderRowDetail> OrderRowDetails
        {
            get
            {
                return Db.SQL<ProductionOrderRowDetail>("SELECT a FROM ProductionOrderRowDetail a WHERE a.OrderRow=?", this);
            }
        }

        public ProductionOrderStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


    }
}
