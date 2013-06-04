/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/PurchaseOrderItem.cs#8 $
      $DateTime: 2010/03/16 12:36:19 $
      $Change: 30495 $
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
    /// A trade item consists of two TradeConfigurations:
    ///  * BuyConfiguration - What the buyer wants, e.g. 1st Coca-Cola.
    ///  * SellConfiguration - What the the seller wants, e.g. 10 SEK in exchange for the Coca-Cola.
    /// </summary>
    public class PurchaseOrderItem : TradeTransactionItem
    {
        public new class Kind : TradeTransactionItem.Kind
        {
            
        }



        /// <summary>
        /// The trade that this item belongs to.
        /// </summary>
        [SynonymousTo("Transaction")]
        public readonly PurchaseOrder Trade;
        public void SetTrade(PurchaseOrder trade)
        {
            SetTransaction(trade);
        }



        public bool IsApprovedSeller;
        public bool IsApprovedBuyer;

        public bool IsApproved
        {
            get
            {
                return IsApprovedSeller && IsApprovedBuyer;
            }
            set
            {
                IsApprovedSeller = value;
                IsApprovedBuyer = value;
            }
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

            Something.Kind tradedKind = TransferedKindSeller;
            //Something tradedObject = TradedObject;
            //DeliveryMethod dm = DeliveryMethod;


            sb.Append(rootIndent).Append("<TradeItem Type=\"").Append(ToReadableString()).AppendLine("\">");
            sb.Append(indentStr).Append("<Trade>").Append(Trade.ToReadableString()).AppendLine("</Trade>");

            if (tradedKind != null)
            {
                sb.Append(indentStr).Append("<TradedKind>").Append(tradedKind.ToReadableString()).AppendLine("</TradedKind>");
            }
            //if (tradedObject != null)
            //{
            //    sb.Append(indentStr).Append("<TradedObject>").Append(tradedObject.ToReadableString()).AppendLine("</TradedObject>");
            //}
            //if (dm != null)
            //{
            //    sb.Append(indentStr).Append("<DeliveryMethod>").Append(dm.ToReadableString()).AppendLine("</DeliveryMethod>");
            //}
            //sb.Append(indentStr).Append("<DeliveryPeriod>").Append(DeliveryPeriod).AppendLine("</DeliveryPeriod>");



            sb.Append(rootIndent).AppendLine("</TradeItem>");

            return sb.ToString();
        }


    }
}
