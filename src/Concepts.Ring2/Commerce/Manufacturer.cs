/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Manufacturer.cs#2 $
      $DateTime: 2007/07/04 10:36:13 $
      $Change: 4686 $
      $Author: freblo $
      =========================================================
*/

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Manufacturer : SomebodiesRelation
    {
        public new class Kind : SomebodiesRelation.Kind
        {
        }
    }
}
