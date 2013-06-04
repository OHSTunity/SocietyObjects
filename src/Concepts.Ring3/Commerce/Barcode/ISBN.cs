/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Barcode/ISBN.cs#10 $
      $DateTime: 2009/05/15 12:39:11 $
      $Change: 21939 $
      $Author: lawyan $
      =========================================================
*/


#region Using directives
using Concepts.Ring1;
using Concepts.Ring2;
using System;
using Starcounter;

#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// Summary for class:  ISBN
    /// 
    /// TODO:
    /// 
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: ISBN
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: ISBN
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: ISBN
    /// This is an example of how to use this class.
    /// </example>
    public class ISBN : Barcode
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Barcode.Kind
        {
            public override bool IsValid(string code)
            {
                // this is only for ISBN-10
                if (code.Length != 10) return false;

                int sum = 0;
                short s;
                for (int i = 1; i <= 9; i++)
                {

                    if (short.TryParse(code[i - 1].ToString(), out s))
                    {
                        sum += s * i;
                    }
                    else
                        return false;
                }
                int mod = sum % 11;
                char checksum;
                if (mod == 10)
                {
                    checksum = 'X';
                }
                else
                {
                    checksum = mod.ToString()[0];
                }
                return checksum == code[9];

            }
        }

        #endregion
    }
}
