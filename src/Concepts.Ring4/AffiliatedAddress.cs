using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Starcounter;

namespace Concepts.Ring4
{
    /// <summary>
    /// This is an address that can't be any other kind of address. It contains a typeofaddress description.
    /// </summary>
    public class AffiliatedAddress : PostalAddressRelation
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : PostalAddressRelation.Kind { }
        #endregion

        [SynonymousTo("Description")]
        public String AddressDescription;
    }
}
