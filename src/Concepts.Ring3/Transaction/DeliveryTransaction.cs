/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/DeliveryTransaction.cs#6 $
      $DateTime: 2010/10/12 12:04:59 $
      $Change: 37069 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring2;
using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  DeliveryTransaction
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: DeliveryTransaction
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: DeliveryTransaction
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: DeliveryTransaction
    /// This is an example of how to use this class.
    /// </example>
    public class DeliveryTransaction : MoveTransaction
    {
        public new class Kind : MoveTransaction.Kind { }


        private Customer _customer;
        /// <summary>
        /// The consumer object that represents the buyer and the seller of this trade.
        /// </summary>
        [SynonymousTo("_customer")]
        public readonly Customer Customer;

        /// <summary>
        /// Sets the Consumer as well as creates the Buyer- and Seller-relation.
        /// </summary>
        /// <param name="consumerRelation"></param>
        public void SetCustomerRelation(Customer customerRelation)
        {
            _customer = customerRelation;
        }

        public Somebody Buyer
        {
            get
            {
                return Customer.WhoIs;
            }
        }

        public Somebody Seller
        {
            get
            {
                return Customer.ToWhom;
            }
        }



        public virtual void OnDelivereeSet(Somebody deliveree)
        {
        }
        public virtual Somebody Deliveree
        {
            get
            {
                foreach (Somebody s in ImplicitlyRelatedObjects<Somebody,Deliveree>())
                {
                    return s;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Deliveree.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Deliveree.Kind>());
                }
                OnDelivereeSet(value);
            }
        }
        public virtual void OnDelivererSet(Somebody deliveree)
        {
        }
        public virtual Somebody Deliverer
        {
            get
            {
                foreach (Somebody s in ImplicitlyRelatedObjects<Somebody, Deliverer>())
                {
                    return s;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    AssureExclusiveParticipant(Kind.GetInstance<Deliverer.Kind>(), value);
                }
                else
                {
                    RemoveAllParticipants(Kind.GetInstance<Deliverer.Kind>());
                }
                OnDelivererSet(value);
            }
        }

    }
}
