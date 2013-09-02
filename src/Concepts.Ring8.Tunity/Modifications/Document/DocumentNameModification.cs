/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/Accessible.cs#2 $
      $DateTime: 2008/12/12 07:46:28 $
      $Change: 17466 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring4;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentNameModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public DocumentNameModification(DateTime time, Person modifier, Document doc, String oldName):
            base(time, modifier, ModificationType.DOCUMENT)
        {
            Document = doc;
            NewDocumentName = doc.Name;
            OldDocumentName = oldName;
            AddTarget(doc);
        }


        [SynonymousTo("Data")]
        public readonly Document Document;

        public readonly String NewDocumentName;
        
        [SynonymousTo("Description")]
        public readonly String OldDocumentName;

        public override String ShortDescription
        {
            get
            {
                return"";// String.Format(
                      // Yesugi.ResourceManager.GetString("Modification.DocumentName{0}"),
                      // NewDocumentName);
            }
        }
        
        public override String LongDescription
        {
            get
            {
                return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.DocumentName{0}{1}"),
                    //OldDocumentName, NewDocumentName);
            }
        }

       
    }
}
