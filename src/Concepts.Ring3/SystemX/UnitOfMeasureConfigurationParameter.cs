/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/UnitOfMeasureConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


#region Using directives
using Concepts.Ring1; 
#endregion

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Summary for class:  UnitOfMeasureConfigurationParameter
    /// 
    /// Configuration parameter to set up a list of unit of measures that should belong to a certain configuration (for example under a computer system).
    /// 
    /// </summary>
    /// <remarks>
    /// Remarks for class: UnitOfMeasureConfigurationParameter
    /// 
    /// 
    /// 
    /// <para>
    /// Paragraph for class: UnitOfMeasureConfigurationParameter
    /// 
    /// 
    /// 
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// Example for class: UnitOfMeasureConfigurationParameter
    /// 
    /// 
    /// 
    /// </example>
    public class UnitOfMeasureConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ListConfigurationParameter.Kind
        {
            /// <summary>
            /// When a new kind is derived. Sets id, name, description, configurationkind and memberkind (kind that this config is representing).
            /// </summary>
            public override void TempPrototypeKindInit()
            {
                
                _ID = BaseConfigurationIdentification.CONFPAR_UNITOFMEASUREs;
                Name = "CONFPAR_UNITOFMEASUREs";
                Description = "CONFDESC_UNITOFMEASURES";
                ConfigurationKind = Kind.GetInstance < ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance < UnitOfMeasure.Kind>();
            }

        }

        #endregion
    }
}
