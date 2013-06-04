/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/StopbitsConfigurationParameter.cs#8 $
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
    /// Used by a ComputerSystem, e.g. ComPort, to set the stopbits for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComStopbits port = new ComStopbits();
    /// StopbitsConfigurationParameter scp = StopbitsConfigurationParameter._.Assure(port) as StopbitsConfigurationParameter;
    /// scp.LongValue = 1L;
    /// </example>
    public class StopbitsConfigurationParameter : DecimalConfigurationParameter
    {
        public new class Kind : DecimalConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default Stopbits Configuration
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_STOPBITS;
                DecimalDefaultValue = 1m;
                Group = Kind.GetInstance < UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_STOPBITS";
                Description = "CONFDESC_STOPBITS";
                MinValue = 1;
            }
            
            public new StopbitsConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as StopbitsConfigurationParameter;
            }
        }
    }
}
