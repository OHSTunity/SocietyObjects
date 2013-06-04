using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SomebodiesRelationWithAddress : SomebodiesRelation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="SomebodiesRelation.Kind"/>
        public new class Kind : SomebodiesRelation.Kind { }
        #endregion

        /// <summary>
        /// Reference pointing to an address.
        /// </summary>
        public Address Address;
    }
}
