/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Transaction/MoveTransaction.cs#3 $
      $DateTime: 2010/10/06 16:03:20 $
      $Change: 36882 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;
namespace Concepts.Ring3
{
    /// <summary>
    /// TODO: Summary for class:  MoveTransaction
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: MoveTransaction
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: MoveTransaction
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: MoveTransaction
    /// This is an example of how to use this class.
    /// </example>
    public class MoveTransaction : BusinessTransaction
    {
        public new class Kind : BusinessTransaction.Kind { }

        public bool IsApproved
        {
            get
            {
                return HasEnded;
            }
        }


        protected Somebody _approver;
        /// <summary>
        /// The somebody that the orderer confirmed the trade with, shall only be set if this differs from the seller.
        /// </summary>
        [SynonymousTo("_approver")]
        public readonly Somebody Approver;
        public void SetApprover(Somebody approver)
        {
            _approver = approver;
        }
    }
}
