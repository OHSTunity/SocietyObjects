/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CustomerGroupConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring2;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// CustomerGroup configuration
    /// </summary>
    public class CustomerGroupConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_CUSTOMERGROUP;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CUSTOMERGROUP";
                Description = "CONFDESC_CUSTOMERGROUP";
                _memberKind = Kind.GetInstance < CustomerGroup.Kind>();
            }
        }

        #endregion
    }
}
