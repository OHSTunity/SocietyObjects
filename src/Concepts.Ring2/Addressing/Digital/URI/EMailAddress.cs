#region Using directives

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Starcounter;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// An email address. I.e. joachim.wester@societyobjects.com.
    /// </summary>
    public class EMailAddress : DigitalAddress
    {
	
        [SynonymousTo("Name")]
        public string EMail;

        /// <summary>
        /// Indicates wether this address is valid
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsValidEmail
        {
            get
            {
                if (EMail == null || EMail == "")
                {
                    return false;
                }

                string pattern = @"^(([^<>()[\]\\.,;:\s@\""]+"
                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                    + @"[a-zA-Z]{2,}))$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(EMail);
            }
        }
	}
}
