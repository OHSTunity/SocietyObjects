/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Consumer.cs#15 $
      $DateTime: 2009/05/13 03:03:57 $
      $Change: 21724 $
      $Author: freblo $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// Somebody who uses or is a target of becoming a user of somebodys goods or services, i.e. both customers and prospects of somebody.
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:07559990</equal>
    /// </ontlogy>
    public class Consumer : SomebodiesRelation
    {

        /// <summary>
        /// The consumers id for this relation.
        /// </summary>
        [SynonymousTo("ID")]
        public String ConsumerID;

        /// <summary>
        /// The suppliers id for this relation.
        /// </summary>
        public String SupplierID;

        public Currency DefaultCurrency;

        public DeliveryMethod DefaultDeliveryMethod;

        public TransferCondition DefaultTransferCondition;

        /// <summary>
        /// Shall missing items be sent with a later transfer, or shall they be cancelled?
        /// </summary>
        public bool DefaultAllowBackOrder;

        /// <summary>
        /// The default transfer terms for this Consumer relation.
        /// </summary>
        public PaymentTerms DefaultPaymentTerms;
    }
}
