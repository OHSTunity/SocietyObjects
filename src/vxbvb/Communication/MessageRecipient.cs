#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
#endregion

namespace Concepts.Ring2
{
    public class MessageRecipient : ParticipatingThing
    {
        public new class Kind : ParticipatingThing.Kind { }
    }
}
