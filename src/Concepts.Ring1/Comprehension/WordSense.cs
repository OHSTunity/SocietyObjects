using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;


namespace Concepts.Ring1
{
    /// <summary>
    /// How a word relates to a concept.
    /// </summary>
    public class WordSense : Relation
    {
        /// <summary>
        /// A word relating to a concept. Same as WhatIs (synonym).
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Word Word;
        public void SetWord(Word word)
        {
            SetWhatIs(word);
        }

        /// <summary>
        /// A concept related to the word. Same as ToWhat (synonym).
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Something Concept;
        public void SetConcept(Something concept)
        {
            SetToWhat(concept);
        }

        /// <summary>
        /// The rank of this meaning in relation to other meanings for the Word.
        /// </summary>
        /// <remarks>
        /// A single word may have many meanings (wordsenses). This number sorts the more common
        /// ones from the less common ones. The higher the number, the less common the use of the
        /// word is.
        /// </remarks>
        public int Rank;
    }
}
