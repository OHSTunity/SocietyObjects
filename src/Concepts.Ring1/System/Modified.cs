// Move to Ring1.System subfolder

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring1
{
    public class Modified : ParticipatingThing
    {
       
        [SynonymousTo("ToWhat")]
        public readonly Modification Modification;
        public void SetModification(Modification modification)
        {
            SetToWhat(modification);
        }

        [SynonymousTo("WhatIs")]
        public readonly Something ModifiedObject;
        public void SetModifiedObject(Something modifiedObject)
        {
            SetWhatIs(modifiedObject);
        }

        public Concepts.Ring1.Attribute Attribute;

        public string OldValue;

        public string NewValue;
    }
}
