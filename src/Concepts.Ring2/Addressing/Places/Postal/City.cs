using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring2
{
    /// <summary>
    /// Part of the postal address system.
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class City : PostAddressComponent
    {
		

        /// <summary>
        /// Name of the city.
        /// </summary>
        [SynonymousTo("Name")]
        public string CityName;
	}
}
