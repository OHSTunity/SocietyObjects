/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/Prerequisite/VendiblePrerequisite.cs#2 $
      $DateTime: 2007/10/15 17:27:58 $
      $Change: 6421 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    public class VendiblePrerequisite
    {
        private List<Vendible> _preRequisite = new List<Vendible>();

        public void AddVendible(Vendible vendible)
        {
            _preRequisite.Add(vendible);
        }
    }
}
