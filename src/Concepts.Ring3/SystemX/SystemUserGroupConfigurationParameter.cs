/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/SystemUserGroupConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class SystemUserGroupConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_SYSTEMUSERGROUP;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_SYSTEMUSERGROUP";
                Description = "CONFDESC_SYSTEMUSERGROUP";
                _memberKind = Kind.GetInstance < SystemUserGroup.Kind>();
            }
        }
    }
}
