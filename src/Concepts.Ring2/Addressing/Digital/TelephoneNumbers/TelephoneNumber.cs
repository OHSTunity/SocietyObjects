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
        public Country Country;

        [SynonymousTo("AddressID")]
        public String Number;
	}
}