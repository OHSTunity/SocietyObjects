using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;


namespace Concepts.Ring4
{
    /// <summary>
    /// Use this to set a standard address to something. This is the adress used on Businesscards and other official documents
    /// </summary>
    public class VisitingAddress : PostalAddressRelation
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : PostalAddressRelation.Kind { }
        #endregion
    }
}
