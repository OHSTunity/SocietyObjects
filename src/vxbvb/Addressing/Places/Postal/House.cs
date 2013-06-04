using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class House : PostAddressComponent
    {
        #region Kind
        
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
        public string HouseName;
    }
}
