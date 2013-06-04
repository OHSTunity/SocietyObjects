/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/Trade/VendibleConfigurationItem.cs#2 $
      $DateTime: 2007/12/07 13:05:03 $
      $Change: 8002 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  VendibleConfigurationItem
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: VendibleConfigurationItem
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: VendibleConfigurationItem
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: VendibleConfigurationItem
    /// This is an example of how to use this class.
    /// </example>
    public class VendibleConfigurationItem : Something
    {
        #region Kind

        public new class Kind : Something.Kind
        {
        }

        #endregion

        /// <summary>
        /// The claim configuration that this item belongs to.
        /// </summary>
        public VendibleConfiguration VendibleConfiguration;

        /// <summary>
        /// The Vendible.
        /// </summary>
        public Vendible Vendible;

        /// <summary>
        /// Tells how many of the Vendible.
        /// </summary>
        public decimal Multiplier;

        /// <summary>
        /// Defines a specific instance of a vendible.
        /// </summary>
        public Artifact SpecificArtifact;
    }
}
