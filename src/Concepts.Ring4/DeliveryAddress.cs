using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring4
{
    /// <summary>
    /// Points at an Address that should be the DeliveryAddress (Example: A Company can have different adresses for Delivery, Invoice etc.)
    /// </summary>
    public class DeliveryAddress : PostalAddressRelation
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : PostalAddressRelation.Kind { }
        #endregion
    }
}
