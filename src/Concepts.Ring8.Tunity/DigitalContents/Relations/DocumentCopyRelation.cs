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
    /// A relation between a document and the document/version the document was copied from.
    /// Just exists when a document has been copied.
    /// </summary>
    public class DocumentCopyRelation : Relation
    {
       
        public DocumentCopyRelation()
        {
        }

        public DocumentCopyRelation(Version source, Document doc)
        {
            SetSource(source);
            SetDocument(doc);
        }

        /// <summary>
        /// The source of the copy
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Version Source;
        public void SetSource(Version version)
        {
            SetToWhat(version);
        }

        /// <summary>
        /// The new document that is a copy of the source version
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Document Document;
        public void SetDocument(Document document)
        {
            SetWhatIs(document);
        }

        /// <summary>
        /// Not used everywhere
        /// </summary>
        public Version Destination;

    }
}

