using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;
using Concepts.Ring2;

namespace Concepts.Ring3
{
    public class Voucher : Monetary
    {
        public new class Kind : Monetary.Kind
        {
            /// <summary>
            /// The condition that must be met in order to use the voucher as payment.
            /// The condition will be handed the Sale as a prerequisite to evaluate wheter
            /// the voucher is valid or not.
            /// </summary>
            public Concepts.Ring1.Condition Condition;


            /// <summary>
            /// To which supplier the voucher may be used as a payment.
            /// </summary>
            public Somebody ValidToWhom;

            /// <summary>
            /// In addition to the condition, a valid period for using the voucher may be specified here.
            /// </summary>
            public DateTime ValidFrom;

            /// <summary>
            /// In addition to the condition, a valid period for using the voucher may be specified here.
            /// </summary>
            public DateTime ValidTo;

        }

        /// <summary>
        /// The condition that must be met in order to use the voucher as payment.
        /// The condition will be handed the Sale as a prerequisite to evaluate wheter
        /// the voucher is valid or not.
        /// </summary>
        public Concepts.Ring1.Condition Condition;


        /// <summary>
        /// To which supplier the voucher may be used as a payment.
        /// </summary>
        public Somebody ValidToWhom;

        /// <summary>
        /// Each Voucher may have a unique ID.
        /// </summary>
        [SynonymousTo("Name")]
        public string ID;


        /// <summary>
        /// In addition to the condition, a valid period for using the voucher may be specified here.
        /// </summary>
        public DateTime ValidFrom;

        /// <summary>
        /// In addition to the condition, a valid period for using the voucher may be specified here.
        /// </summary>
        public DateTime ValidTo;
    }
}
