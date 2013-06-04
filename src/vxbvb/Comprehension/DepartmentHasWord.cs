/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Comprehension/DepartmentHasWord.cs#2 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring2.Comprehension
{
    /// <summary>
    /// TODO: Summary for class:  DepartmentHasWord
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: DepartmentHasWord
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: DepartmentHasWord
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: DepartmentHasWord
    /// This is an example of how to use this class.
    /// </example>
    public class DepartmentHasWord : HasWord
    {
        public DepartmentHasWord(Word word, Something wordOwner, WordIndexAttribute.Kind attrKind) 
            : base(word, wordOwner, attrKind)
        {
        }
    }
}
