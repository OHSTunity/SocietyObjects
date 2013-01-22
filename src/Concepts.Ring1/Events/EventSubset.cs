using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    public abstract class EventSubset : EventRole
    {
      
		/// <summary>
		/// The event the subset event is part of
		/// </summary>
		[SynonymousTo("ToWhat")]                            
        public readonly Event PartOf;
        public void SetPartOf(Event partOf)
        {
            SetToWhat(partOf);
        }


		/// <summary>
		/// If the events are to be in a specific order
		/// </summary>
		public Int32 Order;
    }
}
