/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Commerce/Configuration/TenderConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring3.Commerce.Configuration
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class TenderConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_TENDER;
                Group = Kind.GetInstance<CommerceConfigurationParameterGroup.Kind>();
                ConfigurationKind = Kind.GetInstance < ApplicationConfiguration.Kind>();
                Name = "CONFPAR_TENDER";
                Description = "CONFDESC_TENDER";
                _memberKind = Kind.GetInstance < Tender.Kind>();
            }
        }
    }
}
