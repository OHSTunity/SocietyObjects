/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Documents/Document.cs#13 $
      $DateTime: 2010/04/12 12:51:07 $
      $Change: 31538 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System.Collections;
using System.Collections.Generic;
using SocietyObjects.Utils;

namespace Concepts.Ring2
{
    /// <summary>
    /// A document is a way of defining the type of e.g. Trade or VendibleTransfer.
    /// A Trade can be a Customer Order, Supplier Order, Receipt etc by defining a Document.Kind
    /// on the trade we can specify what document type it is.
    /// 
    /// I.e. a PurchaseOrder is of course the buyers view of a Trade, the same Trade is a CustomerOrder for the seller, therefore
    /// Document inherits Relation.
    /// </summary>
    public abstract class Document : Relation
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Relation.Kind
        {
        }

        #endregion

        /// <summary>
        /// The somebody that views the document in a special way.
        /// </summary>
        [SynonymousTo("ToWhat")] 
        public readonly Somebody ToWhom;
        public void SetToWhom(Somebody toWhom)
        {
            SetToWhat(toWhom);
        }

        public IEnumerable<DocumentItem> Items
        {
            get { return GetItems<DocumentItem>().Lock(); }
        }

        public IEnumerable<T> GetItems<T>() where T : DocumentItem
        {
            return IndexedQueryHelper.GetRelatesTo<T>(this, "Document").Lock();
        }

    }
}
