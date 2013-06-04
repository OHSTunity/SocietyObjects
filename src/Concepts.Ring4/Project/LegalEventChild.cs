using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring4
{
	public class LegalEventChild : EventRole
	{
		public new class Kind : EventRole.Kind 
		{
			[SynonymousTo("Subset")]
			public Event.Kind ChildEventKind;
		}

		[SynonymousTo("WhatIs")]
		public readonly Event ChildEvent;
        public void SetChildEvent(Event childEvent)
        {
            SetWhatIs(childEvent);
        }
	}
}
