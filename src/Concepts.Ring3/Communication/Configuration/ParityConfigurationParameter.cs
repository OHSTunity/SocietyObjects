/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/ParityConfigurationParameter.cs#9 $
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
    /// Used by a ComputerSystem, e.g. ComPort, to set the parity for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// ParityConfigurationParameter pcp = ParityConfigurationParameter._.Assure(port) as ParityConfigurationParameter;
    /// pcp.Value = (Int64)ParityConfigurationParameter.ParityOption.None;
    /// </example>
    public class ParityConfigurationParameter : EnumConfigurationParameter
    {
        public new class Kind : EnumConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default Parity
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_PARITY;
                Group = Kind.GetInstance<UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_PARITY";
                Description = "CONFDESC_PARITY";
            }
            
            
            public override Type EnumType
            {
                get
                {
                    return typeof(ParityOption);
                }
                set
                {
                    // Do nothing!
                }
            }

            public new ParityConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as ParityConfigurationParameter;
            }
        }

        public enum ParityOption : int
        {
            None = 0,
            Even = 1,
            Odd = 2,
            Mark = 3,
            Space = 4
        }
    }
}
