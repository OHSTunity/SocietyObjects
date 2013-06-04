using System;
using System.Collections.Generic;
using System.Text;
using Starcounter.Data;

namespace Ring3
{
    /// <summary>
    /// Till exempel en diktsamling eller en film. En film kan best� av l�tar, animationer som �r andra sj�lvst�ndiga verk med egna upphovsm�n etc.
    /// En bok kan vara kompilerad av separata verk, doktorsavhandlingar etc. osv.
    /// </summary>
    public class Compilation : Creation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Creation.Kind"/>
        public new class Kind : Creation.Kind { }
        #endregion

        /// <summary>
        /// A Compilation contains one or more Creation.
        /// </summary>
        [RelatesTo(typeof(Creation), "Compilation")]        
        public ICollection<Creation> Creations;
    }
}
