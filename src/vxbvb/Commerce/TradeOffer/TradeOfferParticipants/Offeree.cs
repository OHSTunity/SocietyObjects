using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// The buying part of a AgreedCompensation.
    /// </summary>
    public class Offeree : Participant
    {
        #region Kind
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="Participant.Kind"/>
        public new class Kind : Participant.Kind { }
        #endregion
    }
}
