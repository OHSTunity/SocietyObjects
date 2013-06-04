/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/TradeAssortment.cs#8 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring2
{
    /// <summary>
    /// Type representing a definition of what kind of vendible 
    /// can be used when a consumer relation is used.
    /// </summary>
    public class TradeAssortment : Relation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Relation.Kind"/>
        public new class Kind : Relation.Kind
        {
            public TradeAssortment Assure( Vendible vendible, Consumer consumer)
            {
                TradeAssortment assortment = Find(vendible, consumer);

                if (assortment == null)
                {
                    assortment = new TradeAssortment();
                    assortment.SetVendible(vendible);
                    assortment.SetAssortmentParts(consumer);
                }

                return assortment;
            }

            public TradeAssortment Find( Vendible vendible, Consumer consumer)
            {
                TradeAssortment assortment = null;

                //Find all consumer roles where somebody id WhoIs
                String query = "SELECT ta FROM " + TradeAssortment.Kind.GetInstance<TradeAssortment.Kind>().FullInstanceClassName + " ta "
                           + "WHERE "
                           + "      ta.WhatIs=variable(" + Something.Kind.GetInstance<Something.Kind>().FullInstanceClassName + ", vendible) AND "
                           + "      ta.ToWhat=variable(" + Consumer.Kind.GetInstance<Consumer.Kind>().FullInstanceClassName + ", consumer)";

                using (SqlEnumerator sqlEnum = Sql.GetEnumerator(query))
                {
                    sqlEnum.SetVariable("vendible", vendible);
                    sqlEnum.SetVariable("consumer", consumer);

                    while (sqlEnum.MoveNext())
                    {
                        assortment = sqlEnum.Current as TradeAssortment;
                    } 
                }

                return assortment;
            }
        }

        #endregion

        /// <summary>
        /// Vendible in this relation.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Vendible Vendible;
        public void SetVendible(Vendible vendible)
        {
            SetWhatIs(vendible);
        }

        /// <summary>
        /// Consumer relation that defines between part the tradeble can
        /// be used
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Consumer AssortmentParts;
        public void SetAssortmentParts(Consumer assortmentParts)
        {
            SetToWhat(assortmentParts);
        }
    }
}
