/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Configuration/CommerceConfigurationParameterGroup.cs#2 $
      $DateTime: 2007/07/16 17:31:53 $
      $Change: 4862 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Commerce.Configuration
{
    /// <summary>
    /// Only used to keep track of HardwareConfigurationParameters, no need to instanciate!
    /// </summary>    
    public class CommerceConfigurationParameterGroup : ConfigurationParameterGroup
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ConfigurationParameterGroup.Kind
        {
            public override void TempPrototypeKindInit()
            {
                
            }
        }

        #endregion
    }
}
