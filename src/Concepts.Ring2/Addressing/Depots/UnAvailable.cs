/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Depots/UnAvailable.cs#2 $
      $DateTime: 2008/05/15 17:10:30 $
      $Change: 12177 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  NotAvailable
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: NotAvailable
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: NotAvailable
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: NotAvailable
    /// This is an example of how to use this class.
    /// </example>
    public class UnAvailable : Inventory
    {
        public new class Kind : Inventory.Kind { }

        public Something DisabledBy;

        public override void SetPartOf(Address partOf)
        {
            if (AddressID == null && partOf != null)
            {
                AddressID = partOf.AddressID;
            }
            base.SetPartOf(partOf);
        }

    }
}
