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
    public class CommentEditedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public CommentEditedModification(DateTime time, Person modifier, Comment comment):
            base(time, modifier, ModificationType.COMMENT)
        {
            Comment = comment;
            this.AddTarget(comment);
            if (comment.Target != null)
            {
                this.AddTarget(comment.Target);
            }
        }

        [SynonymousTo("Data")]
        public Comment Comment;

        public override CombineResult HowToCombine(Modification mod)
        {
            return CombineResult.NoCombine;
        }


        public override String ShortDescription
        {
            get
            {
                Something target = Comment.Target;
                if (target is Version)
                {
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentEditedVersion{0}"),
                        //(target as Version).VersionNumber);
                }
                else if (target is Todo)
                {
                    if ((target as Todo).Document != null)
                    {
                        return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentEditedDocumentTodo"));
                    }
                }
                return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentEdited"));
            }
        }

        public override String LongDescription
        {
            get
            {
                Something target = Comment.Target;
                if (target is Todo)
                {
                    if ((target as Todo).Document != null)
                    {
                       return"";// String.Format(
                           // Yesugi.ResourceManager.GetString("Modification.CommentEditedDocumentTodo{0}"),
                           //   (target as Todo).Document.Name);
                    }
                    else
                    {
                       return"";// String.Format(
                           // Yesugi.ResourceManager.GetString("Modification.CommentEditedTodo{0}"),
                               // target.Name);
                    }
                }
                else if (target is TunityActivity) //Does not exist for the moment
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.CommentEditedActivity"));
                }
                else if (target is Version)
                {
                   Document doc = (target as Version).Owner;
                   return"";// String.Format(
                       // Yesugi.ResourceManager.GetString("Modification.CommentEditedVersion{0}Doc{1}"), 
                           //(target as Version).VersionNumber, doc.Name);
                }
                return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentEdited"));
            }
        }

       
    }
}
