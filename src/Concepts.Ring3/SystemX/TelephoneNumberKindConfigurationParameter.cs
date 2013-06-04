/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/TelephoneNumberKindConfigurationParameter.cs#5 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;

using Starcounter;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// CustomerGroup configuration
    /// </summary>
    public class TelphoneNumberKindConfigurationParameter : ConfigurationParameter
    {
        #region Kind

        public new class Kind : ConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_CompanyCustomerDefaultNumberKind;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CompanyCustomerDefaultNumberKind";
                Description = "CONFPAR_CompanyCustomerDefaultNumberKind";
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public TelphoneNumberKindConfigurationParameter GetConfigParameter(IConfigurationParameterOwner owner,
                Type usedByType)
            {
                Dictionary<IConfigurationParameterOwner, TelphoneNumberKindConfigurationParameter> dict = new Dictionary<IConfigurationParameterOwner, TelphoneNumberKindConfigurationParameter>();
                TelphoneNumberKindConfigurationParameter param;

                using (SqlEnumerator enu = Sql.GetEnumerator(
                    "SELECT param FROM Concepts.Ring3.SystemX.TelphoneNumberKindConfigurationParameter param WHERE param.InstantiatedFrom=variable(Concepts.Ring1.Something, kind)"))
                {
                    enu.SetVariable("kind", this);
                    param = null;
                    while (enu.MoveNext())
                    {
                        param = enu.Current as TelphoneNumberKindConfigurationParameter;
                        dict[param.BelongsTo as IConfigurationParameterOwner] = param;
                        if (param.BelongsTo.Equals(owner))
                        {
                            return param;
                        }

                    } 
                }
                if (param == null && owner.GetConfigurationParent() != null)
                {
                    return GetParameterRecursively(owner, usedByType, dict);
                }
                return null;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <param name="dic"></param>
            /// <returns></returns>
            public TelphoneNumberKindConfigurationParameter GetParameterRecursively(
                IConfigurationParameterOwner owner,
                Type usedByType,
                Dictionary<IConfigurationParameterOwner, TelphoneNumberKindConfigurationParameter> dic)
            {
                TelphoneNumberKindConfigurationParameter param = dic[owner];
                if (param != null)
                {
                    return param;
                }
                if (owner.GetConfigurationParent() != null)
                {
                    return GetParameterRecursively(owner.GetConfigurationParent(), usedByType, dic) as TelphoneNumberKindConfigurationParameter;
                }
                return null;
            }
        }

        public TelephoneNumberRelation.Kind TelephoneNumberRelationKind;

        #endregion
    }
}
