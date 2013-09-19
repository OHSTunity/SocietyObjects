/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Transfer/Transfered.cs#11 $
      $DateTime: 2012/06/04 13:08:03 $
      $Change: 58596 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System;
using System.Collections.Generic;
namespace Concepts.Ring1
{
    /// <summary>
    /// TODO: Summary for class:  Transfered
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Transfered
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Transfered
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Transfered
    /// This is an example of how to use this class.
    /// </example>
    public abstract class Transfered : ParticipatingThing
    {
        
        [SynonymousTo("ParticipatesIn")]
        public Transfer Transfer;
        

        [SynonymousTo("WhatIs")]
        public Something TransferedThing;
        
        public DateTime ExecutedTime;
        public bool IsExecuted
        {
            get { return ExecutedTime > DateTime.MinValue; }
        }
        
        
        [SynonymousTo("Quantity")]
        public decimal ReferedQuantity;


        /// <summary>
        /// This might be a "super" transfer item that is a grouping of many transferitems with exactly the same properties.
        /// The per event tells the quantity that was the original value for each grouped transfitem.
        /// </summary>
        public decimal QuantityPerShare;

        /// <summary>
        /// Responsible agent (person, company group etc.) to have the move performed.
        /// For instance, if this is a move in a trade (aka purchase order), the Buyer role is usually the agent
        /// responsible for delivering the money, whilst the Seller role is usually responsible to deliver goods or services.
        /// </summary>
        public Participant Agent;

        public Address From;
        public Address To;


        public void SetFrom(Address from)
        {
            From = from;
        }
        public void SetTo(Address to)
        {
            To = to;
        }

        private void ValidateParameters(
            Something objectToTransfer, 
            Address from, 
            Address to
            )
        {
            if (to == null)
            {
                throw new ArgumentNullException("to", "You can only transfer things to a valid address");
            }
            if (from == null)
            {
                throw new ArgumentNullException("from", "You can only transfer things from a valid address");
            }
            if (objectToTransfer == null)
            {
                throw new ArgumentNullException("thingToTransfer", "You can not transfer a NULL value");
            }
        }

        private void SetParameters(
            Something objectToTransfer, 
            Address from, 
            Address to, 
            decimal quantity, 
            Participant agent)
        {
            TransferedThing = objectToTransfer;
            From = from;
            To = to;
            ReferedQuantity = quantity;
            Agent = agent;
        }

        public PlacementPackageToBeMovedToExtension PlacementPackageToBeMovedToExtension;

        public void Execute(
            Something objectToTransfer,
            Address from,
            Address to,
            decimal quantity,
            Participant agent,
            PlacementPackageToBeMovedToExtension package)
        {
            Execute(objectToTransfer,
                from,
                to,
                quantity,
                agent,
                package,
                false);
        }

        private void Execute(
            Something objectToTransfer, 
            Address from, 
            Address to, 
            decimal quantity, 
            Participant agent,
            PlacementPackageToBeMovedToExtension package,
            bool reExecute)
        {
            
            ValidateParameters(objectToTransfer, from, to);

            TransferedThing = objectToTransfer;
            From = from;
            To = to;
            ReferedQuantity = quantity;
            Agent = agent;

            if (quantity == 0) { return; }
            if (!reExecute && IsExecuted) { return; }

            Placement fromPlacement = null;
            bool isPositiveTransfer = quantity > 0;

            fromPlacement = FindPlacement<Placement>(objectToTransfer, from, package);

            decimal newQty = fromPlacement != null ? fromPlacement.ReferedQuantity - quantity : -quantity;

            if (fromPlacement == null)
            {
                if (newQty != 0)
                {
                    // Create a new Placement
                    fromPlacement = newQty > 0 ? (Placement)new PositivePlacement() : (Placement)new NegativePlacement();
                    fromPlacement.PlacementPackageToBeMovedToExtension = package;
                    fromPlacement.PlacedObject = objectToTransfer;
                    fromPlacement.Address = from;
                    fromPlacement.ReferedQuantity = newQty;
                }
            }
            else if (newQty == 0)
            {
                fromPlacement.Delete();
            }
            else
            {
                if (newQty > 0 && fromPlacement is NegativePlacement)
                {
                    fromPlacement.Delete();
                    fromPlacement = new PositivePlacement();
                    fromPlacement.PlacementPackageToBeMovedToExtension = package;
                    fromPlacement.PlacedObject = objectToTransfer;
                    fromPlacement.Address = from;
                }
                else if (newQty < 0 && fromPlacement is PositivePlacement)
                {
                    fromPlacement.Delete();
                    fromPlacement = new NegativePlacement();
                    fromPlacement.PlacementPackageToBeMovedToExtension = package;
                    fromPlacement.PlacedObject = objectToTransfer;
                    fromPlacement.Address = from;
                }
                fromPlacement.ReferedQuantity = newQty;
            }

            Placement toPlacement = FindPlacement<Placement>(objectToTransfer, to,package);

            newQty = toPlacement != null ? toPlacement.ReferedQuantity + quantity : quantity;

            if (toPlacement == null)
            {
                if (newQty != 0)
                {
                    // Create a new Placement
                    toPlacement = newQty > 0 ? (Placement)new PositivePlacement() : (Placement)new NegativePlacement();
                    toPlacement.PlacementPackageToBeMovedToExtension = package;
                    toPlacement.PlacedObject = objectToTransfer;
                    toPlacement.Address = to;
                    toPlacement.ReferedQuantity = newQty;
                }
            }
            else if (newQty == 0)
            {
                toPlacement.Delete();
            }
            else
            {
                // Modify the current Placement
                if (newQty > 0 && toPlacement is NegativePlacement)
                {
                    toPlacement.Delete();
                    toPlacement = new PositivePlacement();
                    toPlacement.PlacementPackageToBeMovedToExtension = package;
                    toPlacement.PlacedObject = objectToTransfer;
                    toPlacement.Address = to;
                }
                else if (newQty < 0 && toPlacement is PositivePlacement)
                {
                    toPlacement.Delete();
                    toPlacement = new NegativePlacement();
                    toPlacement.PlacementPackageToBeMovedToExtension = package;
                    toPlacement.PlacedObject = objectToTransfer;
                    toPlacement.Address = to;
                }
                toPlacement.ReferedQuantity = newQty;
            }
            ExecutedTime = DateTime.Now;
            if (TransferedExecuted != null)
            {
                TransferedExecuted(this, objectToTransfer, quantity, from, to);
            }
        }

