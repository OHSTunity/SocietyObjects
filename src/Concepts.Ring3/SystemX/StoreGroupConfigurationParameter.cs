/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/StoreGroupConfigurationParameter.cs#7 $
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
    /// StoreGroup configuration
    /// </summary>
    public class StoreGroupConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_STOREGROUP;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_STOREGROUP";
                Description = "CONFDESC_STOREGROUP";
                _memberKind = Kind.GetInstance < StoreGroup.Kind>();
            }
        }

        #endregion
    }
}
