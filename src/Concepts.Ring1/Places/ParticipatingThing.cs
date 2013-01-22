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
        public readonly Event ParticipatesIn;
        public void SetParticipatesIn(Event participatesIn)
        {
            SetToWhat(participatesIn);
        }

        /// <summary>
        /// Same as the WhatIs attribute (synonym).
        /// </summary>
		[SynonymousTo("WhatIs")]
		public readonly Something Participant;
        public void SetParticipant(Something participant)
        {
            SetWhatIs(participant);
        }

    }
}