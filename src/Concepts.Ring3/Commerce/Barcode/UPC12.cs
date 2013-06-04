/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Barcode/UPC12.cs#1 $
      $DateTime: 2008/12/01 10:45:35 $
      $Change: 17057 $
      $Author: tobwen $
      =========================================================
*/


using Concepts.Ring1;
using System;

namespace Concepts.Ring3.Commerce.Barcode
{
    /// <summary>
    /// TODO: Summary for class:  UPC12
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: UPC12
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: UPC12
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: UPC12
    /// This is an example of how to use this class.
    /// </example>
    public class UPC12 : Concepts.Ring2.Barcode
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Concepts.Ring2.Barcode.Kind
        {
            public override bool IsValid(string code)
            {
                if (code == null || code.Length != 12) return false;
                if (char.IsDigit(code[11]) == false) return false;
                short s = short.Parse(code[11].ToString());
                return CheckSum(code) == s;
            }

            /// <summary>
            /// Parses an input string. Will possibly change the string
            /// so that it conforms with the standard
            /// </summary>
            /// <param name="barcode">The input to be parsed</param>
            /// <returns>
            /// A valid barcode, or null if the string couldn't be parsed
            /// </returns>
            private string Parse(string code)
            {
                //return null if input is empty or null
                if (string.IsNullOrEmpty(code))
                {
                    return null;
                }

                //some scanners strip leading zero, so we prepend it
                if (code.Length == 11)
                {
                    code = "0" + code;
                }

                //return if it is valid
                if (IsValid(code))
                {
                    return code;
                }

                //it is invalid if len != 12
                if (code.Length != 12)
                {
                    return null;
                }

                //if we get here, we probably have a barcode that was
                //badly printed, i.e a 11-digit code that should have had
                //a "0" at the beginning. if that is the case, a checksum
                //digit would have been generated for those 11 digits,
                //creating a new 12-digit code (that is wrong). We try to
                //parse the first 11 digits, with a "0" prepended.
                code = "0" + code.Substring(1, 11);
                if (IsValid(code))
                {
                    return code;
                }
                return null;
            }

            /// <summary>
            /// Calculates a check sum for a given code
            /// </summary>
            /// <param name="barcode">The input to calculate the checksum from</param>
            /// <returns>The checksum</returns>
            private short CheckSum(string code)
            {
                if (code == null || code.Length < 11) return -1;
                short[] buf = new short[11];
                for (int i = 0; i < 11; i++)
                {
                    char c = code[i];
                    if (char.IsDigit(c) == false) return -1;
                    buf[i] = short.Parse(c.ToString());
                }
                short odd = 0, even = 0;
                for (int j = 0; j < 5; j++)
                {
                    odd += buf[j * 2];
                    even += buf[j * 2 + 1];
                }
                odd += buf[10];
                return (short)((10 - ((odd * 3 + even) % 10)) % 10);
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
