using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Threading;

namespace Concepts.Ring1
{
    /// <summary>
    /// 
    /// </summary>
    
    /* TODO public abstract class HasWord : Entity, IObjectIDProvider
    {        
        /// <summary>
        /// Returns the relation between something and word where the attribute matches, if it exists.
        /// If you are going to call Get many times in a row, consider creating a SearchHelper-instance and call the Get-method
        /// on the SearchHelper, this is because the search helper reuses the Sql-Enumerator
        /// </summary>
        /// <param name="something"></param>
        /// <param name="word"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static HasWord Get(Something something, Word word, WordIndexAttribute attribute)
        {
            //TODO: Make this work
            // Get the correct has word relation
            return default(HasWord);
        }

        public HasWord(Word word, Something wordOwner, WordIndexAttribute attribute)
        {
            Word = word;
            Something = wordOwner;
            Attribute = attribute;
        }

        ///// <summary>
        ///// The word representing the something.
        ///// </summary>
        public readonly Word Word;

        /// <summary>
        /// The something that has the word.
        /// </summary>
        public readonly Something Something;

        /// <summary>
        /// The attribute containing the word.
        /// </summary>
	    public readonly WordIndexAttribute Attribute;

        internal byte _index;
        /// <summary>
        /// Tells the position of the word in the whole context. If the position is larger than 8 it will be 8.
        /// </summary>
        [SynonymousTo("_index")]
        public readonly byte Index;


        #region IObjectIDProvider Members

        public ulong ObjectID
        {
            get { return DbHelper.GetObjectID(this); }
        }

        #endregion

        public static HasWordTypeHandle GetHandle<THasWordType>()
            where THasWordType : HasWord
        {
            return GetHandle(typeof(THasWordType));
        }

        public static HasWordTypeHandle GetHandle(Type hasWordType)
        {
            return HasWordTypeHandle.GetHandle(hasWordType);
        }

    }
     */
}
