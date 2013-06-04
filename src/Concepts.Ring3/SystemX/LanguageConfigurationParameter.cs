/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/LanguageConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Starcounter;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class LanguageConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_LANGUAGES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_LANGUAGES";
                Description = "CONFDESC_LANGUAGES";
                _memberKind = Kind.GetInstance < Language.Kind>();
            }
        }
    }
}
