using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    public class MonetaryVoucher : Voucher
    {
        public new class Kind : Voucher.Kind 
        {
            public decimal UsableAmount;
        }

        public decimal UsableAmount;

        public decimal UsedAmount;
    }
}
