#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace Concepts.Ring3
{
    public class DigitalStream : DigitalSource
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : DigitalSource.Kind { }
        #endregion
    }
}
