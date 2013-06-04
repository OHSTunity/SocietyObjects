using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;
using System.Collections;

namespace Concepts.Ring2
{
    public class MeansOfPayment : Something
    {
        public new class Kind : Something.Kind 
        {
            /// <summary>
            /// The currency of this means of payment,
            /// </summary>
            public Currency.Kind Currency;

            /// <summary>
            /// Gets or sets the maximum amount allowed, using this payment method
            /// </summary>
            public Decimal MaxAmount;

            /// <summary>
            /// Gets or sets a value deciding how to round off payments of this kind. E.g 0.01, 0.50, 1
            /// </summary>
            public Decimal RoundTo;

            /// <summary>
            /// Get or set a value indicating whether or not it is allows to give money back using this payment method.
            /// </summary>
            public bool AllowMoneyBack;

            /// <summary>
            /// Get or set a value indicating whether or not a specified buyer i required to use this payment method.
            /// </summary>
            public bool SpecifiedBuyerRequiredForUse;

            /// <summary>
            /// Get or set a value indicating whether or not it is allowed to change amount using this payment method. 
            /// </summary>
            public bool AllowChangeAmount;

            /// <summary>
            /// Return first found MeansOfPayment.Kind or null
            /// </summary>
            /// <param name="name">The name of the MeansOfPayment.Kind to be found</param>
            /// <returns></returns>
            public static MeansOfPayment.Kind GetByName(String name)
            {
                MeansOfPayment.Kind meansOfPaymentKind = null;

                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT result FROM Concepts.Ring2.MeansOfPayment.Kind result WHERE result.Name=variable(String, name)"))
                {
                    sqlEnumerator.SetVariable("name", name);
                    if (sqlEnumerator.MoveNext())
                    {
                        meansOfPaymentKind = sqlEnumerator.Current as MeansOfPayment.Kind;
                    } 
                }
                return meansOfPaymentKind;
            }

            public static IEnumerable GetAll() 
            {
                SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT result FROM Concepts.Ring2.MeansOfPayment.Kind result WHERE NOT result = variable(Concepts.Ring2.MeansOfPayment.Kind, hardKind)");
                sqlEnumerator.SetVariable("hardKind", Kind.GetInstance<MeansOfPayment.Kind>());

                // By using yield return we make sure that the enumerator is disposed
                foreach (var v in sqlEnumerator)
                {
                    yield return v;
                }
            }
        }
    }
}
