/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/BaudConfigurationParameter.cs#8 $
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
    /// Used by a ComputerSystem, e.g. ComPort, to set the baud rate for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// BaudConfigurationParameter bcp = BaudConfigurationParameter._.Assure(port) as BaudConfigurationParameter;
    /// bcp.LongValue = 2400L;
    /// </example>
    public class BaudConfigurationParameter : LongConfigurationParameter
    {
        public new class Kind : LongConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default BaudConfiguration
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_BAUD;
                LongDefaultValue = 9600L;
                Group = Kind.GetInstance < UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_BAUD";
                Description = "CONFDESC_BAUD";
                MinValue = 0;                
            }
            
            public new BaudConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as BaudConfigurationParameter;
            }
        }
    }
}
