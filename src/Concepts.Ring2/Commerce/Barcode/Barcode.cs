using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;
using System;

namespace Concepts.Ring2
{
	/// <summary>
	/// A barcode contains a code (a string containing text or numbers) in a specific format (Barcode.Kind).
	/// Examples for formats (derived classes from Barcode.Kind) are EAN and Barcode39.
    /// TODO:Henrik, Wordnet map are wrong
	/// </summary>
	public class Barcode : Identifier
	{
		
		/// <summary>
		/// The barcode data (the number or string) including the checksum.
		/// </summary>
        [SynonymousTo("Name")]
		public string Code;

        
	}
}
