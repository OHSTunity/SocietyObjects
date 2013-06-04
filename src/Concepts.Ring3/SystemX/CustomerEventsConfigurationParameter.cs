/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CustomerEventsConfigurationParameter.cs#6 $
      $DateTime: 2010/02/16 17:19:47 $
      $Change: 29428 $
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
    public class CustomerEventsConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_CUSTOMEREVENTS;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CUSTOMEREVENTS";
                Description = "CONFPAR_CUSTOMEREVENTS";
                _memberKind = Kind.GetInstance < Event.Kind>();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public CustomerEventsConfigurationParameter GetConfigParameter(IConfigurationParameterOwner owner,
                Type usedByType)
            {
                Dictionary<IConfigurationParameterOwner, CustomerEventsConfigurationParameter> dict = new Dictionary<IConfigurationParameterOwner, CustomerEventsConfigurationParameter>();
                CustomerEventsConfigurationParameter param;

                using (SqlEnumerator enu = Sql.GetEnumerator(
                    "SELECT param FROM Concepts.Ring3.SystemX.CustomerEventsConfigurationParameter param WHERE param.InstantiatedFrom=variable(Concepts.Ring1.Something, kind)"))
                {
                    enu.SetVariable("kind", this);
                    param = null;
                    while (enu.MoveNext())
                    {
                        param = enu.Current as CustomerEventsConfigurationParameter;
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
            public CustomerEventsConfigurationParameter GetParameterRecursively(
                IConfigurationParameterOwner owner,
                Type usedByType,
                Dictionary<IConfigurationParameterOwner, CustomerEventsConfigurationParameter> dic)
            {
                CustomerEventsConfigurationParameter param = dic[owner];
                if (param != null)
                {
                    return param;
                }
                if (owner.GetConfigurationParent() != null)
                {
                    return GetParameterRecursively(owner.GetConfigurationParent(), usedByType, dic) as CustomerEventsConfigurationParameter;
                }
                return null;
            }
        }

        #endregion
    }
}
