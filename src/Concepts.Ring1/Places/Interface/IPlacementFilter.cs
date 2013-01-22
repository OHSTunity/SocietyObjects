using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concepts.Ring1
{
    public interface IPlacementFilter
    {
        Placement PlacementKind { get; set; }
        bool Recursive { get; set; }
        ISomethingTemplate SOTemplate { get; set; }
        IPlacementPackageTemplate PackageTemplate { get; set; }
        IAddressTemplate AddressTemplate { get; set; }

        bool IsValid(Placement placement);
    }
}
