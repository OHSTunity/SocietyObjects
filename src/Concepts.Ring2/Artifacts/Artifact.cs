/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Artifacts/Artifact.cs#15 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;


namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Artifact : Something
    {
       

        // TODO, check name
        /// <summary>
        /// Serialno of the manufacturer of this piece of goods, if any.
        /// </summary>
        /// <remarks>
        /// The serial number is the identification of an individual piece of goods or a
        /// batch of goods. It is the number or text used by the manufacturer of this specific
        /// piece of goods or the original supplier of the service.
        /// </remarks>
        public string SerialId;

        // TODO, shall the artifact have a location. Or is this done through relations?
        /// <summary>
        /// The current physical place of this piece of goods. The place may also be a
        /// Package if this goods is contained in a box or any other container.
        /// </summary>
        //public AssetDepot Address;
    }
}
