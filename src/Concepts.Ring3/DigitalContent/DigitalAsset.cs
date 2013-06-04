#region Using directives

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// An immaterial computer file or stream entity that does not necessarly 
    /// recide on one specific place.
    /// </summary>
    public abstract class DigitalAsset : ContentBearingObject
    {
       
        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding;


        public IEnumerable<DigitalSource> Sources
        {
            get { return GetSources<DigitalSource>(); }
        }
		/// <summary>
		/// 
		/// </summary>
        public IEnumerable<T> GetSources<T>() where T : DigitalSource
        {
            return null; //TODO: IndexedQueryHelper.GetRelatesTo<T>(this, "DigitalAsset");
        }
	}
}
