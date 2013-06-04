/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/Prerequisite/VendibleCategoryPrerequisite.cs#3 $
      $DateTime: 2007/10/15 17:27:58 $
      $Change: 6421 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    /// <summary>
    /// Prerequisite for a TradeConditionExistsVendibleCategory. 
    /// </summary>
    public class VendibleCategoryPrerequisite
    {
        private List<VendibleCategory.Kind> _searchList;

        /// <summary>
        /// Constructor that takes a VendibleCategory list for this prerequisite.
        /// </summary>
        /// <param name="list"></param>
        public VendibleCategoryPrerequisite(List<VendibleCategory.Kind> list)
        {
            _searchList = list;
        }

        /// <summary>
        /// List of categories for that are prereq for a TradeConditionExistsVendibleCategory
        /// </summary>
        public List<VendibleCategory.Kind> SearchList
        {
            get
            {
                if (_searchList == null)
                {
                    _searchList = new List<VendibleCategory.Kind>();
                }
                return _searchList;
            }
        }

    }
}
