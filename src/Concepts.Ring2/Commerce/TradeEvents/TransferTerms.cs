/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/TransferTerms.cs#5 $
      $DateTime: 2009/05/13 03:03:57 $
      $Change: 21724 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using System;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// Holds information about the terms for a transfer.
    /// </summary>
    public class XTransferTerms : Something
    {
        public new class Kind : Something.Kind
        {
        }

        ///// <summary>
        ///// How are the items going to be delivered.
        ///// </summary>
        //public DeliveryMethod DeliveryMethod;

        //public TransferCondition TransferCondition;

        ///// <summary>
        ///// Shall missing items be sent with a later transfer, or shall they be cancelled?
        ///// </summary>
        //public bool AllowBackOrder;


        //public override T Clone<T>()
        //{
        //    T tClone = base.Clone<T>();
        //    TransferTerms terms = tClone as TransferTerms;
        //    Copy(this, terms);

        //    return tClone;
        //}

        ///// <summary>
        ///// Copies values from the source to the destination
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="destination"></param>
        //public static void Copy(TransferTerms source, TransferTerms destination)
        //{
        //    destination.DeliveryMethod = source.DeliveryMethod;
        //    destination.AllowBackOrder = source.AllowBackOrder;
        //    destination.TransferCondition = source.TransferCondition;

        //}

    }
}
