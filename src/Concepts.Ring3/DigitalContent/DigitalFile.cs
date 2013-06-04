#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace Concepts.Ring3
{
    public class DigitalFile : DigitalSource
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : DigitalSource.Kind { }
        #endregion
    }
}
