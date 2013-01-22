using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// 
    /// </summary>
    /// TODO: Review joawes
    public abstract class EventRole : Relation
    {
		/// <summary>
		/// The superior event
		/// </summary>
		[SynonymousTo("ToWhat")]
		public readonly Event Superset;
        public void SetSuperSet(Event superSet)
        {
            SetToWhat(superSet);
        }

		/// <summary>
		/// The subset event
		/// </summary>
		[SynonymousTo("WhatIs")]
		public readonly Event Subset;
        public void SetSubSet(Event subSet)
        {
            SetWhatIs(subSet);
        }
	}
}
