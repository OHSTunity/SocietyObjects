/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/NumberOfPinsConfigurationParameter.cs#8 $
      $DateTime: 2008/06/10 16:03:02 $
      $Change: 12801 $
      $Author: careri $
      =========================================================
*/

using System;
using Concepts.Ring3.SystemX;
using Starcounter;

namespace Concepts.Ring3.Communication.Configuration
{
    /// <summary>
    /// Used by a ComputerSystem, e.g. ComPort, to set the number of pins for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// NumberOfPinsConfigurationParameter ncp = NumberOfPinsConfigurationParameter._.Assure(port) as NumberOfPinsConfigurationParameter;
    /// ncp.LongValue = 9L;
    /// </example>
    public class NumberOfPinsConfigurationParameter : LongConfigurationParameter
    {
        public new class Kind : LongConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default NumberOfPins
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_NOPINS;
                LongDefaultValue = 9L;
                Group = Kind.GetInstance < UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_NOPINS";
                Description = "CONFDESC_NOPINS";
                MinValue = 0;
            }

            public new NumberOfPinsConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as NumberOfPinsConfigurationParameter;
            }
        }
    }
}
