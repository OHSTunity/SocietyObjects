/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/IVendibleIdentifierLogic.cs#1 $
      $DateTime: 2007/10/15 17:27:58 $
      $Change: 6421 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// Logic class for performing the actuall identifying.
    /// 
    /// It is recommended to implement the interface on a kind so that 
    /// there is only one instance of the logic. The IdentifyVendibles-method
    /// must be synchronized!
    /// </summary>
    public interface IVendibleIdentifierLogic
    {
        /// <summary>
        /// Identifies Vendibles for the given object.
        /// This method must use a lock object, otherwise multiple 
        /// identifications can be made of the same object!
        /// </summary>
        /// <param name="something"></param>
        void IdentifyVendibles(Something something);
    }
}
