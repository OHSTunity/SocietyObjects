using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;



namespace Concepts.Ring2
{
    /// <summary>
    /// The street part of an address. In "Joachim Wester, 14B Kensington Court Gardens, 
    /// Kensington Court Place, London W8 5QE, United Kingdom", the street object would
    /// be "Kensington Court Place, London W8 5QE, United Kingdom".
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
	public class Street: PostAddressComponent
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        /// <seealso cref="SpatialAddress.Kind"/>
        public new class Kind : PostAddressComponent.Kind 
        {

        }

		#endregion

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("Name")]
        public string StreetName;
	}
}
