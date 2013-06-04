/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/IConfigurationParameterOwner.cs#3 $
      $DateTime: 2009/03/03 12:56:44 $
      $Change: 20024 $
      $Author: careri $
      =========================================================
*/

using System.Collections.Generic;
using Concepts.Ring1;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Interface that must be implemented by any Persistent object that wants to
    /// have ConfigurationParameters connected to it.
    /// 
    /// In SocietyObjects only ComputerSystem and SystemUserExtension can be an IConfigurationParameterOwner.
    /// </summary>
    public interface IConfigurationParameterOwner : IObjectIDProvider
    {
        /// <summary>
        /// Returns the computer system that this IConfigurationParameterOwner is connected to.
        /// </summary>
        /// <returns></returns>
        // ComputerSystem GetComputerSystem();

        IConfigurationParameterOwner GetConfigurationParent();

        /// <summary>
        /// Returns a list of the parameters that belong to this owner.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConfigurationParameter> GetOwnedParameters();
    }
}
