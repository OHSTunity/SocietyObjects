/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/PostcodeConfigurationParameter.cs#7 $
      $DateTime: 2008/05/26 14:09:40 $
      $Change: 12427 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring2;
using Starcounter;
namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Summary for class:  PostcodeConfigurationParameter
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: PostcodeConfigurationParameter
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: PostcodeConfigurationParameter
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: PostcodeConfigurationParameter
    /// This is an example of how to use this class.
    /// </example>
    public class PostcodeConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_POSTCODES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_POSTCODES";
                Description = "CONFDESC_POSTCODES";
                _memberKind = Kind.GetInstance < Postcode.Kind>();
            }
        }
    }
}
