/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring4/Artifacts/PointOfSale.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring3;

namespace Concepts.Ring4.Artifacts
{
    /// <summary>
    /// Represents a POS (Point Of Sale), synonymous to Till.
    /// </summary>
    public class PointOfSale : ComputerSystem
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ComputerSystem.Kind
        {

        }

        #endregion
    }
}
