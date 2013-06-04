/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Comprehension/ArtifactHasWord.cs#3 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring2
{
    /// <summary>
    /// Specialization of Artifact has word relation
    /// </summary>
    /// </example>
    public class ArtifactHasWord : HasWord
    {
        public ArtifactHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
