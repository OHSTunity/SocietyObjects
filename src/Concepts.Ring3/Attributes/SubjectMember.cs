using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3
{
    /// <summary>
    /// Makes something a member of a subject
    /// </summary>
    public class SubjectMember : Relation
    {
        public new class Kind : Relation.Kind
        {
        }

        [SynonymousTo("ToWhat")]
        public readonly Subject Subject;

        public void SetSubject(Subject subject)
        {
            SetToWhat(subject);
        }
    }
}
