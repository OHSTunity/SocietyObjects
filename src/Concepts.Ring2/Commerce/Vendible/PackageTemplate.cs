/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/PackageTemplate.cs#1 $
      $DateTime: 2007/10/15 17:27:58 $
      $Change: 6421 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System;

namespace Concepts.Ring2
{
    /// <summary>
    /// This class represents a template for different types of packages.
    /// </summary>
    public class PackageTemplate : Something
    {

        /// <summary>
        /// Denotes the weight of this package type.
        /// <remarks>Note that this is the weight of the package type, 
        /// not what is inside of the package.</remarks>
        /// </summary>
        public decimal Weight;

        /// <summary>
        /// Denotes the volume of this package type.
        /// </summary>
        public decimal Volume;

        /// <summary>
        /// Height of this package type.
        /// </summary>
        public decimal Height;

        /// <summary>
        /// width of this package type.
        /// </summary>
        public decimal Width;

        /// <summary>
        /// Depth of this package type.
        /// </summary>
        public decimal Depth;

        /// <summary>
        /// The unit of the current mass of the package type.
        /// </summary>
        public MassUnit MassUnit;

        /// <summary>
        /// The unit the height, length, volume and depth is measured in.
        /// </summary>
        public LengthUnit LengthUnit;
    }
}