        public void ExecuteWithoutPlacementMerge(
            Something objectToTransfer,
            Address from,
            Address to,
            decimal quantity,
            Participant agent,
            PlacementPackageToBeMovedToExtension package,
            bool reExecute)
        {
            if (quantity == 0) { return; }
            if (!reExecute && IsExecuted) { return; }

            Placement fromPlacement;
            Placement toPlacement;
            ValidateParameters(objectToTransfer, from, to);

            TransferedThing = objectToTransfer;
            From = from;
            To = to;
            ReferedQuantity = quantity;
            Agent = agent;
            bool isPositiveTransfer = quantity > 0;


            decimal newQty = -quantity;

            // Create a new Placement
            fromPlacement = newQty > 0 ? (Placement)new PositivePlacement() : (Placement)new NegativePlacement();
            fromPlacement.PlacementPackageToBeMovedToExtension = package;
            fromPlacement.PlacedObject = objectToTransfer;
            fromPlacement.Address = from;
            fromPlacement.ReferedQuantity = newQty;


            newQty = quantity;

            // Create a new Placement
            toPlacement = newQty > 0 ? (Placement)new PositivePlacement() : (Placement)new NegativePlacement();
            toPlacement.PlacementPackageToBeMovedToExtension = package;
            toPlacement.PlacedObject = objectToTransfer;
            toPlacement.Address = to;
            toPlacement.ReferedQuantity = newQty;
            ExecutedTime = DateTime.Now;
            if (TransferedExecuted != null)
            {
                TransferedExecuted(this, objectToTransfer, quantity, from, to);
            }
        }

        /*TODO
        public void ExecuteWithoutPlacementMerge()
        {
            ExecuteWithoutPlacementMerge(WhatIs, From, To, ReferedQuantity, Agent, Package, false);
        }
        public void Execute()
        {
            Execute(WhatIs, From, To, ReferedQuantity, Agent, Package,false);
        }
        public void ReExecute()
        {
            Execute(WhatIs, From, To, ReferedQuantity, Agent, Package, true);
        }
        public void ReExecuteWithoutPlacementMerge()
        {
            ExecuteWithoutPlacementMerge(WhatIs, From, To, ReferedQuantity, Agent, Package, true);
        }
        */





        public override T Clone<T>()
        {
            Transfered t = base.Clone<Transfered>();
            t.PlacementPackageToBeMovedToExtension = PlacementPackageToBeMovedToExtension;
            t.SetFrom(From);
            t.SetTo(To);
            t.ExecutedTime = ExecutedTime;
            t.Agent = Agent;
            return t as T;
        }

        private T FindPlacement<T>(Something placedObject, Address where, PlacementPackageToBeMovedToExtension package) where T : Placement
        {
            foreach (T p in where.RelationsTo<T>(placedObject))
            {
                if (package != null)
                {
                    if (package == p.PlacementPackageToBeMovedToExtension)
                    {
                        return p;
                    }
                }
                else
                {
                    return p;
                }
            }
            return null;
        }

        public static event TransferedExecutedDelegate TransferedExecuted;
    }
    public delegate void TransferedExecutedDelegate(Transfered transfered, Something transferedObject, decimal quantity, Address from, Address to);
}
