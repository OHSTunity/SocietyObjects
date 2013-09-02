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
    public class CommentStateModification: ObjectStateModification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public CommentStateModification(DateTime time, Person modifier, Comment comment):
            base(time, modifier, ModificationType.COMMENT, comment.ObjectState)
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
                if (NewState == ObjectState.Active)
                {
                    if (Comment.Target is Version)
                    {
                        return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentAddedVersion{0}"),
                           // (Comment.Target as Version).VersionNumber); 
                    }
                    else if (Comment.Target is Todo)
                    {
                        if ((Comment.Target as Todo).Document != null)
                        {
                            return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentAddedDocumentTodo"));
                        }
                    }
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentAdded"));  
                }
                else
                {
                    if (Comment.Target is Version)
                    {
                        return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentRemovedVersion{0}"),
                           // (Comment.Target as Version).VersionNumber);
                    }
                    else if (Comment.Target is Todo)
                    {
                        if ((Comment.Target as Todo).Document != null)
                        {
                            return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentRemovedDocumentTodo"));
                        }
                    }
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentRemoved"));
                }
            }
        }
 
        public override String LongDescription
        {
            get
            {
                Something target = Comment.Target;

                if (NewState == ObjectState.Active)
                {
                    if (target is Todo)
                    {
                        if ((target as Todo).Document != null)
                        {
                           return"";// String.Format(
                               // Yesugi.ResourceManager.GetString("Modification.CommentAddedDocumentTodo{0}"),
                                  // (target as Todo).Document.Name);
                        }
                        else
                        {
                            return"";// String.Format(
                               // Yesugi.ResourceManager.GetString("Modification.CommentAddedTodo{0}"),
                                   // target.Name);
                        }
                    }
                    else if (target is TunityActivity) //Does not exist for the moment
                    {
                        return"";// String.Format(
                        // Yesugi.ResourceManager.GetString("Modification.CommentAddedActivity"));
                    }
                    else if (target is Version)
                    {
                       Document doc = (target as Version).Owner;
                       return"";// String.Format(
                          // Yesugi.ResourceManager.GetString("Modification.CommentAddedVersion{0}Doc{1}"), 
                            //   (target as Version).VersionNumber, doc.Name);
                    }
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentAdded"));
                }
                else
                {
                    if (target is Todo)
                    {
                        //With a todo target it can be a standalone target or a documenttodo
                        if ((target as Todo).Document != null)
                        {
                            return"";// String.Format(
                               // Yesugi.ResourceManager.GetString("Modification.CommentRemovedDocumentTodo{0}"),
                                   // (target as Todo).Document.Name);
                        }
                        else
                        {
                            return"";// String.Format(
                             // Yesugi.ResourceManager.GetString("Modification.CommentRemovedTodo{0}"),
                            //  target.Name);
                        }
                    } 
                    else if (target is TunityActivity)
                    {
                        return"";// String.Format(
                         // Yesugi.ResourceManager.GetString("Modification.CommentRemovedActivity"));
                    }
                    else if (target is Version)
                    {
                        Document doc = (target as Version).Owner;
                        return"";// String.Format(
                           // Yesugi.ResourceManager.GetString("Modification.CommentRemovedVersion{0}Doc{1}"),
                           //     (target as Version).VersionNumber, doc.Name);
                    }
                    return "";//String.Format(Yesugi.ResourceManager.GetString("Modification.CommentRemoved"));
                }
            }
        }

       
    }
}
