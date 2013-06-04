/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/FileKindConfigurationParameter.cs#8 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Summary for class:  FileConfigurationParameter
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: FileConfigurationParameter
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: FileConfigurationParameter
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: FileConfigurationParameter
    /// This is an example of how to use this class.
    /// </example>
    public class FileKindConfigurationParameter : ListConfigurationParameter
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : ListConfigurationParameter.Kind
        {
            /// <summary>
            /// 
            /// </summary>
            public override void TempPrototypeKindInit()
            {
                
                _ID = BaseConfigurationIdentification.CONFPAR_FILES;
                Name = "CONFPAR_FILES";
                Description = "CONFDESC_FILES";
                ConfigurationKind = Kind.GetInstance < ApplicationConfiguration.Kind>();
                _memberKind = Kind.GetInstance < File.Kind>();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override Something InstantiateMember()
            {
                return this.Derive() as Something;
            }

        }

        #endregion

    }
}
