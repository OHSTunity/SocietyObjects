/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Depots/Reserved.cs#4 $
      $DateTime: 2008/05/26 18:59:25 $
      $Change: 12433 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  Reserved
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Reserved
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Reserved
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Reserved
    /// This is an example of how to use this class.
    /// </example>
    public class ReservedInventory : UnAvailable
    {
        public new class Kind : UnAvailable.Kind { }

        [SynonymousTo("DisabledBy")]
        public Something ReservedBy;

    }
}
