/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionGroupMember.cs#1 $
      $DateTime: 2008/12/09 13:00:04 $
      $Change: 17308 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Connecting a something (ProductionGroup or Production) to a ProductionGroup.
    /// </summary>
    public class ProductionGroupMember : Relation
    {
        /// <summary>
        /// Group.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly ProductionGroup Group;
        public void SetGroup(ProductionGroup group)
        {
            SetToWhat(group);
        }
        /// <summary>
        /// Group member.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Something Member;
        public void SetMember(Something member)
        {
            SetWhatIs(member);
        }
    }
}


    

