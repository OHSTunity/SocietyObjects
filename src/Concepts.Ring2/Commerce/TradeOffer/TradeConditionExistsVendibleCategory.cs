/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/TradeOffer/TradeConditionExistsVendibleCategory.cs#1 $
      $DateTime: 2007/10/15 17:33:29 $
      $Change: 6422 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring2
{
    public class TradeConditionExistsVendibleCategory : VendibleConditionFunction
    {
        #region Kind
        public new class Kind : VendibleConditionFunction.Kind
        {
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public VendibleCategory VendibleCategory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prerequisite"></param>
        /// <returns></returns>
        public override bool Evaluate(object prerequisite)
        {
            VendibleCategoryPrerequisite prereq = prerequisite as VendibleCategoryPrerequisite;
            if (prereq == null)
            {
                //report error
                return false;
            }
            else
            {
                foreach (VendibleCategory.Kind category in prereq.SearchList)
                {
                    if (category.Equals(VendibleCategory))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
