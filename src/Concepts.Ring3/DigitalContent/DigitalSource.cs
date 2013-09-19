#region Using directives
using Starcounter;
using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;
#endregion

namespace Concepts.Ring3
{
    [Database]
    public class DigitalSource : Something
    {
       
        public URI Location;

        // Exists are already present in Something.
		public Boolean DoExist;

		public DigitalAsset DigitalAsset;
    }
}
