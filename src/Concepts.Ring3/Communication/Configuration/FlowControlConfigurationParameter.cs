/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/FlowControlConfigurationParameter.cs#9 $
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
    /// Used by a ComputerSystem, e.g. ComPort, to set the flow control for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// FlowControlConfigurationParameter fcp = FlowControlConfigurationParameter._.Assure(port) as FlowControlConfigurationParameter;
    /// fcp.Value = (Int64)FlowControlConfigurationParameter.FlowControlOption.None;
    /// </example>
    public class FlowControlConfigurationParameter : EnumConfigurationParameter
    {
        public new class Kind : EnumConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default BaudConfiguration
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_FLOWCONTROL;
                Group = Kind.GetInstance<UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_FLOWCONTROL";
                Description = "CONFDESC_FLOWCONTROL";
            }
            
            
            public override Type EnumType
            {
                get
                {
                    return typeof(FlowControlOption);
                }
                set
                {
                    // Do nothing!
                }
            }

            public new FlowControlConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as FlowControlConfigurationParameter;
            }
        }

        public enum FlowControlOption : int
        {
            None = 0,
            XonXoff = 1,
            Hardware = 2
        }
    }
}
