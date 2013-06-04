/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/TradeConfiguration.cs#3 $
      $DateTime: 2008/03/27 13:06:50 $
      $Change: 10885 $
      $Author: hentil $
      =========================================================
*/


using Concepts.Ring1;
using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  TradeConfiguration
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: TradeConfiguration
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: TradeConfiguration
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: TradeConfiguration
    /// This is an example of how to use this class.
    /// </example>
    public class TradeConfiguration : Something
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Something.Kind
        {

        }

        #endregion

        /// <summary>
        /// The multiplier for the BuyersConfiguration.
        /// If the Buyer want 7 st Coca-Cola the multiplier would probably be 7 and the configuration
        /// would consist of 1 piece of Coca-Cola.
        /// </summary>
        public decimal BuyersMultiplier;

        /// <summary>
        /// The BuyConfiguration, i.e. What the buyer is trading for the goods that the seller wants.
        /// Usually money.
        /// </summary>
        public TradesideConfiguration BuyersConfiguration;

        /// <summary>
        /// Multiplies the SellersConfiguration.
        /// E.g. the sell configuration consists of 1 Piece of SEK and the multiplier is 10, this
        /// means that the seller is exchanging 10SEK for the BuyConfiguration.
        /// </summary>
        public decimal SellersMultiplier;
        /// <summary>
        /// The SellConfiguration, i.e. What the seller is trading for the goods that the buyer wants.
        /// Usually goods.
        /// </summary>        
        public TradesideConfiguration SellersConfiguration;

        public virtual string ToTradeDebugXML()
        {
            return ToTradeDebugXML(0);
        }

        public virtual string ToTradeDebugXML(int indent)
        {
            string rootIndent = (indent > 0) ? " ".PadRight(indent) : string.Empty;
            string indentStr = " ".PadRight(indent + 1);

            TradesideConfiguration buyersTC = BuyersConfiguration;
            TradesideConfiguration sellersTC = SellersConfiguration;

            StringBuilder sb = new StringBuilder();

            if (indent == 0)
            {
                sb.AppendLine("<?xml version=\"1.0\"?>");
            }

            sb.Append(rootIndent).Append("<TradeConfiguration Type=\"").Append(ToReadableString()).AppendLine("\">");

            if (buyersTC != null)
            {
                sb.Append(indentStr).Append("<BuyersMultiplier>").Append(BuyersMultiplier.ToString()).AppendLine("</BuyersMultiplier>");
                sb.Append(indentStr).AppendLine("<BuyersConfiguration>");
                sb.AppendLine(buyersTC.ToTradeDebugXML(indent + 1));
                sb.Append(indentStr).AppendLine("</BuyersConfiguration>");
            }

            if (sellersTC != null)
            {
                sb.Append(indentStr).Append("<SellersMultiplier>").Append(SellersMultiplier.ToString()).AppendLine("</SellersMultiplier>");
                sb.Append(indentStr).AppendLine("<SellersConfiguration>");
                sb.AppendLine(sellersTC.ToTradeDebugXML(indent + 1));
                sb.Append(indentStr).AppendLine("</SellersConfiguration>");
            }

            sb.Append(rootIndent).Append("</TradeConfiguration>");

            return sb.ToString();
        }
    }
}
