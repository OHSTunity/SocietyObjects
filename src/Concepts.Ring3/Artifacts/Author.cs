/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Artifacts/Author.cs#15 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring1;
using Starcounter;
using System;
using Concepts.Ring2;
using System.Collections.Generic;


namespace Concepts.Ring3
{
    // TODO, shall the author inherit Creator?
    /// <summary>
    /// 
    /// </summary>
    public class Author : SomebodiesRelation
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : SomebodiesRelation.Kind
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="somebody"></param>
            /// <param name="literaryWorkKind"></param>
            /// <returns></returns>
            public Author Assure(Somebody somebody, LiteraryWork.Kind literaryWorkKind)
            {
                return Relate<Author>(somebody, literaryWorkKind);
            }

            /// <summary>
            /// Creators of a Artifact.Kind
            /// </summary>
            /// <param name="literaryWorkKind"></param>
            /// <returns></returns>
            public IEnumerable<Author> GetAuthors(LiteraryWork.Kind literaryWorkKind)
            {
                using (SqlEnumerator<Author> enumerator = Sql.GetEnumerator<Author>(
                    string.Format(
                            "SELECT authors FROM {0} authors " +
                            "WHERE authors.LiteraryWorkKind=variable({1},literaryWorkKind)",
                            new object[] { Kind.GetInstance<Author.Kind>().FullInstanceClassName, 
                                           Kind.GetInstance<Artifact.Kind>().FullClassName })))
                {
                    enumerator.SetVariable("literaryWorkKind", literaryWorkKind);
                    // By using yield return we make sure that the enumerator is disposed
                    foreach (var v in enumerator)
                    {
                        yield return v;
                    }
                }
            }

        }

        #endregion

        /// <summary>
        /// The literary work that someone is author of.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly LiteraryWork.Kind LiteraryWorkKind;
        public void SetLiteraryWorkKind(LiteraryWork.Kind literaryWorkKind)
        {
            SetToWhat(literaryWorkKind);
        }

        public String AuthorAsString
        {
            get
            {
                if (WhoIs != null)
                {
                    return ToSelectorString();
                }
                else
                {
                    return Name;
                }
            }
        }
        

        public override string ToSelectorString()
        {
            //TODO: translate
            if (WhoIs is Person)
            {
                return "Author " + (WhatIs as Person).FullName;
            }
            else
            {
                return "Author " + (this.WhatIs as Somebody).ToSelectorString();
            }
        }
    }
}
