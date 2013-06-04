using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3;
using Starcounter;


namespace Concepts.Ring3
{
    public class Publisher : Relation
    {
        
        [SynonymousTo("WhatIs")]
        public readonly Somebody WhoIs;
        public void SetWhoIs(Somebody whoIs)
        {
            SetWhatIs(whoIs);
        }

        [SynonymousTo("ToWhat")]
        public readonly LiteraryWork LiteraryWork;
        public void SetLiteraryWork(LiteraryWork literaryWork)
        {
            SetToWhat(literaryWork);
        }

        public override string ToSelectorString()
        {
            //TODO: translate
            if (WhoIs is Person)
            {
                return "Publisher " + (WhatIs as Person).FullName;
            }
            else
            {
                return "Publisher " + WhoIs.ToSelectorString();
            }
        }
    }
}
