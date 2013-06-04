using System;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3
{
    public class IntegrationInformation:Something
    {
        public new class Kind : Something.Kind
        {
            [SynonymousTo("Name")]
            public String IntegrationName;
        }

        [SynonymousTo("Description")]
        public String IntegrationData;
    }
}
