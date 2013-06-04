/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/PortConfigurationParameter.cs#8 $
      $DateTime: 2008/06/10 16:03:02 $
      $Change: 12801 $
      $Author: careri $
      =========================================================
*/

using System;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Communication.Configuration
{
    /// <summary>
    /// Used by a ComputerSystem, e.g. ComPort, to set the port number for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// PortConfigurationParameter pcp = PortConfigurationParameter._.Assure(port) as PortConfigurationParameter;
    /// pcp.LongValue = 1L;
    /// </example>
    public class PortConfigurationParameter : LongConfigurationParameter
    {
        public new class Kind : LongConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default Port Configuration
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_PORT;
                LongDefaultValue = 1L;
                Group = Kind.GetInstance < UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_PORT";
                Description = "CONFDESC_PORT";
                MinValue = 1;
            }
            
            public new PortConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as PortConfigurationParameter;
            }
        }
    }
}
