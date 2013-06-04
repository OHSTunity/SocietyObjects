/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Identifier.cs#18 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Concepts.Ring2
{
    /// <summary>
    /// Identifiers (IDs) are lexical tokens that name entities. 
    /// The concept is analogous to that of a "name". Identifiers 
    /// are used extensively in virtually all information processing 
    /// systems. Naming entities makes it possible to refer to them, 
    /// which is essential for any kind of symbolic processing.
    /// <example>
    /// An Identifier can tie an attribute to an object, a search word for example.
    /// </example>
    /// 
    /// </summary>
    public class Identifier : Something
    {


        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Something.Kind
        {
            /// <summary>
            /// Make sure that a something can be identified.
            /// </summary>
            /// <param name="identifies"></param>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public virtual T Assure<T>(Something identifies, string identifier) where T : Identifier
            {
                if (this.Instantiates is T)
                {
                    T ID = Find(identifies, identifier) as T;

                    if (ID == null)
                    {
                        ID = this.New() as T;
                        ID.Identifies = identifies;
                        ID.Name = identifier;
                    }
                    return ID;
                }
                else
                {
                    throw new ApplicationException("Generic type " + typeof(T) + " is not an instance class of the given kind " + this.FullClassName);
                }                
            }

            public virtual T New<T>(Something identifies, string identifier) where T : Identifier
            {
                T ID = this.New() as T;
                ID.Identifies = identifies;
                ID.Name = identifier;
                return ID;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="identifies"></param>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public Identifier Find(Something identifies, string identifier)
            {
                Identifier ID = null;

                if (identifies != null && !String.IsNullOrEmpty(identifier))
                {
                    using (SqlEnumerator<Identifier> sqlEnumerator = Sql.GetEnumerator<Identifier>(
                        string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Identifies=variable({1}, Identifies) " +
                        "AND result.Name=variable(String, Identifier)",
                        FullInstanceClassName,
                        identifies.FullClassName)))
                    {
                        sqlEnumerator.SetVariable("Identifies", identifies as Something);
                        sqlEnumerator.SetVariable("Identifier", identifier);

                        if (sqlEnumerator.MoveNext())
                        {
                            ID = sqlEnumerator.Current;
                        } 
                    }
                }
                else
                {
                    throw new NullReferenceException(
                        String.Format(
                        "Cannot Find Identifier when provided arguments are null " +
                        "(class: {0})", Kind.GetInstance<Identifier.Kind>().FullClassName));
                }
                return ID;
            }

            /// <summary>
            /// Returns all identifiers of a someting
            /// </summary>
            /// <param name="identifies"></param>
            /// <returns></returns>
            public IEnumerable<T> GetIdentifiers<T>(Something identifies) where T : Identifier
            {
                SqlEnumerator<T> e = Sql.GetEnumerator<T>(
                    string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Identifies=variable({1}, identifies)",
                        FullInstanceClassName,
                        identifies.FullClassName));
                        //identifies);
                e.SetVariable("identifies", identifies);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var t in e)
                {
                    yield return t;
                }
            }

            /// <summary>
            /// Returns all objects that is identified by a identifier.
            /// </summary>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public IEnumerable<T> GetIdentifiers<T>(String identifier) where T : Identifier
            {
                SqlEnumerator<T> e = Sql.GetEnumerator<T>(
                    string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Name=variable(String, Identifier)",
                        FullInstanceClassName));
                        //identifier);
                e.SetVariable("Identifier", identifier);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var t in e)
                {
                    yield return t;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="identifier"></param>
            /// <returns></returns>
            public IEnumerable<Something> GetIdentifiedObjects<T>(String identifier) where T : Identifier
            {
                return from ind in GetIdentifiers<T>(identifier) select ind.Identifies;
            }

            /// <summary>
            /// Returns all objects that is identified by a identifier.
            /// </summary>
            /// <param name="identifier"></param>
            /// <param name="exactType">
            /// If true, then matches only where the datatype is exactly T (not derived from T)
            /// </param>
            /// <returns></returns>
            public IEnumerable<T> GetIdentifiers<T>(
                String identifier,
                bool exactType)
                where T : Identifier
            {
                IEnumerable<T> result;
                if (!exactType)
                {
                    result = GetIdentifiers<T>(identifier);
                }
                else
                {
                    result = GetExactIdentifiers<T>(identifier);
                }
                return result;
            }

            private IEnumerable<T> GetExactIdentifiers<T>(String identifier)
                where T : Identifier
            {
                var tKind = Of<T>();
                SqlEnumerator<T> sqlE = Sql.GetEnumerator<T>(
                    string.Format(
                        "SELECT result FROM {0} result " +
                        "WHERE result.Name=variable(String, Identifier)" +
                        "AND result.InstantiatedFrom=variable({1}, tKind)",
                        FullInstanceClassName,
                        tKind.FullClassName));
                    //identifier,
                    //tKind);
                sqlE.SetVariable("Identifier", identifier);
                sqlE.SetVariable("tKind", tKind);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var t in sqlE)
                {
                    yield return t;
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Something Identifies;

        /// <summary>
        /// Tells if this is the primary identifier for an object. This flag comes in handy when displaying only one identifier for an object.
        /// </summary>
        public bool IsPrimary;
    }
}
