using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Concepts.Ring3.Artifacts;
using Starcounter.Data;

namespace Concepts.Ring3
{
    public class StockContainer : StockDepot
    {
        public new class Kind : Depot.Kind { }
        [SynonymousTo("WhatIs")]
        public Container Container;

    }
}
