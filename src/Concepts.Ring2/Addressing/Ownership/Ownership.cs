/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Ownership/Ownership.cs#6 $
      $DateTime: 2008/12/19 16:19:17 $
      $Change: 17716 $
      $Author: headstestdev $
      =========================================================
*/


using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    /// <summary>
    /// An area where something can be stored.
    /// </summary>
    public class Ownership : Address
    {
        public Ownership() { }
        public Ownership(Somebody owner)
        {
            Owner = owner;
        }

        [SynonymousTo("Owner")]
        public Somebody OwnedBy;
        #region Kind

        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        public new class Kind : Address.Kind
        {
            /// <summary>
            /// This is the only constructor that shall be used for depots.
            /// </summary>
            /// <param name="owner"></param>
            /// <returns></returns>
            public T New<T>(Somebody owner) where T : Ownership
            {
                Ownership depot = New<Ownership>();
                depot.Owner = owner;
                return depot as T;
            }
            
        }

        #endregion

        public override void SetPartOf(Address partOf)
        {
            Owner = (partOf == null) ? null : partOf.Owner;
            base.SetPartOf(partOf);
        }

    }
}
