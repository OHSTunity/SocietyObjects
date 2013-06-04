using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring2;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    public class PaymentTermConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            /// <summary>
            /// When a new kind is derived.
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_PaymentTerm;
                Name = "CONFPAR_PaymentTerm";
                Description = "CONFDESC_PaymentTerm";
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance<PaymentTerms.Kind>();
                _memberRelationKind = Kind.GetInstance<PaymentTermConfigurationParameterMember.Kind>();
            }
        }
    }

    public class PaymentTermConfigurationParameterMember : ListConfigurationParameterMember
    {
        public new class Kind : ListConfigurationParameterMember.Kind
        {
        }

        [SynonymousTo("WhatIs")]
        public readonly PaymentTerms PaymentTerms;

        public void SetPaymentTerms(PaymentTerms paymentTerms)
        {
            SetWhatIs(paymentTerms);
        }
    }
}
