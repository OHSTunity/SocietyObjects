/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionRelation.cs#2 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    public class ProductionRelation : Relation
    {
       

        /// <summary>
        /// The object addressed by the Production
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Something ProdOwner;
        public void SetProdOwner(Something prodOwner)
        {
            SetToWhat(prodOwner);
        }



        /// <summary>
        /// The Production that belongs to a owner
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Production Production;
        public void SetProduction(Production production)
        {
            SetWhatIs(production);
        }

        /// <summary>
        /// Setting of "ToWhat" property of this relation.
        /// </summary>
        /// <param name="addressee"></param>
        public override void SetToWhat(Something prodOwner)
        {
            if (prodOwner == null)
            {
                throw new ArgumentNullException("prodOwner can not be null. A Productionrelation must point to an ProdOwner");
            }
            base.SetToWhat(prodOwner);
        }
    }
}

