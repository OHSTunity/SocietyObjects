/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/PrinterConfigurationParameter.cs#5 $
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
    /// Configures what Printers are available in a system
    /// </summary>
    public class PrinterConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_PRINTERS;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_PRINTERS";
                Description = "CONFDESC_LPRINTERS";
                _memberKind = Kind.GetInstance<Printer.Kind>();
            }
        }
    }
}
