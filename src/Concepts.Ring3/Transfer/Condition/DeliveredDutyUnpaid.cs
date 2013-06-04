using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    /// <summary>
    /// It means that the seller delivers the goods to the buyer to the named place 
    /// of destination in the contract of sale. The goods are not cleared for import 
    /// or unloaded from any form of transport at the place of destination. 
    /// The buyer is responsible for the costs and risks for the unloading, duty 
    /// and any subsequent delivery beyond the place of destination. 
    /// However, if the buyer wishes the seller to bear cost and risks associated with 
    /// the import clearance, duty, unloading and subsequent delivery beyond the place 
    /// of destination, then this all needs to be explicitly agreed 
    /// upon in the contract of sale. 
    /// </summary>
    public class DeliveredDutyUnpaid : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
}
