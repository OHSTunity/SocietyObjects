using System;
using System.Collections.Generic;
using System.Text;

namespace Ring3
{
    /// <summary>
    /// A publication of a creation
    /// </summary>
    public class Publication : ContentBearingObject
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="ContentBearingObject.Kind"/>
        public new class Kind : ContentBearingObject.Kind
        {
        }
        #endregion

        /// <summary>
        /// Internaltional Standard Book Number
        /// </summary>
        public String ISBN;
    }
}
