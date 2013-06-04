using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Starcounter.Data;
using Concepts.Ring3.Artifacts;

namespace Concepts.Ring3
{
    public class StockPallet : StockDepot
    {
        public new class Kind : Depot.Kind { }
        [SynonymousTo("WhatIs")]
        public Pallet Pallet;
    }
}
