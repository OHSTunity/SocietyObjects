using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// Postcode is a kind of Place that is derived in many countries 
    /// post addressing system (as in the Swedish Postnummer). Please
    /// use VAddress to build a new address and to view a current address.
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class Postcode : PostAddressComponent
    {
        #region Kind class
        /// <summary>
        /// Kind of postcode
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
        public string PostCodeID;
      }
}
