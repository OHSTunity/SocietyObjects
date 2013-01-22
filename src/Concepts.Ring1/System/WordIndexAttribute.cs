/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/System/WordIndexAttribute.cs#8 $
      $DateTime: 2009/10/16 14:20:48 $
      $Change: 26208 $
      $Author: careri $
      =========================================================
*/


using Starcounter;
using System.Collections.Generic;
using System;
namespace Concepts.Ring1
{
    /// <summary>
    /// A specialization of attribute that is used in the WordIndex-service
    /// </summary>
   /* TODO
    * public abstract class WordIndexAttribute : Attribute
    {
        private class PreparedStatements
        {
            internal readonly SqlPrepared Somethings;
            internal readonly SqlPrepared HasWordsByWord;
            internal readonly SqlPrepared Words;
            internal readonly SqlPrepared HasWords;
            internal readonly SqlPrepared AllHasWordsForAttribute;
            internal const string AttributeField = "attribute";
            internal const string WordField = "word";
            internal const string SomethingField = "something";

            internal PreparedStatements(HasWordTypeHandle handle)
            {
                Type hasWordType = handle.HasWordType;
                Somethings = Sql.GetPrepared(string.Format(
                    "SELECT hw.Something FROM {0} hw WHERE hw.Word=VAR({3}, {4}) AND hw.AttributeKind=VAR({1}, {2})",
                    SqlNamespaceHelper.GetSafe(hasWordType),
                    Kind.GetInstance<WordIndexAttribute.Kind>().FullClassName,
                    AttributeField,
                    Kind.GetInstance<Word.Kind>().FullInstanceClassName,
                    WordField));

                HasWordsByWord = Sql.GetPrepared(string.Format(
                    "SELECT hw FROM {0} hw WHERE hw.Word=VAR({3}, {4}) AND hw.AttributeKind=VAR({1}, {2})",
                    SqlNamespaceHelper.GetSafe(hasWordType),
                    Kind.GetInstance<WordIndexAttribute.Kind>().FullClassName,
                    AttributeField,
                    Kind.GetInstance<Word.Kind>().FullInstanceClassName,
                    WordField));

                Words = Sql.GetPrepared(string.Format(
                    "SELECT hw.Word FROM {0} hw WHERE hw.Something=VAR({3}, {4}) AND hw.AttributeKind=VAR({1}, {2})",
                    SqlNamespaceHelper.GetSafe(hasWordType),
                    Kind.GetInstance<WordIndexAttribute.Kind>().FullClassName,
                    AttributeField,
                    Kind.GetInstance<Something.Kind>().FullInstanceClassName,
                    SomethingField));

                HasWords = Sql.GetPrepared(string.Format(
                    "SELECT hw FROM {0} hw WHERE hw.Something=VAR({3}, {4}) AND hw.AttributeKind=VAR({1}, {2}) Order By hw.[Index]",
                    SqlNamespaceHelper.GetSafe(hasWordType),
                    Kind.GetInstance<WordIndexAttribute.Kind>().FullClassName,
                    AttributeField,
                    Kind.GetInstance<Something.Kind>().FullInstanceClassName,
                    SomethingField));

                AllHasWordsForAttribute = Sql.GetPrepared(string.Format(
                   "SELECT hw FROM {0} hw WHERE hw.AttributeKind=VAR({1}, {2})",
                   SqlNamespaceHelper.GetSafe(hasWordType),
                   Kind.GetInstance<WordIndexAttribute.Kind>().FullClassName,
                   AttributeField));
            }
        }

        public new class Kind : Attribute.Kind
        {
            private static readonly Dictionary<ulong, PreparedStatements> PreparedStatementsPerHasWord = 
                new Dictionary<ulong,PreparedStatements>();

            private PreparedStatements GetPreparedStatements()
            {
                var hasWordHandle = _CustomHasWordKind;
                PreparedStatements statements = null;
                ulong objectID = hasWordHandle.ObjectID;

                if (!PreparedStatementsPerHasWord.TryGetValue(objectID, out statements))
                {
                    statements = new PreparedStatements(hasWordHandle);
                    PreparedStatementsPerHasWord[objectID] = statements;
                }

                return statements;
            }

            public T AssureKind<T>(
                string name, 
                Something.Kind ownerKind, 
                Something.Kind valueKind, 
                bool isSplit)
                where T : WordIndexAttribute.Kind
            {
                T attributeKind = AssureKind<T>(name, ownerKind, valueKind);
                attributeKind._isSplit = isSplit;
                return attributeKind;
            }

            /// <summary>
            /// All hasword relations for this attribute. 
            /// </summary>
            public SqlEnumerator<HasWord> HasWordRelations
            {
                get
                {
                    SqlEnumerator<HasWord> relations = Sql.GetEnumerator<HasWord>(GetPreparedStatements().AllHasWordsForAttribute);
                    relations.SetVariable(PreparedStatements.AttributeField, this);
                    return relations;
                }
            }

            private HasWordTypeHandle _CustomHasWordKind;

            /// <summary>
            /// Its possible for an attribute to define its own has word relation kind, by using a custom relation
            /// you narrow down the instances you have to search amongst.
            /// The value can only be set once.
            /// </summary>
            public HasWordTypeHandle CustomHasWordKind
            {
                get { return _CustomHasWordKind; }
                set
                {
                    if (_CustomHasWordKind == null)
                    {
                        _CustomHasWordKind = value;
                    }
                }
            }

            /// <summary>
            /// Returns all words connected to the given attribute where the word starts with 'searchword'
            /// </summary>
            /// <param name="searchWord"></param>
            /// <returns></returns>
            public IEnumerable<Word> GetWords(string searchWord)
            {
                return GetWords(searchWord, false);
            }

            /// <summary>
            /// Returns all words connected to the given attribute, if isExactMatch is true only words that are exactly
            /// the given search string will be returned and if false all words starting with searchWord is returned.
            /// </summary>
            /// <param name="searchWord"></param>
            /// <returns></returns>
            public IEnumerable<Word> GetWords(string searchWord, bool isExactMatch)
            {
                HashSet<Word> words = new HashSet<Word>();

                foreach (HasWord hw in HasWordRelations)
                {
                    Word word = hw.Word;

                    if (isExactMatch)
                    {
                        if (word.Lemma.StartsWith(searchWord, global::System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            words.Add(word);
                        }
                    }
                    else
                    {
                        if (word.Lemma.Equals(searchWord, global::System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            words.Add(word);
                        }
                    }
                }

                return words;
            }

            /// <summary>
            /// Returns all somethings that has the given word for this attribute.
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public SqlEnumerator<Something> GetSomethings(Word word)
            {
                SqlEnumerator<Something> somethingE = Sql.GetEnumerator<Something>(GetPreparedStatements().Somethings);
                somethingE.SetVariable(PreparedStatements.AttributeField, this);
                somethingE.SetVariable(PreparedStatements.WordField, word);
                return somethingE;
            }

            /// <summary>
            /// Returns all somethings that has the given word for this attribute.
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public SqlEnumerator<Word> GetWords(Something wordOwner)
            {
                SqlEnumerator<Word> somethingE = Sql.GetEnumerator<Word>(GetPreparedStatements().Words);
                somethingE.SetVariable(PreparedStatements.AttributeField, this);
                somethingE.SetVariable(PreparedStatements.SomethingField, wordOwner);
                return somethingE;
            }

            /// <summary>
            /// Returns all has word relation that has the given owner for this attribute. The relations are sorted on index.
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public SqlEnumerator<HasWord> GetWordRelationsByOwner(Something wordOwner)
            {
                SqlEnumerator<HasWord> somethingE = Sql.GetEnumerator<HasWord>(GetPreparedStatements().HasWords);
                somethingE.SetVariable(PreparedStatements.AttributeField, this);
                somethingE.SetVariable(PreparedStatements.SomethingField, wordOwner);
                return somethingE;
            }

            /// <summary>
            /// Returns all has word relation that has the given word for this attribute.
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public SqlEnumerator<HasWord> GetWordRelationsByWord(Word word)
            {
                SqlEnumerator<HasWord> somethingE = Sql.GetEnumerator<HasWord>(GetPreparedStatements().HasWordsByWord);
                somethingE.SetVariable(PreparedStatements.AttributeField, this);
                somethingE.SetVariable(PreparedStatements.WordField, word);
                return somethingE;
            }

            /// <summary>
            /// Creates a new has word relation for this attribute between the something and word.
            /// </summary>
            /// <param name="something"></param>
            /// <param name="word"></param>
            /// <returns></returns>
            internal HasWord NewRelation(Something something, Word word)
            {
                var hasWordHandle = _CustomHasWordKind;
                return hasWordHandle.New(word, something, this);
            }

            private bool _isSplit;
            /// <summary>
            /// Tells if values for this attribute shall be splitted.
            /// </summary>
            [SynonymousTo("_isSplit")]
            public readonly bool IsSplit;

            /// <summary>
            /// Tells if this attribute is bound to a kind or the instance class
            /// </summary>
            public virtual bool IsInstanceAttribute { get { return false; } }
        }
    }
    * */
}
