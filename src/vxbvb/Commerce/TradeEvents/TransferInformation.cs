/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeEvents/TransferInformation.cs#4 $
      $DateTime: 2009/05/13 03:03:57 $
      $Change: 21724 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using System;
namespace Concepts.Ring2
{
    /// <summary>
    /// Holds unique information about a transfer. E.g ETA and ETD.
    /// </summary>
    public class XTransferInformation : Something
    {
        //public new class Kind : Something.Kind
        //{
        //}

        ///// <summary>
        ///// The time when the items are expected to arrive.
        ///// </summary>
        //public DateTime EstimatedTimeOfArrival;

        ///// <summary>
        ///// The time when the items are expected to departure.
        ///// </summary>
        //public DateTime EstimatedTimeOfDeparture;

        ///// <summary>
        ///// The gate at wich to deliver the goods at the delivery address.
        ///// </summary>
        //public Address ReceivingGate;

        ///// <summary>
        ///// Package number of the transfer.
        ///// </summary>
        //public String PackageReference;

        //public override T Clone<T>()
        //{
        //    T tClone = base.Clone<T>();
        //    TransferInformation info = tClone as TransferInformation;
        //    Copy(this, info);

        //    return tClone;
        //}

        /// <summary>
        /// Copies values from the source to the destination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        //public static void Copy(TransferInformation source, TransferInformation destination)
        //{
        //    destination.EstimatedTimeOfArrival = source.EstimatedTimeOfArrival;
        //    destination.EstimatedTimeOfDeparture = source.EstimatedTimeOfDeparture;
        //    destination.PackageReference = source.PackageReference;
        //    destination.ReceivingGate = source.ReceivingGate;
        //}
    }
}
