using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    public class VoucherCompensationProvisionCondition : VoucherConditionFunction
    {
        public new class Kind : VoucherConditionFunction.Kind { }

        public CompensationProvision CompensationProvision;
    }
}
