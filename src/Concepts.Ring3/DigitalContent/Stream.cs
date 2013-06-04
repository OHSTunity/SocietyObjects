#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// A Stream of bits in a computer system
    /// </summary>
    public class Stream : DigitalAsset
    {
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : DigitalAsset.Kind { }
		#endregion
	}
}
