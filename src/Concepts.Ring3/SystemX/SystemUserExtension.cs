/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/SystemUserExtension.cs#2 $
      $DateTime: 2007/05/07 09:54:29 $
      $Change: 3628 $
      $Author: nikbjo $
      =========================================================
*/

using System.Collections.Generic;
using Concepts.Ring1.SystemX;
using Concepts.Ring1;
using Starcounter.Data;

namespace Concepts.Ring3.SystemX
{
    public sealed class SystemUserExtension : Extension, IConfigurationParameterOwner
    {
        [Extends]
        public SystemUser SystemUser;

        /// <summary>
        /// The computer system that this SystemUser belongs to.
        /// </summary>
        #region IConfigurationParameterOwner Members

        public IConfigurationParameterOwner GetConfigurationParent()
        {
            return SystemUser.Group;
        }

        public IEnumerable<ConfigurationParameter> GetOwnedParameters()
        {
            foreach (ConfigurationParameter parameter in ConfigurationParameters)
            {
                yield return parameter;
            }
        }
        
        public SystemUserExtension GetExtension(SystemUser systemUser)
        {
            return systemUser[_] as SystemUserExtension;
        }

        [RelatesTo(typeof(ConfigurationParameter), "_belongsTo")]
        public ICollection<ConfigurationParameter> ConfigurationParameters;

        #endregion
    }
}
