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
    public class DocumentDetailsModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public DocumentDetailsModification(DateTime time, Person modifier, Document doc):
            base(time, modifier, ModificationType.DOCUMENT)
        {
            Document = doc;
            if (Document != null)
            {
                AddTarget(doc);
            }
        }


        [SynonymousTo("Data")]
        public readonly Document Document;

        public override String ShortDescription
        {
            get
            {
                return "";//"";// String.Format(
                        //Yesugi.ResourceManager.GetString("Modification.DocumentDetails"));
            }
        }
        
        public override String LongDescription
        {
            get
            {
                return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.DocumentDetails{0}"),
                   // Document.Name);
            }
        }

    
    }
}
