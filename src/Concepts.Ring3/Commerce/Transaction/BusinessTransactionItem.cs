/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Transaction/BusinessTransactionItem.cs#13 $
      $DateTime: 2010/03/16 12:36:19 $
      $Change: 30495 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  TransactionItem
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: TransactionItem
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: TransactionItem
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: TransactionItem
    /// This is an example of how to use this class.
    /// </example>
    public class BusinessTransactionItem : EventShare
    {
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        public new class Kind : EventShare.Kind { }

        [SynonymousTo("WhatIs")]
        public readonly BusinessTransaction Transaction;
        public virtual void SetTransaction(BusinessTransaction transaction)
        {
            SetWhatIs(transaction);
        }
        [SynonymousTo("ToWhat")]
        public readonly Transfer Transfer;
        public virtual void SetTransfer(Transfer transfer)
        {
            SetToWhat(transfer);
        }

        public T AssureTransfer<T>() where T : Transfer
        {
            T transfer = Transfer as T;
            if (transfer == null)
            {
                transfer = Kind.Of<T>().New<T>();
                SetTransfer(transfer);
            }
            return transfer;
        }
        public T AssureTransfer<T>(Transfer.Kind transferKind) where T : Transfer
        {
            T transfer = Transfer as T;
            if (transfer == null)
            {
                transfer = transferKind.New<T>();
                SetTransfer(transfer);
            }
            return transfer;
        }

    }
}
