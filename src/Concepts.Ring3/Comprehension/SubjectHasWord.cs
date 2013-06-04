/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Comprehension/SubjectHasWord.cs#3 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring3.Comprehension
{
    /// <summary>
    /// Specialization of subject has word relation
    /// </summary>
    /// </example>
    public class SubjectHasWord : HasWord
    {
        public SubjectHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
