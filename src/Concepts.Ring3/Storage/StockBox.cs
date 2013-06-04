using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Concepts.Ring3.Artifacts;
using Starcounter.Data;

namespace Concepts.Ring3
{
    public class StockBox : StockDepot
    {
        public new class Kind : Depot.Kind { }

        [SynonymousTo("WhatIs")]
        public Box Box;
        
    }
}
