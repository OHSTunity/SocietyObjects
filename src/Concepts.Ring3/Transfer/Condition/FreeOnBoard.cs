using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    /// <summary>
    /// The classic maritime trade term, Free On Board: seller must 
    /// load the goods on board the ship nominated by the buyer, cost 
    /// and risk being divided at ship's rail. The seller must clear 
    /// the goods for export. Maritime transport only. 
    /// </summary>
    public class FreeOnBoard : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group E - Departure
    /// </summary>
    public class ExWorks : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group F - Main Carriage Unpaid
    /// </summary>
    public class FreeCarrier : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group F - Main Carriage Unpaid
    /// </summary>
    public class FreeAlongsideShip : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group C - Main Carriage Paid
    /// </summary>
    public class CostInsuranceAndFreight : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group C - Main Carriage Paid
    /// </summary>
    public class CarriagePaidTo : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }

    /// <summary>
    /// Group C - Main Carriage Paid
    /// </summary>
    public class CarriageAndInsurancePaidTo : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group D - Arrival
    /// </summary>
    public class DeliveredAtFrontier : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }

    /// <summary>
    /// Group D - Arrival
    /// </summary>
    public class DeliveredEXShip : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
    
    /// <summary>
    /// Group D - Arrival
    /// </summary>
    public class DeliveredEXQuay : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
}
