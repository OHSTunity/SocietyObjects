/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CurrencyKindConfigurationParameter.cs#11 $
      $DateTime: 2010/12/08 09:32:17 $
      $Change: 39434 $
      $Author: hentil $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Starcounter;
using Concepts.Ring1;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyKindConfigurationParameter : ListConfigurationParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void  TempPrototypeKindInit()
            {
                _ID = BaseConfigurationIdentification.CONFPAR_CURRENCIES;
                ConfigurationKind = GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CURRENCIES";
                Description = "CONFDESC_CURRENCIES";
                _memberKind = GetInstance<Currency.Kind>();
            }

            public override Concepts.Ring1.Something InstantiateMember()
            {
                return MemberKind.Derive() as Something;
            }
        }

        /// <summary>
        /// Defined system currency, Can not be changed, once set.
        /// </summary>
        private Currency.Kind _systemCurrency;

        /// <summary>
        /// Defined system currency, Can not be changed, once set.
        /// </summary>
        public Currency.Kind SystemCurrency
        {
            get { return _systemCurrency; }
            set
            {
                if (_systemCurrency == null)
                {
                    _systemCurrency = value;
                }
                else
                {
                    throw new ApplicationException("System currency cannot be changed");
                }
            }
        }


        public IEnumerable<Currency.Kind> ExistingCurrencies
        {
            get
            {
                List<Currency.Kind> list = new List<Currency.Kind>();
                foreach (var item in ListMembers)
                {
                    list.Add(item.WhatIs as Currency.Kind);   
                }

                return list;
            }

        }
    }
}
