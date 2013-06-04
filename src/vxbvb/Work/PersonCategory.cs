using System;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// A person category could be used to categorize the
    /// persons.
    /// 
    /// </summary>
    public class PersonCategory : Category
    {
        public new class Kind : Category.Kind
        {
        }
    }
}
