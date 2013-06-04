using System;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
	/// <summary>
	/// A company ca be a subsidiary of another company.
	/// </summary>
	public class Subsidiary : SomebodiesRelation
	{
		
        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Company DaughterCompany;
        public void SetDaughterCompany(Company daughterCompany)
        {
            SetWhatIs(daughterCompany);
        }

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Company MotherCompany;
        public void SetMotherCompany(Company motherCompany)
        {
            SetToWhat(motherCompany);
        }
	}
}
