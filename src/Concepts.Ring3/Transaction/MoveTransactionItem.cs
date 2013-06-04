/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/MoveTransactionItem.cs#5 $
      $DateTime: 2010/03/16 12:36:19 $
      $Change: 30495 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  MoveTransactionItem
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: MoveTransactionItem
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: MoveTransactionItem
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: MoveTransactionItem
    /// This is an example of how to use this class.
    /// </example>
    public class MoveTransactionItem : BusinessTransactionItem
    {
        public new class Kind : BusinessTransactionItem.Kind { }

        public Participant.Kind Agent;

        public Something.Kind TransferedKind;
        public virtual void SetTransferedKind(Something.Kind transferedKind)
        {
            TransferedKind = transferedKind;
        }
        public string TransferedKindName
        {
            get
            {
                return TransferedKind != null ? TransferedKind.Name : string.Empty;
            }
        }
        public Address From;
        public Address To;


        private Something _UniqueObject;
        [SynonymousTo("_UniqueObject")]
        public readonly Something UniqueObject;
        public void SetUniqueObject(Something uniqueObject)
        {
            _UniqueObject = uniqueObject;
        }

        private Something _TemplateObject;
        [SynonymousTo("_TemplateObject")]
        public readonly Something TemplateObject;
        public void SetTemplateObject(Something templateObject)
        {
            _TemplateObject = templateObject;
        }

        private bool _isApproved;
        [SynonymousTo("_isApproved")]
        public readonly bool IsApproved;

        private DateTime _approvedTime;
        [SynonymousTo("_approvedTime")]
        public readonly DateTime ApprovedTime;

        public PlacementPackageToBeMovedToExtension.Kind Package;

        public decimal BaseQuantity
        {
            get
            {
                if (Package != null)
                {
                    return Package.ConvertToBaseQuantity(Quantity);
                }
                else
                {
                    return Quantity;
                }
            }
        }

        public void Approve()
        {
            if (!_isApproved)
            {
                OnApprove();
                _isApproved = true;
                _approvedTime = DateTime.Now;
            }
        }
        public void UnApprove()
        {
            _isApproved = false;
            _approvedTime = DateTime.MinValue;
        }

        protected virtual void OnApprove()
        {
        }
    }
}
