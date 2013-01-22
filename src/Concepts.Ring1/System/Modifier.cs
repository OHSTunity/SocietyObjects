// Move to Ring1.System subfolder
using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    public class Modifier : Participant
    {
        
        [SynonymousTo("ToWhat")]
        public readonly Modification Modification;
        public void SetModification(Modification modification)
        {
            SetToWhat(modification);
        }
        
        [SynonymousTo("WhatIs")]
        public readonly Something ModifierObject;
        public void SetModifierObject(Something modifierObject)
        {
            SetWhatIs(modifierObject);
        }

    }
}
