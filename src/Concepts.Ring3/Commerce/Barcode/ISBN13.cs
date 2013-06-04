#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Starcounter; 
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// 
    /// </summary>
    public class ISBN13 : EAN13
    {
        #region Kind
        public new class Kind : EAN13.Kind
        {
            public override bool IsValid(string code)
            {
                return (base.IsValid(code) && 
                    (code.StartsWith("978", StringComparison.Ordinal) || 
                    code.StartsWith("979", StringComparison.Ordinal)));
            }
        }
        #endregion
    }
}
