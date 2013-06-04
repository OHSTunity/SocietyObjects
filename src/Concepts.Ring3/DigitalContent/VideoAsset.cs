#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;
#endregion

namespace Concepts.Ring3
{
    public class VideoAsset : DigitalAsset
    {
        public new class Kind : DigitalAsset.Kind
        {
        }


        /// <summary>
        /// The encoding used for a video file or stream is called a codec.
        /// It is the same as the DigitalAssets encoding (synonym).
        /// </summary>
        [SynonymousTo("Encoding")]
        public VideoCodec Codec;

		public Int64 BitRate;
        public String LanguageISO;
	}
}
