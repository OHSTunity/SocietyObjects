/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Communication/Configuration/UARTConfigurationParameterGroup.cs#4 $
      $DateTime: 2008/06/10 16:03:02 $
      $Change: 12801 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Communication.Configuration
{
    /// <summary>
    /// Only used to keep track of HardwareConfigurationParameters, no need to instanciate!
    /// </summary>
    public class UARTConfigurationParameterGroup : ConfigurationParameterGroup
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ConfigurationParameterGroup.Kind
        {
            public override void TempPrototypeKindInit()
            {
                
                Parent = Kind.GetInstance < HardwareConfigurationParameterGroup.Kind>();
            }
        }

        #endregion
    }
}
