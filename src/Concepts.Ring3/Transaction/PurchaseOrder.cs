/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/PurchaseOrder.cs#16 $
      $DateTime: 2010/10/12 12:04:59 $
      $Change: 37069 $
      $Author: freblo $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;
using System.Text;

namespace Concepts.Ring3
{
    /// <summary>
    /// This is an agreement for two parties to exchange vendibles. 
    /// We refer to the parties as the buyer and the seller.
    /// 
    /// The trade consists of two VendibleTransfers:
    /// * The SellerTransfer
    /// * The BuyerTransfer
    /// 
    /// The seller transfer is what the seller wants in exchange for the buyertransfer.
    /// </summary>
    public class PurchaseOrder : TradeTransaction
    {
        public new class Kind : TradeTransaction.Kind
        {
               
        }

        protected sealed override void OnNew()
        {
            base.OnNew();
            OnNewTrade();
        }

        protected virtual void OnNewTrade()
        {
        }

        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems
        {
            get
            {
                return Items<PurchaseOrderItem>();
            }
        }



        #region Dates


        /// <summary>
        /// Tells when the trade was approved by the buyer.
        /// </summary>
        public DateTime BuyerApprovedTime;
        
        /// <summary>
        /// Tells when the trade was approved by the seller.
        /// </summary>        
        public DateTime SellerApprovedTime;

        /// <summary>
        /// Tells when the trade was completed (no more actions can be done).
        /// </summary>
        [SynonymousTo("EndTime")]
        public DateTime CompletedAtTime;

        #endregion
        

        #region Common properties used both by the buyer and seller side

        private Consumer _consumer;
        /// <summary>
        /// The consumer object that represents the buyer and the seller of this trade.
        /// </summary>
        [SynonymousTo("_consumer")]
        public readonly Consumer Consumer;

