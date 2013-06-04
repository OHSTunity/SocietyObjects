/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Barcode/EAN.cs#5 $
      $DateTime: 2009/10/05 11:45:41 $
      $Change: 25771 $
      $Author: freblo $
      =========================================================
*/


#region Using directives
using Concepts.Ring1;
using System;
using Concepts.Ring2;
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  EAN
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: EAN
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: EAN
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: EAN
    /// This is an example of how to use this class.
    /// </example>
    public class EAN8 : Barcode
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Barcode.Kind
        {
            public override T Assure<T>(Something identifies, string identifier)
            {
                return base.Assure<T>(identifies, identifier);
            }
            public override bool IsValid(string code)
            {
                if (code == null || code.Length != 8) return false;
                if (char.IsDigit(code[code.Length - 1]) == false) return false;
                short s = short.Parse(code[code.Length - 1].ToString());
                return EANCheckSum(code) == s;
            }
            private short EANCheckSum(string code)
            {
                if (string.IsNullOrEmpty(code)) return -1;
                int length = code.Length - 1;
                short[] buf = new short[length];
                for (int i = 0; i < length; i++)
                {
                    char c = code[i];
                    if (char.IsDigit(c) == false) return -1;
                    buf[i] = short.Parse(c.ToString());
                }
                short odd = 0, even = 0;
                bool isOdd = true;
                for (int j = length - 1; j >= 0; j--)
                {
                    if (isOdd)
                    {
                        odd += buf[j];
                    }
                    else
                    {
                        even += buf[j];
                    }
                    isOdd = !isOdd;
                }
                return (short)((10 - (odd * 3 + even) % 10) % 10);
            }
        }

        #endregion

        protected override void OnNew()
        {
            base.OnNew();
            // TODO

        }

        protected override void OnDelete()
        {
            // TODO


            base.OnDelete();
        }

        public override string ToSelectorString()
        {
            // TODO
            return base.ToSelectorString();
        }

        public override string ToReadableString()
        {
            // TODO
            return base.ToReadableString();
        }
    }
}
