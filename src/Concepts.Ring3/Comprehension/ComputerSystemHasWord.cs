/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Comprehension/ComputerSystemHasWord.cs#2 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring3
{
    /// <summary>
    /// Specialization of Artifact has word relation
    /// </summary>
    /// </example>
    public class ComputerSystemHasWord : HasWord
    {
        public ComputerSystemHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
