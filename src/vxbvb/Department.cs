#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter; 
#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// A department in another department or company.
    /// </summary>
    public class Department : Somebody
    {
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        public new class Kind : Somebody.Kind { }

        /// <summary>
        /// Sets owner of this department.
        /// </summary>
        /// <param name="department">Owner</param>
        public void SetOwner(Department department)
        {
            Owner = department;
        }

        /// <summary>
        /// Sets owner of this department,
        /// </summary>
        /// <param name="company">Owner</param>
        public void SetOwner(Company company)
        {
            Owner = company;
        }
    }
}