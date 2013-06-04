using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring4
{
	public class LegalEventParent : EventRole
	{
		public new class Kind : EventRole.Kind 
		{
			[SynonymousTo("Superset")]
			public Event.Kind ParentEventKind;
		}

		[SynonymousTo("ToWhat")]
		public readonly Event ParentEvent;
        public void SetParentEvent(Event parentEvent)
        {
            SetToWhat(parentEvent);
        }
	}
}
