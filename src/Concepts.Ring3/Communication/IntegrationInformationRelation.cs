using System;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring3
{
    public class IntegrationInformationRelation:Relation
    {
        public new class Kind : Relation.Kind
        {
        }
        [SynonymousTo("WhatIs")]
        public readonly IntegrationInformation Information;
        public void SetInformation(IntegrationInformation information)
        {
            SetWhatIs(information);
        }

        public IntegrationInformation Ballajsans;

        
        [SynonymousTo("ToWhat")]
        public readonly Something InformationAbout;
        public void SetInformationAbout(Something informationAbout)
        {
            SetToWhat(informationAbout);
        }
    }
}
