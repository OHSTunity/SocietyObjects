/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/VendibleKindAttributeConfigurationParameter.cs#5 $
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
    /// TODO: Summary for class:  VendibleAttributeConfigurationParameter
    /// </summary>
    public class VendibleAttributeConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ListConfigurationParameter.Kind
        {
            /// <summary>
            /// When a new kind is derived.
            /// </summary>
            public override void TempPrototypeKindInit()
            {
                
                _ID = BaseConfigurationIdentification.CONFPAR_VendibleAttribute;
                Name = "CONFPAR_VendibleAttribute";
                Description = "CONFDESC_VendibleAttribute";
                ConfigurationKind = Kind.GetInstance < ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance < Identifier.Kind>();
            }
        }

        #endregion
    }
}
