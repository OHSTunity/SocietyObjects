/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/AccountConfigurationParameter.cs#8 $
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
    /// TODO: Summary for class:  AccountConfigurationParameter
    /// </summary>
    public class AccountConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_ACCOUNT;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_ACCOUNT";
                Description = "CONFDESC_ACCOUNT";
                _memberKind = Kind.GetInstance < Account.Kind>();
            }
        }
    }
}

