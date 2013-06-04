using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    public abstract class DocumentItem : Relation
    {
        public new class Kind : Relation.Kind { }
        
        [SynonymousTo("ToWhat")]
        public readonly Somebody ToWhom;
        public void SetToWhom(Somebody toWhom)
        {
            SetToWhat(toWhom);
        }

        /// <summary>
        /// This propery should be readonly.Use SetDocument(Document doc) instead
        /// </summary>
        public Document Document;

        public virtual void SetDocument(Document doc)
        {
            Document = doc;
        }

    }
}
