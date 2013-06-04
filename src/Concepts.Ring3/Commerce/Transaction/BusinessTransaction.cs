/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Transaction/BusinessTransaction.cs#12 $
      $DateTime: 2010/04/12 12:51:07 $
      $Change: 31538 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring2;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using SocietyObjects.Utils;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  Transaction
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Transaction
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Transaction
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Transaction
    /// This is an example of how to use this class.
    /// </example>
    public class BusinessTransaction : Event
    {
        public new class Kind : Event.Kind { }

        protected override void OnNew()
        {
            base.OnNew();
            RegistrationTime = DateTime.Now;
        }

        /// <summary>
        /// Registration time of a purchase.
        /// </summary>
        public DateTime RegistrationTime;

        public IEnumerable<T> Items<T>() where T : BusinessTransactionItem
        {
            // Workaround for not using a closed enumerator with SCDB1.3.

            return this.Roles<T>().Lock();
        }

        public T Document<T>() where T : Document
        {
            return Role<T>();
        }
        public T Document<T>(Document.Kind documentKind) where T : Document
        {
            return Role<T>(documentKind);
        }
        public T Document<T>(Somebody toWhom) where T : Document
        {
            return RelationTo<T>(toWhom);
        }
        public T Document<T>(Document.Kind documentKind, Somebody toWhom) where T : Document
        {
            return RelationTo<T>(documentKind, toWhom);
        }

        public IEnumerable<T> Documents<T>() where T : Document
        {
            return Roles<T>().Lock();
        }
        public IEnumerable<T> Documents<T>(Document.Kind documentKind) where T : Document
        {
            return Roles<T>(documentKind);
        }
        public IEnumerable<T> Documents<T>(Somebody toWhom ) where T : Document
        {
            return RelationsTo<T>(toWhom);
        }
        public IEnumerable<T> Documents<T>(Document.Kind documentKind, Somebody toWhom) where T : Document
        {
            return RelationsTo<T>(documentKind,toWhom);
        }

        


    }
}
