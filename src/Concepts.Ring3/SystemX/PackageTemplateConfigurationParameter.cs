/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/PackageTemplateConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Starcounter;
namespace Concepts.Ring3.SystemX
{
    public class PackageTemplateConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_PACKAGE_TEMPLATE;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_PACKAGE_TEMPLATE";
                Description = "CONFDESC_PACKAGE_TEMPLATE";
                _memberKind = Kind.GetInstance < PackageTemplate.Kind>();
            }
        }
    }
}
