using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;

namespace Concepts.Ring4
{
    public class InvoiceAddress : PostalAddressRelation
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : PostalAddressRelation.Kind { }
        #endregion
    }
}
