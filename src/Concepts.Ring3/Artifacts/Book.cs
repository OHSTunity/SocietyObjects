using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3
{
    /// <summary>
    /// 
    /// </summary>
    public class Book : LiteraryWork
    {
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : LiteraryWork.Kind
        {

            /// <summary>
            /// 
            /// </summary>
            public Int32 PageCount;
        }
    }
}
