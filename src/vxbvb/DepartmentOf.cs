using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// Defines the relation between a Department and a Somebody
    /// </summary>
    public abstract class DepartmentOf : SomebodiesRelation   
    {
        public new class Kind : SomebodiesRelation.Kind 
        { 
        }

        /// <summary>
        /// The Department that is part of another somebody.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Department Department;
        public void SetDepartment(Department department)
        {
            SetWhatIs(department);
        }
    }
}
