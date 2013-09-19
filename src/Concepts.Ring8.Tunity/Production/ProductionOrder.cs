/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionOrder.cs#4 $
      $DateTime: 2008/12/16 10:06:38 $
      $Change: 17570 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductionOrder : Something
    {


        protected override void OnDelete()
        {
            base.OnDelete();
            foreach (ProductionOrderRow row in OrderRows)
            {
                row.Delete();
            }

        }


        public ProductionOrder()
        {
             _Created = DateTime.Now;
             _SubOrderNr = FindNextFreeOrderNr();
        }

        private int FindNextFreeOrderNr()
        {
            int suggestion = 1;
           
            SqlResult<ProductionOrder> res = Db.SQL<ProductionOrder>("SELECT p FROM Concepts.Ring8.Tunity.ProductionOrder p");
            foreach (ProductionOrder po in res)
            {
                if (po.SubOrderNr >= suggestion)
                    suggestion = po.SubOrderNr + 1;
            }
            return suggestion;
        }

        public ProductionOrderRow FindFirstOrderRow()
        {
            foreach (ProductionOrderRow por in OrderRows)
            {
                return por;
            }
            return null;
        }

       
        /// <summary>
        /// All production order rows that is belonging to this production order.
        /// </summary>
        public IEnumerable<ProductionOrderRow> OrderRows
        {
            get
            {
                return Db.SQL<ProductionOrderRow>("SELECT a FROM ProductionOrderRow a WHERE a.Order=?", this);
            }
        }



        /// <summary>
        ///  Date and time when this order was created
        /// </summary>
        private DateTime _Created;
        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        /// <summary>
        ///  OrderNumber
        /// </summary>
        private int _SubOrderNr;
        public int SubOrderNr
        {
            get { return _SubOrderNr; }
            set { _SubOrderNr = value; }
        }
        public String OrderNr
        {
            get
            {
                return (_Created.ToString("yy") + "-" + Convert.ToString(_SubOrderNr));
            }
        }


        [SynonymousTo("Description")]
        public String Comments;
        
        /// <summary>
        ///  Date and time when this order should start production
        /// </summary>
        private DateTime _ProductionStart;
        public DateTime ProductionStart
        {
            get { return _ProductionStart; }
            set { _ProductionStart = value; }
        }


        /// <summary>
        ///  User that made this order
        /// </summary>
        private Person _User;
        public Person User
        {
            get { return _User; }
            set { _User = value; }
        }

        /// <summary>
        ///  Designer for this order
        /// </summary>
        private Person _Designer;
        public Person Designer
        {
            get { return _Designer; }
            set { _Designer = value; }
        }

        /// <summary>
        ///  Reciever for this order. If not set then return the User that made the order.
        /// </summary>
        private Person _Reciever;
        public Person Reciever
        {
            get { 
                if(_Reciever == null)return _User;
                else return _Reciever;
            }
            set { _Reciever = value; }
        }

        /// <summary>
        /// Status
        /// </summary>
        private int _Status;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
       
    }

    /// <summary>
    /// Different status used on production orders and production orderrows
    /// </summary>
    public enum ProductionOrderStatus
    {
        /// <summary>
        /// Indicating that this order is new.
        /// </summary>
        New = 0,
        /// <summary>
        /// Indicating that this order is under work.
        /// </summary>
        Work = 1,
        /// <summary>
        /// Indicating that this order is finished.
        /// </summary>
        Finished = 2
    }
}
