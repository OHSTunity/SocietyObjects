using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class PreDefinedConsigneeRole : SomebodiesRelationWithAddress
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="SomebodiesRelationWithAddress.Kind"/>
        public new class Kind : SomebodiesRelationWithAddress.Kind { }
        #endregion
    }
}
