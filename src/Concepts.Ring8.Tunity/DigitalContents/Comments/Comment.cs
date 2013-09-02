/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Comment.cs#6 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/


using System;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    
    /// <summary>
    /// Handles a comment for a specific version
    /// </summary>
    public class Comment : Something, IObjectState 
    {
       
       
        public Comment()
        {
            ObjectState = ObjectState.Active;
        }

        public Comment(Something target)
        {
            ObjectState = ObjectState.Active;
            Target = target;
        }

        public static IEnumerable<Comment> GetCommentsFor(Something something)
        {
            return Db.SQL<Comment>("SELECT a FROM Comment a WHERE a.Active=true AND a.Target=?", something);
        }


        public ObjectState ObjectState
        {
            get;
            set;
        }
        
        /// </summary>
        public String TheComment;

        /// <summary>
        /// The date and time when the comment where made.
        /// </summary>
        public DateTime CommentTime;

        /// <summary>
        /// The person that made the comment
        /// </summary>        
        public Person CommentBy;

        /// <summary>
        /// If the comment is performed. 
        /// </summary>
        public Boolean Performed;

        /// <summary>
        /// The version that is the owner of the comment.
        /// </summary>
        [Obsolete("v.1.4.0 has made this one obsolete, use Target instead")]
        public Version Owner;






        /// <summary>
        /// A comment can have a comment parent (a reply to a comment)
        /// </summary>
        public Comment Parent;

        public IEnumerable<Comment> Children
        {
            get
            {
                return Db.SQL<Comment>("SELECT a FROM Comment a WHERE a.Parent=?", this);
            }
        }



        public Boolean HasChildren
        {
            get
            {
                foreach (Comment child in Children)
                {
                    return true;
                }
                return false;
            }
        }



        public Something Target;

        public T GetTarget<T>() where T : Something
        {
            return Target as T;
        }

       // private CommentType _type = CommentType.Unknown;

        public CommentType Type
        {
            get
            {
         //       if (_type == CommentType.Unknown)
           //     {
                CommentType _type = CommentType.Inside;

                    foreach (CommentDetail detail in Details)
                    {
                        if (detail is IndesignCommentDetail)
                        {
                            _type = CommentType.Indesign;
                            break;
                        }
                        else if (detail is PdfCommentDetail)
                        {
                            _type = CommentType.PDF;
                            break;
                        }
                        else if (detail is ProofHQCommentDetail)
                        {
                            _type = CommentType.ProofHQ;
                            break;
                        }
                    }
             //   }
                return _type;
            }
        }
  
        /// <summary>
        /// List of the CommentDetails connected to this comment
        /// </summary>
        public IEnumerable<CommentDetail> Details
        {
            get
            {
                return Db.SQL<CommentDetail>("SELECT a FROM CommentDetail a WHERE a.Comment=?", this);
            }
        }

        /// <summary>
        /// Returns the detail of the right type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns>Returns detail if found, otherwise null</returns>
        public T GetDetail<T>() where T:CommentDetail
        {
            foreach (CommentDetail cd in Details)
            {
                if (cd is T)
                {
                    return cd as T;
                }
            }
            return null;
        }

        /// <summary>
        ///  Checks if comment include any detail of the particular type
        /// </summary>
        /// <param name="type">CommentDetailType to check</param>
        /// <returns>true if type is found, else false</returns>
        public Boolean IncludesDetail<T>() where T:CommentDetail
        {
            foreach (CommentDetail cd in Details)
            {
                if (cd is T)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Copies the comment to the given new version
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        public Comment CopyTo(Version version)
        {
            Comment nc = new Comment();
            nc.Target = version;
            nc.CommentBy = this.CommentBy;
            nc.CommentTime = this.CommentTime;
            nc.TheComment = this.TheComment;
            nc.Performed = this.Performed;

            foreach (CommentDetail cd in Details)
            {
                cd.CopyTo(nc);
            }

            return nc;
        }

        /// <summary>
        /// Remove the versions connected to this document.
        /// </summary>        
        protected override void OnDelete()
        {
            base.OnDelete();
            foreach (CommentDetail detail in this.Details)
            {
                detail.Delete();
            }
            foreach (CommentOwner co in this.ImplicitRoles<CommentOwner>())
            {
                co.Delete();
            }
        }

        /// <summary>
        ///  Below should be removed later on when they are no longer in use
        /// </summary>
        [Obsolete("Replaced by commentdetails")]
        public int Page;
        [Obsolete("Replaced by commentdetails")]
        public Decimal X_PDF;
        [Obsolete("Replaced by commentdetails")]
        public Decimal Y_PDF;
        [Obsolete("Replaced by commentdetails")]
        public Decimal X_INDD;
        [Obsolete("Replaced by commentdetails")]
        public Decimal Y_INDD;
    }

    public enum CommentType
    {
        Unknown = 0,
        Inside = 1,
        Indesign = 2,
        PDF = 3,
        ProofHQ = 4,
    }
}
