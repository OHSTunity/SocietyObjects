/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Comprehension/PostAddressComponentHasWord.cs#2 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring2
{
    /// <summary>
    /// Specialization of PostAddressComponentHasWord has word relation
    /// </summary>
    /// </example>
    public class PostAddressComponentHasWord : HasWord
    {
        public PostAddressComponentHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
