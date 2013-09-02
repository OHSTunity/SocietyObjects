using System;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Base class for CommentData (must be 
    /// </summary>
    public abstract class CommentDetail : Something
    {
        /// <summary>
        /// The comment that this dataobject belongs to
        /// </summary>
        public Comment Comment;


        public virtual CommentDetail CopyTo(Comment nc)
        {
            return null;
        }

    }
}
