using System;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// A company category could be used to categorize the
    /// company within branches.
    /// 
    /// For example, in Sweden this is the SNI-code category
    /// </summary>
    public class CompanyCategory : Category
    {
        public new class Kind : Category.Kind
        {
        }
    }
}
