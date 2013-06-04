#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// A computer file on a specific location in a computer system.
    /// </summary>
    public class File : DigitalAsset
    {
        // An immaterial computer file entity that does not necessarly recide on one specific place.
        // I.e. "MyDocument.Doc" is a File.Kind that contains a certain text. Each instance (copy) of "MyDocument.doc"
        // is an instance of File.
        public new class Kind : DigitalAsset.Kind
        {
        }

        /// <summary>
        /// The location of the file.
        /// </summary>
        public string LocationPath;
    }
}
