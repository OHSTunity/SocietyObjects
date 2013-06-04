/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/TradesideConfigurationItem.cs#5 $
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
    /// TODO: Summary for class:  TradesideConfigurationItem
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: TradesideConfigurationItem
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: TradesideConfigurationItem
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: TradesideConfigurationItem
    /// This is an example of how to use this class.
    /// </example>
    public class TradesideConfigurationItem : Something
    {
        #region Kind

        public new class Kind : Something.Kind
        {
        }

        #endregion

        /// <summary>
        /// The claim configuration that this item belongs to.
        /// </summary>
        public TradesideConfiguration TradesideConfiguration;

        /// <summary>
        /// Tells how many of the Vendible.
        /// </summary>
        public decimal Multiplier;

        /// <summary>
        /// Defines a specific instance.
        /// </summary>
        public Something SpecificInstance;

        public virtual string ToTradeDebugXML()
        {
            return ToTradeDebugXML(0);
        }

        public virtual string ToTradeDebugXML(int indent)
        {
            string rootIndent = (indent > 0) ? " ".PadRight(indent) : string.Empty;
            string indentStr = " ".PadRight(indent + 1);
            Something specificInstance = SpecificInstance;

            StringBuilder sb = new StringBuilder();

            if (indent == 0)
            {
                sb.AppendLine("<?xml version=\"1.0\"?>");
            }

            sb.Append(rootIndent).Append("<TradesideConfigurationItem Type=\"").Append(ToReadableString()).AppendLine("\">");
            sb.Append(indentStr).Append("<TradesideConfiguration>").Append(TradesideConfiguration.ToReadableString()).AppendLine("</TradesideConfiguration>");
            sb.Append(indentStr).Append("<Multiplier>").Append(Multiplier.ToString()).AppendLine("</Multiplier>");

            if (specificInstance != null)
            {
                sb.Append(indentStr).Append("<SpecificInstance>").Append(specificInstance.ToReadableString()).AppendLine("</SpecificInstance>");
            }
            sb.Append(rootIndent).AppendLine("</TradesideConfigurationItem>");

            return sb.ToString();
        }
    }
}
