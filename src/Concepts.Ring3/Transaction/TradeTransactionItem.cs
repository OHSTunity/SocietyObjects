/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/TradeTransactionItem.cs#3 $
      $DateTime: 2011/09/23 12:56:38 $
      $Change: 48401 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  TradeTransactionItem
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: TradeTransactionItem
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: TradeTransactionItem
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: TradeTransactionItem
    /// This is an example of how to use this class.
    /// </example>
    public class TradeTransactionItem : BusinessTransactionItem
    {
        public new class Kind : BusinessTransactionItem.Kind { }

        /// <summary>
        /// This property should be readonly. Use SetTransferedKindSeller(Something.Kind kind) instead
        /// </summary>
        public Something.Kind TransferedKindSeller;
        public void SetTransferedKindSeller(Something.Kind kind)
        {
            TransferedKindSeller = kind;

        }
        /// <summary>
        /// This property should be readonly. Use SetTransferedKindBuyer(Something.Kind kind) instead
        /// </summary>
        public Something.Kind TransferedKindBuyer;
        public void SetTransferedKindBuyer(Something.Kind kind)
        {
            TransferedKindBuyer = kind;
        }

        [SynonymousTo("Quantity")]
        public readonly decimal QuantitySeller;
        public void SetQuantitySeller(decimal quantity)
        {
            SetQuantificationQuantity(quantity);
        }
        private decimal _QuantityBuyer;
        [SynonymousTo("_QuantityBuyer")]
        public readonly decimal QuantityBuyer;
        public void SetQuantityBuyer(decimal quantity)
        {
            _QuantityBuyer = quantity;
        }


        public string TransferedKindNameSeller
        {
            get { return TransferedKindSeller != null ? TransferedKindSeller.Name : string.Empty; }
        }
        public string TransferedKindNameBuyer
        {
            get { return TransferedKindBuyer != null ? TransferedKindBuyer.Name : string.Empty; }
        }


        public PlacementPackageToBeMovedToExtension.Kind PackageSeller;

        public decimal BaseQuantitySeller
        {
            get
            {
                if (PackageSeller != null)
                {
                    return PackageSeller.ConvertToBaseQuantity(QuantitySeller);
                }
                else
                {
                    return QuantitySeller;
                }
            }
        }
        public decimal BaseQuantityBuyer
        {
            get
            {
                return QuantityBuyer;
            }
        }


    }
}
