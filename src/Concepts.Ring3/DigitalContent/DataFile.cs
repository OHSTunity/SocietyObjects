#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
#endregion

namespace Concepts.Ring3
{
    // A computer file on a specific location in a computer system.
    public class DataFile : DigitalAssetSource
    {
       
        /// <summary>
        /// The location of the file.
        /// </summary>
        public string LocationPath;
    }
}
