/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Comprehension/EmailHasWord.cs#2 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring2
{
    /// <summary>
    /// Specialization of telehone has word relation
    /// </summary>
    /// </example>
    public class TelephoneHasWord : HasWord
    {
        public TelephoneHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
