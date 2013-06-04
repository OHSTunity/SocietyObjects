/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Artifacts/Artifact.cs#15 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using System.Collections.Generic;


namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Artifact : Something
    {
        #region Kind

        public new class Kind : Something.Kind
        {
            /// <summary>
            /// The creator of this artifact.
            /// The creator can be a group that references many creators.
            /// </summary>
            public Creator Creator;
            
            /// <summary>
            /// The name the creator has choosen for this artifact.
            /// </summary>
            public String CreatorsName;
            
            /// <summary>
            /// The ID the creator uses to refer to this artifact.
            /// </summary>
            public String CreatorsModelID;
            
            /// <summary>
            /// The creators Description for this artifact.
            /// </summary>
            public String CreatorsDescription;
            
            /// <summary>
            /// The unique identifier of this artificat. (EAN).
            /// </summary>
            public String GTIN;
            public T AssureByGTIN<T>(string gtin) where T : Artifact.Kind
            {
                T lw;
                string query = String.Format(
                    "SELECT ak "+ 
                    "FROM {0} ak "+
                    "WHERE ak.GTIN=VAR(String,gtin)",
                    FullClassName);

                using (SqlEnumerator<T> e = Sql.GetEnumerator<T>(query))
                {
                    e.SetVariable("gtin", gtin);
                    if (e.MoveNext())
                    {
                        return e.Current;
                    }
                    lw = Derive() as T;
                    lw.GTIN = gtin; 
                }
                return lw;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="id"></param>
            /// <returns></returns>
            public IEnumerable<T> GetKindsByID<T>(string id) where T : Artifact.Kind
            {
                string query = string.Format(
                    "SELECT a FROM {0} a WHERE a.CreatorsModelID=VAR(String, id)",
                    FullClassName);
                SqlEnumerator<T> e = Sql.GetEnumerator<T>(query); //, id);
                e.SetVariable("id", id);

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
            /// <param name="name"></param>
            /// <returns></returns>
            public IEnumerable<T> GetKindsByName<T>(string name) where T : Artifact.Kind
            {
                string query = string.Format(
                    "SELECT a FROM {0} a WHERE a.Name=VAR(String, id)",
                    FullClassName);
                SqlEnumerator<T> e = Sql.GetEnumerator<T>(query); //, name);
                e.SetVariable("id", name);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var v in e)
                {
                    yield return v;
                }
            }
        }

        #endregion


        // TODO, check name
        /// <summary>
        /// Serialno of the manufacturer of this piece of goods, if any.
        /// </summary>
        /// <remarks>
        /// The serial number is the identification of an individual piece of goods or a
        /// batch of goods. It is the number or text used by the manufacturer of this specific
        /// piece of goods or the original supplier of the service.
        /// </remarks>
        public string SerialId;

        // TODO, shall the artifact have a location. Or is this done through relations?
        /// <summary>
        /// The current physical place of this piece of goods. The place may also be a
        /// Package if this goods is contained in a box or any other container.
        /// </summary>
        //public AssetDepot Address;
    }
}
