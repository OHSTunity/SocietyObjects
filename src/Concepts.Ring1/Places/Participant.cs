#region Using directives
using System;
using System.Collections.Generic;
using Starcounter;
#endregion

namespace Concepts.Ring1
{
    /// <summary>
    /// A participation by a person or an organisation (a somebody) in an event.
    /// </summary>
    /// <ontology>
    /// <equal>wordnet:00889341</equal>
    /// <equal>wordnet:08131618</equal>
    /// </ontology>
    public abstract class Participant : ParticipatingThing
    {

        /// <summary>
        /// An EventUndertaking is the same as an EventParticipantRole only it is restricted to persons and organisations (somebodys).
        /// Same as WhatIs (synonym).
        /// </summary>
        [SynonymousTo("WhatIs")]
        public Somebody WhoIs;
    }
}
