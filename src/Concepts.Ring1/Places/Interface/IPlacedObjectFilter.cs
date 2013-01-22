/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Places/Interface/IPlacedObjectFilter.cs#1 $
      $DateTime: 2008/12/18 20:22:26 $
      $Change: 17692 $
      $Author: freblo $
      =========================================================
*/


namespace Concepts.Ring1
{
    /// <summary>
    /// TODO: Summary for class:  IPlacedObjectFilter
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: IPlacedObjectFilter
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: IPlacedObjectFilter
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: IPlacedObjectFilter
    /// This is an example of how to use this class.
    /// </example>
    public interface IPlacedObjectFilter
    {
        Something PlacedObject { get; set; }
        Placement PlacementKind { get; set; }
        bool Recursive { get; set; }
        IPlacementPackageTemplate PackageTemplate { get; set; }
        IAddressTemplate AddressTemplate { get; set; }

        bool IsValid(Placement placement);
    }
}
