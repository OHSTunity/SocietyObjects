/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/DeliveryMethodConfigurationParameter.cs#4 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/

#region Using directives
using Concepts.Ring1;
using Concepts.Ring2; 
#endregion

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Summary for class:  DeliveryMethodConfigurationParameter
    /// 
    /// Configuration parameter to set up a list of delivery methods that should belong to a certain configuration (for example under a computer system).
    /// 
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: DeliveryMethodConfigurationParameter
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: DeliveryMethodConfigurationParameter
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: DeliveryMethodConfigurationParameter
    /// This is an example of how to use this class.
    /// </example>
    public class DeliveryMethodConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {
                _ID = BaseConfigurationIdentification.CONFPAR_DELIVERYMETHOD;
                Name = "CONFPAR_DELIVERYMETHOD";
                Description = "CONFDESC_DELIVERYMETHOD";
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance<DeliveryMethod.Kind>();
            }
        }

        #endregion
    }
}
