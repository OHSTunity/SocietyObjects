using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    /// <summary>
    /// It means that the seller pays for all transportation costs and 
    /// bears all risk until the goods have been delivered and pays the duty. 
    /// Also used interchangeably with the term "Free Domicile" 
    /// </summary>
    public class DeliveredDutyPaid : TransferCondition
    {
        public new class Kind : TransferCondition.Kind { }
    }
}