        /// <summary>
        /// Sets the Consumer as well as creates the Buyer- and Seller-relation.
        /// </summary>
        /// <param name="consumerRelation"></param>
        public void SetConsumerRelation(Consumer consumerRelation, bool createRelations)
        {
            _consumer = consumerRelation;
            if (createRelations)
            {
                if (consumerRelation != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Buyer.Kind>(), consumerRelation.WhoIs);
                    AssureExclusiveParticipant(Kind.GetInstance<Seller.Kind>(), consumerRelation.ToWhom);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Buyer.Kind>());
                    RemoveAllParticipants(Kind.GetInstance<Seller.Kind>());
                }
            }
        }

        #endregion

        #region Buyer

        public Somebody Buyer
        {
            get
            {
                return Consumer.WhoIs;
            }
        }


        /// <summary>
        /// The person making the trade, shall only be set if this differs from the buyer.
        /// </summary>
        public virtual Somebody Orderer
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Orderer>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Orderer.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Orderer.Kind>());
                }
            }
        }

        /// <summary>
        /// The reciever of the invoice, shall only be set if this differs from the buyer.
        /// </summary>
        public Somebody Invoicee
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Invoicee>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Invoicee.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Invoicee.Kind>());
                }
            }
        }

        /// <summary>
        /// The reciever of the gods, shall only be set if this differs from the buyer.
        /// </summary>
        public Somebody Consignee
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Consignee>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Consignee.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Consignee.Kind>());
                }
            }
        }
        
        /// <summary>
        /// The contact person for the buyer side, shall only be set if this differs from the buyer.
        /// </summary>
        public Somebody BuyerContact
        {
            get { return this.ImplicitlyRelatedObject<Somebody, BuyerContact>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<BuyerContact.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<BuyerContact.Kind>());
                }
            }
        }

        protected bool _isBuyerApproved;

        /// <summary>
        /// Tells if this Trade has been approved.
        /// </summary>
        [SynonymousTo("_isBuyerApproved")]
        public readonly bool IsBuyerApproved;

        #endregion

        #region Seller

        public Somebody Seller
        {
            get
            {
                return Consumer.ToWhom;
            }
        }


        /// <summary>
        /// The somebody that the orderer confirmed the trade with, shall only be set if this differs from the seller.
        /// </summary>
        public virtual Somebody Orderee
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Orderee>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Orderee.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Orderee.Kind>());
                }
            }
        }
        
        /// <summary>
        /// The somebody that shall recieve the payment, shall only be set if this differs from the seller.
        /// </summary>
        public Somebody Invoicer
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Invoicer>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Invoicer.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Invoicer.Kind>());
                }
            }
        }
        
        /// <summary>
        /// The somebody that provides the goods, shall only be set if this differs from the seller.
        /// </summary>
        public Somebody Deliverer
        {
            get { return this.ImplicitlyRelatedObject<Somebody, Deliverer>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Deliverer.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Deliverer.Kind>());
                }
            }
        }
        
        /// <summary>
        /// The contact person for the seller side, shall only be set if this differs from the seller.
        /// </summary>
        public Somebody SellerContact
        {
            get { return this.ImplicitlyRelatedObject<Somebody, SellerContact>(); }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<SellerContact.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<SellerContact.Kind>());
                }
            }
        }
        
        protected bool _isSellerApproved;

        /// <summary>
        /// Tells if this Trade has been approved.
        /// </summary>
        public bool IsSellerApproved
        {
            get { return _isSellerApproved; }
        }

        public bool IsApproved
        {
            get
            {
                return _isSellerApproved && _isBuyerApproved;
            }
        }

        #endregion
        

        /// <summary>
        /// Intended to create an item instance for this trade. The item will
        /// be connected to this trade via the CreateItem-method.
        /// </summary>
        /// <returns></returns>
        protected virtual T NewItemInstance<T>() where T : PurchaseOrderItem
        {
            throw new NotImplementedException("You must implement NewItemInstance!");
        }

        private bool _isCompleted;
        /// <summary>
        /// Tells if this Trade has been completed, no more actions can be performed on the trade if completed.
        /// </summary>
        
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
        }
        
        /// <summary>
        /// Completes this Trade, i.e. no more tasks can be performed on the task. Items in AccountingDepots are removed.
        /// </summary>
        public void Complete()
        {
            lock (this)
            {
                if (!_isCompleted)
                {
                    _isCompleted = true;
                    CompletedAtTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Opens a trade for audit.
        /// </summary>
        public void Open()
        {
            _isBuyerApproved = false;
            _isSellerApproved = false;
            OnOpen();
        }

        /// <summary>
        /// Gives inheriting classes a chance to do their stuff on open.
        /// </summary>
        protected virtual void OnOpen()
        {
        }

        /// <summary>
        /// Approves the buyers side of the trade, if the seller side is already approved 
        /// the approve-logic is executed.
        /// 
        /// ATTENTION! The TradeItems themselves are not approved this has to be done per item.
        /// </summary>
        /// <summary>
        /// Approves the buyers side of the trade, if the seller side is already approved 
        /// the approve-logic is executed.
        /// 
        /// ATTENTION! The TradeItems themselves are not approved this has to be done per item.
        /// </summary>
        public void BuyerApprove()
        {
            lock (this)
            {
                if (!IsBuyerApproved)
                {
                    _isBuyerApproved = true;
                    BuyerApprovedTime = DateTime.Now;

                    if (IsSellerApproved)
                    {
                        Approve();
                    }

                    // Commit the changes
                    Transaction.Current.Commit();
                }
            }
        }

        /// <summary>
        /// Approves the sellers side of the trade, if the seller side is already approved 
        /// the approve-logic is executed.
        /// </summary>
        public void SellerApprove()
        {
            lock (this)
            {
                if (!IsSellerApproved)
                {
                    _isSellerApproved = true;
                    SellerApprovedTime = DateTime.Now;

                    if (IsBuyerApproved)
                    {
                        Approve();
                    }

                    // Commit the changes
                    Transaction.Current.Commit();
                }
            }
        }
        
        /// <summary>
        /// Approves the transfer. Can is called when both seller and buyer has approved.
        /// </summary>
        protected virtual void Approve()
        {
            throw new NotImplementedException("You need to implement approve!");
        }

        public virtual string ToTradeDebugXML()
        {
            return ToTradeDebugXML(0);
        }


        public virtual string ToTradeDebugXML(int indent)
        {
            string rootIndent = (indent > 0) ? " ".PadRight(indent) : string.Empty;
            string indentStr = " ".PadRight(indent + 1);
            StringBuilder sb = new StringBuilder();

            if (indent == 0)
            {
                sb.AppendLine("<?xml version=\"1.0\"?>");
            }

            Consumer c = Consumer;

            Somebody buyerContact = BuyerContact;
            Somebody consignee = Consignee;
            //DeliveryMethod deliveryMethod = DefaultDeliveryMethod;
            //PaymentTerm paymentTerm = DefaultPaymentTerm;
            Somebody deliverer = Deliverer;
            Somebody invoicee = Invoicee;
            Somebody invoicer = Invoicer;
            Somebody orderee = Orderee;
            Somebody orderer = Orderer;
            Somebody sellerContact = SellerContact;
            //TradeSubState subState = SubState;

            sb.Append(rootIndent).Append("<Trade Type=\"").Append(ToReadableString()).AppendLine("\">");

            if (c != null)
            {
                Somebody buyer = c.WhoIs;
                Somebody seller = c.ToWhom;
                sb.Append(indentStr).Append("<Consumer ID=\"").Append(c.ConsumerID).Append("\">").Append(c.ToReadableString()).AppendLine("</Consumer>");
                sb.Append(indentStr).Append("<Buyer>").Append(buyer.ToReadableString()).AppendLine("</Buyer>");
                sb.Append(indentStr).Append("<Seller>").Append(seller.ToReadableString()).AppendLine("</Seller>");
            }

            sb.Append(indentStr).Append("<CompletedAtTime>").Append(CompletedAtTime.ToString()).AppendLine("</CompletedAtTime>");

            //if (deliveryMethod != null)
            //{
            //    sb.Append(indentStr).Append("<DefaultDeliveryMethod>").Append(deliveryMethod.ToReadableString()).AppendLine("</DefaultDeliveryMethod>");
            //}
            //if (paymentTerm != null)
            //{
            //    sb.Append(indentStr).Append("<DefaultPaymentTerm>").Append(paymentTerm.ToReadableString()).AppendLine("</DefaultPaymentTerm>"); //
            //}
            //sb.Append(indentStr).Append("<DeliveryPeriod>").Append(DeliveryPeriod).AppendLine("</DeliveryPeriod>");

            //if (subState != null)
            //{
            //    sb.Append(indentStr).Append(indentStr).Append("<SubState>").Append(subState.ToReadableString()).AppendLine("</SubState>"); //
            //}

            #region Buyers properties
            sb.Append(indentStr).Append("<BuyerApprovedTime>").Append(BuyerApprovedTime.ToString()).AppendLine("</BuyerApprovedTime>");
            
            if (buyerContact != null)
            {
                sb.Append(indentStr).Append(indentStr).Append("<BuyerContact>").Append(buyerContact.ToReadableString()).AppendLine("</BuyerContact>");
            }
            //sb.Append(indentStr).Append("<BuyerTradeID>").Append(BuyerTradeID.ToString()).AppendLine("</BuyerTradeID>");
            
            if (consignee != null)
            {
                sb.Append(indentStr).Append(indentStr).Append("<Consignee>").Append(consignee.ToReadableString()).AppendLine("</Consignee>"); //
            }
            if (invoicee != null)
            {
                sb.Append(indentStr).Append(indentStr).Append("<Invoicee>").Append(invoicee.ToReadableString()).AppendLine("</Invoicee>"); //  
            }
            if (orderer != null)
            {
                sb.Append(indentStr).Append(indentStr).Append("<Orderer>").Append(orderer.ToReadableString()).AppendLine("</Orderer>"); //
            }
            #endregion

            #region Sellers properties
            sb.Append(indentStr).Append("<SellerApprovedTime>").Append(SellerApprovedTime.ToString()).AppendLine("</SellerApprovedTime>");

            if (sellerContact != null)
            {
                sb.Append(indentStr).Append(indentStr).Append("<SellerContact>").Append(sellerContact.ToReadableString()).AppendLine("</SellerContact>"); //
            }
            //sb.Append(indentStr).Append("<SellerTradeID>").Append(SellerTradeID.ToString()).AppendLine("</SellerTradeID>");

            if (deliverer != null)
            {
                sb.Append(indentStr).Append("<Deliverer>").Append(deliverer.ToReadableString()).AppendLine("</Deliverer>"); //
            }
            if (invoicer != null)
            {
                sb.Append(indentStr).Append("<Invoicer>").Append(invoicer.ToReadableString()).AppendLine("</Invoicer>"); //
            }
            if (orderee != null)
            {
                sb.Append(indentStr).Append("<Orderee>").Append(orderee.ToString()).AppendLine("</Orderee>"); //
            }
            #endregion

            sb.Append(indentStr).AppendLine();
            sb.Append(indentStr).AppendLine("<Items>");

            foreach(PurchaseOrderItem item in PurchaseOrderItems)
            {
                sb.AppendLine(item.ToTradeDebugXML(indent + 1));
            }

            sb.Append(indentStr).AppendLine("</Items>");
            sb.Append(rootIndent).AppendLine("</Trade>");

            return sb.ToString();
        }
    }
}
