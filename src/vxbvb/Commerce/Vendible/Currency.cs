/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/Currency.cs#8 $
      $DateTime: 2011/05/19 17:12:07 $
      $Change: 45322 $
      $Author: tonsan $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Starcounter;

using System.Collections;
using System.Collections.Generic;

namespace Concepts.Ring2
{
    /// <summary>
    /// Monetary currency (i.e. USD, SEK, GBP).
    /// </summary>
    /// <ontology>
    /// <equal>wordnet:</equal>
    /// <equal>sumo:</equal>
    /// </ontology>
    public class Currency : Monetary
    {
        #region Kind class
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Something.Kind"/>
        public new class Kind : Monetary.Kind
        {
            /// <summary>
            /// Symbol of the currency. E.g. $ or £.
            /// </summary>
            public String Symbol;

            /// <summary>
            /// Standard code of the currency. E.g. USD, SEK, GBP.
            /// </summary>
            public String ISOCode;

            /// <summary>
            /// Finds a currency kind using it's unique ISO code.
            /// </summary>
            /// <param name="isoCode"></param>
            /// <returns></returns>
            public virtual IEnumerable<Currency.Kind> FindKind(string isoCode)
            {
                SqlEnumerator<Currency.Kind> sqlE = Sql.GetEnumerator<Currency.Kind>(string.Format(
                    "SELECT result FROM {0} result WHERE result.ISOCode=variable(String, iSOCode)",
                    FullClassName));
                //, isoCode);
                sqlE.SetVariable("iSOCode", isoCode);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var v in sqlE)
                {
                    yield return v;
                }
            }

            /// <summary>
            /// Assures a new Currency.Kind. 
            /// </summary>
            /// <param name="symbol"></param>
            /// <param name="iSOCode"></param>
            /// <returns></returns>
            public virtual Currency.Kind AssureKind(String symbol, String iSOCode, string name)
            {
                Currency.Kind CurrencyKind = null;

                if (iSOCode != null)
                {
                    using (IEnumerator<Currency.Kind> sqlEnumerator = FindKind(iSOCode).GetEnumerator())
                    {
                        if (sqlEnumerator.MoveNext())
                        {
                            CurrencyKind = sqlEnumerator.Current;
                        }
                    }

                    if (CurrencyKind == null)
                    {
                        CurrencyKind = Kind.GetInstance<Currency.Kind>().Derive() as Currency.Kind;
                        if (symbol != null)
                        {
                            CurrencyKind.Symbol = symbol;
                        }
                        CurrencyKind.ISOCode = iSOCode;
                        CurrencyKind.Name = name;
                    }
                    /*else // Why set symbol to a already existing currency.kind ? TonySa 20110519
                    {
                        if (symbol != null)
                        {
                            CurrencyKind.Symbol = symbol;
                        }
                    }*/
                }
                else
                {
                    throw new Exception("ISOCode missing, cannot create new currency");
                }

                return CurrencyKind;
            }
        }
        #endregion

    }
}
