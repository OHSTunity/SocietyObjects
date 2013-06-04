/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/MainSeekerPluginsConfigurationParameter.cs#2 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


namespace Concepts.Ring3.SystemX
{
     /// <summary>
    /// Holds the available global seeker plugins for the main seeker.
    /// </summary>
    public class MainSeekerPluginsConfigurationParameter : StringConfigurationParameter
    {
        public new class Kind : StringConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {
                _ID = BaseConfigurationIdentification.CONFPAR_MAIN_SEEKER_PLUGINS;
                Name = "CONFPAR_MAIN_SEEKER_PLUGINS";
                Description = "CONFPAR_MAIN_SEEKER_PLUGINS";
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>() as Configuration.Kind;
            }
        }
    }
}
