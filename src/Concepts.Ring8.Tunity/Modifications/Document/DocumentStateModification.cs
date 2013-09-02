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
    public class DocumentStateModification: ObjectStateModification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public DocumentStateModification(DateTime time, Person modifier, Document document):
            base(time, modifier, ModificationType.DOCUMENT, document.ObjectState)
        {
            Document = document;
            this.AddTarget(document);
        }

        [SynonymousTo("Data")]
        public Document Document;

        public override CombineResult HowToCombine(Modification mod)
        {
            return CombineResult.NoCombine;
        }


        public override String ShortDescription
        {
            get
            {
                if (NewState == ObjectState.Active)
                {
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.DocumentAdded"));
                }
                else
                {
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.DocumentRemoved"));
                }
            }
        }
 
        public override String LongDescription
        {
            get
            {
                if (NewState == ObjectState.Active)
                {
                    return"";// String.Format(
                             // Yesugi.ResourceManager.GetString("Modification.DocumentAdded{0}"),
                              //Document != null? Document.Name : "");
                }
                else
                {
                     return"";// String.Format(
                             // Yesugi.ResourceManager.GetString("Modification.DocumentRemoved{0}"),
                            //  Document != null? Document.Name : "");
                } 
               
            }
        }

      
    }
}
