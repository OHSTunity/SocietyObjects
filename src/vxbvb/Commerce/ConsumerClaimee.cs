/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/ConsumerClaimee.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using Ring1;
using Starcounter.Data;

namespace Ring2
{
    /// <summary>
    /// This is the consumer claimee on a Claim, this object doesnt actually contain consumerID and
    /// other Consumer supplier information. Since the claimee might be a store which is supposed to 
    /// use the mother companies Consumer->Supplier relations.
    /// </summary>
    public class ConsumerClaimee : Claimee
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Claimee.Kind"/>
        public new class Kind : Claimee.Kind
        {
//            /// <summary>
//            /// Set up a consumer that represents all consumers to a certain somebody.
//            /// </summary>
//            /// <param name="somebody"></param>
//            /// <returns></returns>
//            public Claimee AssureAllConsumersTo(Somebody somebody)
//            {
//                Everybody everybody = Everybody._.GetInstance();
//                Claimee claimee = (Claimee)Claimee._.Find("WhatIs == {0} AND ToWhat == {1}", new object[] { everybody, somebody });
//                if (claimee == null)
//                {
//                    claimee = (Claimee)this.Relate(everybody, somebody);
//                }
//                return claimee;
//            }
            
            /// <summary>
            /// Assures that the given consumerClaimee has an opposite SupplierClaimee. A
            /// Trade needs one of each.
            /// </summary>
            /// <param name="consumerClaimee"></param>
            /// <returns></returns>
            public SupplierClaimee AssureSupplierClaimee(ConsumerClaimee consumerClaimee)
            {
                return SupplierClaimee._.Relate(
                    consumerClaimee.ToWhat, consumerClaimee.WhatIs) as SupplierClaimee;
            }
        }
        #endregion
    }
}
