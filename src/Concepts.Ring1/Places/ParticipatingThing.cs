using Starcounter;

namespace Concepts.Ring1
{
	/// <summary>
	/// Describes <c>Something</c>'s role to a certain <c>Event</c>.
	/// </summary>
    public abstract class ParticipatingThing : Relation
    {

		/// <summary>
        /// Same as the ToWhat attribute (synonym).
        /// </summary>
        [SynonymousTo("ToWhat")]
        public Event ParticipatesIn;
        
        /// <summary>
        /// Same as the WhatIs attribute (synonym).
        /// </summary>
		[SynonymousTo("WhatIs")]
		public Something Participant;
    }
}