/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/DocumentConfigurationParameter.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Concepts.Ring2;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// DocumentConfigurationParameter
    /// </summary>
    public class DocumentConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            protected override void OnNew()
            {
                base.OnNew();
                ID = 201L;
                ConfigurationKind = ApplicationConfiguration._ as ApplicationConfiguration.Kind;
                Name = "CONFPAR_DOCUMENT";
                Description = "CONFDESC_DOCUMENT";
                MemberKind = Document._;
            }
        }
    }
}