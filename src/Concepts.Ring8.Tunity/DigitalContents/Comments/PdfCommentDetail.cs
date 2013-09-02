using System;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    public class PdfCommentDetail : CommentDetail
    {
        public PdfCommentDetail()
        {
        }

        public PdfCommentDetail(Comment owner, int page, decimal x, decimal y)
        {
            this.Comment = owner;
            Page = page;
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Page in the indesign document where the comment belongs
        /// </summary>
        public int Page;
        /// <summary>
        /// X coord. for the comment in the indesign document
        /// </summary>
        public Decimal X;
        /// <summary>
        /// Y coord. for the comment in the indesign document
        /// </summary>
        public Decimal Y;

        public override CommentDetail CopyTo(Comment nc)
        {
            return new PdfCommentDetail(nc, this.Page, this.X, this.Y);
        }

    }
}
