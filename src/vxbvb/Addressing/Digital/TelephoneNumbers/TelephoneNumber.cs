using System;
using Starcounter;
using Concepts.Ring1;
namespace Concepts.Ring2
{
    /// <summary>
    /// Telephone numbers need no intruduction. They have revolutionized modern society.
    /// </summary>
	public class TelephoneNumber : Address
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
		public new class Kind : Address.Kind { }
		#endregion

        [SynonymousTo("Name")]
        public string Number;
	}
}