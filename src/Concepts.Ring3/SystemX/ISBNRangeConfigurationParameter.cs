/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/ISBNRangeConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


#region Using directories
using Concepts.Ring1; 
#endregion

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Summary for class:  ISBNRangeConfigurationParameter
    /// 
    /// Configuration parameter to set up a list of ISBN ranges that should belong to a certain configuration (for example under a computer system).
    /// 
    /// </summary>
    /// <remarks>
    /// Remarks for class: ISBNRangeConfigurationParameter
    /// 
    /// 
    /// 
    /// <para>
    /// Paragraph for class: ISBNRangeConfigurationParameter
    /// 
    /// 
    /// 
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// Example for class: ISBNRangeConfigurationParameter
    /// 
    /// 
    /// 
    /// </example>
    public class ISBNRangeConfigurationParameter : ListConfigurationParameter
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
                
                _ID = BaseConfigurationIdentification.CONFPAR_ISBNRANGES;
                Name = "CONFPAR_ISBNRANGES";
                Description = "CONFDESC_ISBNRANGES";
                ConfigurationKind = Kind.GetInstance < ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance < ISBNRange.Kind>();
            }
        }

        #endregion
    }
}
