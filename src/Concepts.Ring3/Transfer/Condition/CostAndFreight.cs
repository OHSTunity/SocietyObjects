using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    /// <summary>
    /// Seller must pay the costs and freight to bring the goods 
    /// to the port of destination. However, risk is transferred 
    /// to the buyer once the goods have crossed the ship's rail. 
    /// Maritime transport only.
    /// </summary>
    public class CostAndFreight : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
}
