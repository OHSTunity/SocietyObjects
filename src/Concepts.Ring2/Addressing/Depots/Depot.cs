/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Depots/Depot.cs#25 $
      $DateTime: 2008/06/11 09:37:41 $
      $Change: 12821 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  Status
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Status
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Status
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Status
    /// This is an example of how to use this class.
    /// </example>
    public class Depot : Address
    {
        public new class Kind : Address.Kind { }

        [SynonymousTo("Owner")]
        public Somebody BelongsTo;

        public override void SetPartOf(Address partOf)
        {
            Owner = (partOf == null)? null: partOf.Owner;
            base.SetPartOf(partOf);
        }
    }
}
