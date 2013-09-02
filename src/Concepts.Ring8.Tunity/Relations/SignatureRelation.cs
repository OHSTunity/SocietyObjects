using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class SignatureRelation : Relation
    {
        
        [SynonymousTo("ToWhat")]
        public readonly Somebody Somebody;
        public void SetSomebody(Somebody s)
        {
            SetToWhat(s);
        }



        /// <summary>
        /// The Production that belongs to a owner
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly VersionDataFile DataFile;
        public void SetDataFile(VersionDataFile p)
        {
            SetWhatIs(p);
        }
    }
}
