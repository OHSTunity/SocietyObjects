using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class OrderCompanyRelation : Relation
    {
       

        [SynonymousTo("ToWhat")]
        public readonly Company Company;
        public void SetCompany(Company company)
        {
            SetToWhat(company);
        }



        /// <summary>
        /// The Production that belongs to a owner
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly ProductionOrder ProductionOrder;
        public void SetProductionOrder(ProductionOrder p)
        {
            SetWhatIs(p);
        }
    }
}
