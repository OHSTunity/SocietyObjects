/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/DatabitsConfigurationParameter.cs#8 $
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
    /// Used by a ComputerSystem, e.g. ComPort, to set the databits for a ComputerSystem.
    /// </summary>
    /// 
    /// <example>
    /// ComPort port = new ComPort();
    /// DatabitsConfigurationParameter dcp = DatabitsConfigurationParameter._.Assure(port) as DatabitsConfigurationParameter;
    /// dcp.LongValue = 8L;
    /// </example>
    public class DatabitsConfigurationParameter : LongConfigurationParameter
    {
        public new class Kind : LongConfigurationParameter.Kind
        {
            /// <summary>
            /// Init the default Databits
            /// </summary>
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_DATABITS;
                LongDefaultValue = 8L;
                Group = Kind.GetInstance < UARTConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ComputerConfiguration.Kind>();
                Name = "CONFPAR_DATABITS";
                Description = "CONFDESC_DATABITS";
                MinValue = 0;
                MaxValue = 8;
            }
            
            public new DatabitsConfigurationParameter GetParameter(IConfigurationParameterOwner owner, Type usedByType)
            {
                return base.GetParameter(owner, usedByType) as DatabitsConfigurationParameter;
            }
        }
    }
}
