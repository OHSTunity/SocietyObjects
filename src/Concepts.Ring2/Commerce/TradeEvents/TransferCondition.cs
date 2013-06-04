using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Starcounter;
using System.Resources;

namespace Concepts.Ring2
{
    public class TransferCondition : Something
    {
        /* TODO
        public new class Kind : Something.Kind 
        {

            public class PreparedStatements
            {
                public static readonly SqlPrepared FindTypes;

                public const string DerivedFromIndexField = "derivedFrom";

                static PreparedStatements()
                {
                    string query = string.Format(
                        "SELECT tc FROM {0} tc WHERE tc.DerivedFrom=VAR({0}, {1})",
                        Kind.GetInstance<TransferCondition.Kind>().FullClassName,
                        DerivedFromIndexField);

                    FindTypes = Sql.GetPrepared(query);
                }
            }

            public IEnumerable<TransferCondition.Kind> ConditionTypes
            {
                get
                {
                    using (SqlEnumerator<TransferCondition.Kind> e = Sql.GetEnumerator<TransferCondition.Kind>(TransferCondition.Kind.PreparedStatements.FindTypes))
                    {
                        e.SetVariable(TransferCondition.Kind.PreparedStatements.DerivedFromIndexField, Something.Kind.GetInstance<TransferCondition.Kind>());
                        return e;
                        //foreach (var tc in e)
                        //{
                        //    if (tc.DerivedFrom == Something.Kind.GetInstance<TransferCondition.Kind>())
                        //    {
                        //        yield return tc;
                        //    }
                        //} 
                    }
                }
            }
        }
         * */
    }
}
