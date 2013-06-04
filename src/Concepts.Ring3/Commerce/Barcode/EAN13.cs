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
    public class EAN13 : Concepts.Ring2.Barcode
    {
        public new class Kind : Concepts.Ring2.Barcode.Kind
        {
            
            #region EAN13 checksum code

            public short EAN13CheckSum(string code)
            {
                if (code == null || code.Length < 12) return -1;
                short[] buf = new short[12];
                for (int i = 0; i < 12; i++)
                {
                    char c = code[i];
                    if (char.IsDigit(c) == false) return -1;
                    buf[i] = short.Parse(c.ToString());
                }
                short odd = 0, even = 0;
                for (int j = 0; j < 6; j++)
                {
                    odd += buf[j * 2];
                    even += buf[j * 2 + 1];
                }
                return (short)((10 - ((even * 3 + odd) % 10)) % 10);
            }

            public override bool IsValid(string code)
            {
                if (code == null || code.Length != 13) return false;
                if (char.IsDigit(code[12]) == false) return false;
                short s = short.Parse(code[12].ToString());
                return EAN13CheckSum(code) == s;
            }

            #endregion

        
        }
       

    }
}
