/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CountryConfigurationParameter.cs#9 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class CountryConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID =BaseConfigurationIdentification.CONFPAR_COUNTRIES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_COUNTRIES";
                Description = "CONFDESC_COUNTRIES";
                _memberKind = Kind.GetInstance<Country.Kind>();
                _memberRelationKind = Kind.GetInstance<CountryConfigurationParameterMember.Kind>();
            }

            public override Something InstantiateMember()
            {
                 return MemberKind.Derive() as Something;
            }
        }
    }

    public class CountryConfigurationParameterMember : ListConfigurationParameterMember
    {
        public new class Kind : ListConfigurationParameterMember.Kind
        {

        }

        [SynonymousTo("WhatIs")]
        public readonly Country Country;

        /// <summary>
        /// Needed for the SelfExplainLookup to work.
        /// TODO, have shall we solve this in a nicer way?
        /// </summary>
        public Country _Country
        {
            get { return Country; }
            set { SetCountry(value); }
        }

        public void SetCountry(Country country)
        {
            SetWhatIs(country);
        }
    }
}
