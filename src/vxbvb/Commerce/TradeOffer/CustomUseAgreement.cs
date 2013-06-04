using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using System.Collections;

namespace Concepts.Ring2
{
    /// <summary>
    /// Custom use agreement for price configurations
    /// </summary>
    public class CustomUseAgreement : AgreedCompensation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="AgreedCompensation.Kind"/>
        public new class Kind : AgreedCompensation.Kind
        {
        }
        #endregion

    }
}