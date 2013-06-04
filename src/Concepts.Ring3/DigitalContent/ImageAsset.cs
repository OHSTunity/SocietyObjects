#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;
#endregion

namespace Concepts.Ring3
{
    public class ImageAsset : DigitalAsset
    {
        public new class Kind : DigitalAsset.Kind
        {
        }


        /// <summary>
        /// The encoding used for an image is called the image format (i.e. jpg, gif, png, etc.).
        /// It is the same as the DigitalAssets encoding (synonym).
        /// </summary>
        [SynonymousTo("Encoding")]
        public ImageFormat Format;
    }
}
