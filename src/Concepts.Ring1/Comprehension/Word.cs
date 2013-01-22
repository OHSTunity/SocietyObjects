
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;


namespace Concepts.Ring1
{
    /// <summary>
    /// A word in a specific language
    /// </summary>
    public class Word : Something
    {

        public static readonly char[] SplitChars;

        static Word()
        {
            SplitChars = new char[] { 
                ' ', '.', ',', '-', '+', ':', ';', '\t', '@', '\r', '\n', 
                '\'', '?', '!', '#', '¤', '%', '&', '/', '(', ')', '=', 
                '´', '`', '^', '\\', '<', '>', '½', '§', '\"'};
        }

        /// <summary>
        /// The language of the word
        /// </summary>
        public Language Language;

        /// <summary>
        /// The word itself (as spelled in the language of the word).
        /// </summary>
        public String Lemma;

        /// <summary>
        /// An example of the pronounciation of the word.
        /// </summary>
        public string AudioPronounciationsURL;

        /// <summary>
        /// An estimation of the number of search results that would result from a web search.
        /// </summary>
        public long EstimatedWebSearchResults;

        /// <summary>
        /// A counter for meassuring how often this word occures.
        /// </summary>
        public uint OccurenceCount;

        public override string ToString()
        {
            return string.Format("[{0}], {1}, Occurance={2}", ObjectID, Lemma, OccurenceCount);
        }

        public override string ToSelectorString()
        {
            return ToString();
        }
    }
}
