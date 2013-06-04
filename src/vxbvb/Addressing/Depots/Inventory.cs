/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Depots/Inventory.cs#2 $
      $DateTime: 2008/07/31 11:01:07 $
      $Change: 13707 $
      $Author: freblo $
      =========================================================
*/


namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  Inventory
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Inventory
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Inventory
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Inventory
    /// This is an example of how to use this class.
    /// </example>
    public class Inventory : Depot
    {
        public new class Kind : Depot.Kind { }

        public override bool IsStatic
        {
            get
            {
                return false;
            }
        }
    }
}
