using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class TunityAddressRelation : Relation
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
        public readonly TunityAddress Address;
        public void SetAddress(TunityAddress address)
        {
            SetWhatIs(address);
        }
    }
}
