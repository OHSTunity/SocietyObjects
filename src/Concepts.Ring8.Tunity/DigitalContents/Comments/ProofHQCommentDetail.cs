using System;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{

    public class ProofHQCommentDetail : CommentDetail
    {
        public ProofHQCommentDetail()
        {
        }

        public ProofHQCommentDetail(Comment owner, int commentID)
        {
            this.Comment = owner;
            CommentID = commentID;
        }

        public int CommentID;
        
        public override CommentDetail CopyTo(Comment nc)
        {
            return new ProofHQCommentDetail(nc, this.CommentID);
        }

    }
}
