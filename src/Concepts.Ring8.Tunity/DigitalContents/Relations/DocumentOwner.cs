/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/DocumentRelation.cs#2 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring4;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Relation for something that owns a document. (Example a projectEvent)
    /// </summary>
    public class DocumentOwner : Relation
    {
      
        public DocumentOwner()
        {
        }

        public DocumentOwner(Something owner, Document doc)
        {
            SetWhatIs(owner);
            SetDocument(doc);
        }

        /// <summary>
        /// The Document that belongs to a owner
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Document Document;
        public void SetDocument(Document document)
        {
            SetToWhat(document);
        }

    }
}

