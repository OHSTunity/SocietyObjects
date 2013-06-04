/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/VendibleCategoryMember.cs#4 $
      $DateTime: 2008/09/23 11:21:45 $
      $Change: 14912 $
      $Author: tobwen $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    public class VendibleCategoryMember : CategoryMember
    {
        
        /// <summary>
        /// What Vendible is a member of the category.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Vendible Vendible;
        public void SetVendible(Vendible vendible)
        {
            SetWhatIs(vendible);
        }

        /// <summary>
        /// The category the Vendible is member of.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly VendibleCategory.Kind VendibleCategoryKind;
        public void SetVendibleCategoryKind(VendibleCategory.Kind vendibleCategoryKind)
        {
            SetToWhat(vendibleCategoryKind);
        }

    }
}
