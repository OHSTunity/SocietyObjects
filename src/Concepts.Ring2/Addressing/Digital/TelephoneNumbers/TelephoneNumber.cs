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

        [SynonymousTo("AddressID")]
        public String Number;
	}
}