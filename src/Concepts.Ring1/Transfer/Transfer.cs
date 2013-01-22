/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Transfer/Transfer.cs#4 $
      $DateTime: 2012/04/19 21:33:20 $
      $Change: 56975 $
      $Author: hentil $
      =========================================================
*/


using System.Collections.Generic;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// TODO: Summary for class:  Transfer
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Transfer
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Transfer
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Transfer
    /// This is an example of how to use this class.
    /// </example>
    public class Transfer : Event
    {
        
        public string Signature;

        public IEnumerable<T> Items<T>() where T : Transfered
        {
            return ImplicitRoles<T>();
        }



        //public void Execute(Something thingToMove, Address from, Address to, decimal quantity, Participant.Kind agent, PlacementPackageToBeMovedToExtension preferedPack, bool allowNegativePlacement, decimal quantityPerShare)
        //{
        //    Transfered t;
        //    t = new Transfered();
        //    t.Transfer = this;
        //    t.PlacementPackageToBeMovedToExtension = preferedPack;
        //    t.Execute(thingToMove, from, to, quantity, agent, preferedPack, allowNegativePlacement, quantityPerShare);
        //}
        //public decimal ExecuteAsManyAsPossible(Something thingToMove, Address from, Address to, decimal maxQuantity, Participant.Kind agent, PlacementPackageToBeMovedToExtension preferedPack, decimal quantityPerShare)
        //{
        //    Transfered t;
        //    t = new Transfered();
        //    t.Transfer = this;
        //    t.PlacementPackageToBeMovedToExtension = preferedPack;
        //    return t.ExecuteAsManyAsPossible(thingToMove, from, to, maxQuantity, agent, preferedPack, quantityPerShare);
        //}

        //public void Execute(Placement placement, Address to, decimal quantity, Participant.Kind agent, decimal quantityPerShare)
        //{
        //    Transfered t;
        //    t = new Transfered();
        //    t.Transfer = this;
        //    t.Execute(placement, to, quantity, agent, quantityPerShare);
        //}
    }
}
