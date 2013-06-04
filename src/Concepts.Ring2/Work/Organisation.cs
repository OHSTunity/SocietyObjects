using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// The base class for Companies, Sharities, Sportsclubs etc.
    /// </summary>
	public class Organisation : LegalEntity
	{
		
        /// <summary>
        /// Organisation registration number. 
        /// </summary>
        [SynonymousTo("ID")]
        public String OrgRegNo;

	}
}
