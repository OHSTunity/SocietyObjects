using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    public class PostalAddress : PostAddressComponent
    {
        public new class Kind : PostAddressComponent.Kind { }
    }
}
