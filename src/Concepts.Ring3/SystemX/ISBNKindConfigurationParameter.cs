/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/ISBNKindConfigurationParameter.cs#8 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Summary for class:  ISBNKindConfigurationParameter
    /// 
    /// Configuration parameter to set up a list of ISBN kinds that should belong to a certain configuration (for example under a computer system).
    /// 
    /// </summary>
    /// <remarks>
    /// Remarks for class: ISBNKindConfigurationParameter
    /// 
    /// 
    /// 
    /// <para>
    /// Paragraph for class: ISBNKindConfigurationParameter
    /// 
    /// 
    /// 
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// Example for class: ISBNKindConfigurationParameter
    /// 
    /// 
    /// 
    /// </example>
    public class ISBNKindConfigurationParameter : ListConfigurationParameter
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
                
                _ID = BaseConfigurationIdentification.CONFPAR_ISBNKINDS;
                Name = "CONFPAR_ISBNKINDS";
                Description = "CONFDESC_ISBNKINDS";
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance < ISBN.Kind>();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override Something InstantiateMember()
            {
                return MemberKind.Derive() as Something;
            }
        }

        #endregion
    }
}
