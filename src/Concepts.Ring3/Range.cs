/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Range.cs#6 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/


#region Using directives
using Concepts.Ring1;
using System;
using Starcounter;
 
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  Range
    /// 
    /// Represents a range from one decimal value to another.
    /// 
    /// </summary>
    /// <remarks>
    /// Remarks for class: Range
    /// 
    /// From-value = parameter From
    /// 
    /// To-value = parameter To
    /// 
    /// <para>
    /// Paragraph for class: Range
    /// 
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// Example for class: Range
    /// 
    /// Ex1.) (One should always use this method to prevent the same object to be stored more than once)
    /// 
    /// Range newRange = Range._.Assure(2, 13);
    /// 
    /// 
    /// Ex2.)
    /// 
    /// Range newRange = new Range();
    /// //Set from-value
    /// newRange.From = 2;
    /// //Set to-value
    /// newRange.To = 13;
    /// 
    /// </example>
    public class Range : Something
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Something.Kind
        {
            /// <summary>
            /// Assures a new instance of Range. Sets from-value and to-value.
            /// </summary>
            /// <param name="from">From-value in range.</param>
            /// <param name="to">To-value in range.</param>
            /// <returns></returns>
            public Range Assure(decimal from, decimal to)
            {
                Range range;
                String query = "SELECT r FROM " + Range.Kind.GetInstance<Range.Kind>().FullInstanceClassName + " r " +
                               "WHERE r.From=variable(Decimal, rangeFrom) AND " +
                               "r.To=variable(Decimal, rangeTo)";
                
                using (SqlEnumerator sqlEnum = Sql.GetEnumerator(query))
                {
                    sqlEnum.SetVariable("rangeFrom", from);
                    sqlEnum.SetVariable("rangeTo", to);
                    if (sqlEnum.MoveNext())
                    {
                        range = sqlEnum.Current as Range;
                    }
                    else
                    {
                        range = new Range();
                        range.From = from;
                        range.To = to;
                    } 
                }
                return range;
            }
        }

        #endregion

        /// <summary>
        /// From-value in range.
        /// </summary>
        public decimal From;

        /// <summary>
        /// To-value in range.
        /// </summary>
        public decimal To;
    }
}
