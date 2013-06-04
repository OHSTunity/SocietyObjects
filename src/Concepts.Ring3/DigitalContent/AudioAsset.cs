#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

#endregion

namespace Concepts.Ring3
{
    public class AudioAsset : DigitalAsset
    {
        public new class Kind : DigitalAsset.Kind
        {
        }


        /// <summary>
        /// The encoding used for a audio (sound) file or stream is called a codec.
        /// It is the same as the DigitalAssets encoding (synonym).
        /// </summary>
        [SynonymousTo("Encoding")]
        public AudioCodec Codec;


		public Int64 BitRate;

	}
}
