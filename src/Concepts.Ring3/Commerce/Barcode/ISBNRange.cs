/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Barcode/ISBNRange.cs#7 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring2;
using System;
using Starcounter;


namespace Concepts.Ring3
{
    /// <summary>
    /// Summary for class:  ISBNRange
    /// 
    /// An ISBN range consists of from-value, to-value, reference to an ISBN kind and a publisher.
    /// 
    /// This range determines the range that belongs to a certain publisher for a ISBN kind.
    /// 
    /// Deprecated!
    /// 
    /// </summary>
    /// <remarks>
    /// Remarks for class: ISBNRange
    /// 
    /// 
    /// 
    /// <para>
    /// Paragraph for class: ISBNRange
    /// 
    /// 
    /// 
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// Example for class: ISBNRange
    /// 
    /// 
    /// 
    /// </example>
    public class ISBNRange : Range
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Range.Kind
        {
            
        }


        #endregion
    }
}
