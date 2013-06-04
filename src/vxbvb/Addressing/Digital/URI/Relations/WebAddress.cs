using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    public abstract class WebAddress : AddressRelation
    {
        public new class Kind : AddressRelation.Kind { }
    }
}
