/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transfer/Delivered.cs#4 $
      $DateTime: 2009/06/02 16:44:00 $
      $Change: 22508 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  Delivered
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Delivered
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Delivered
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Delivered
    /// This is an example of how to use this class.
    /// </example>
    public class Delivered : Transfered
    {
        public new class Kind : Transfered.Kind { }

        public Trade Trade;
    }
}
