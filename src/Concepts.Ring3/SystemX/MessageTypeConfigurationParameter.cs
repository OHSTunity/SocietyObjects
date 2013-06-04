/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/MessageTypeConfigurationParameter.cs#12 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring1;
using Concepts.Ring2;
using Starcounter;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Summary for class:  MessageTypeConfigurationParameter
    /// </summary>
    public class MessageTypeConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_MESSAGE_TYPES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_MESSAGE_TYPES";
                Description = "CONFDESC_MESSAGE_TYPES";
                _memberKind = Kind.GetInstance < Message.Kind>();
            }

            public override Concepts.Ring1.Something InstantiateMember()
            {
                return MemberKind.Derive() as Something;
            }
        }

        protected override void OnNew()
        {
            base.OnNew();

            // Create a list member for each country.
            using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT result FROM Concepts.Ring2.Message.Kind result"))
            {
                while (sqlEnumerator.MoveNext())
                {
                    AssureMember(sqlEnumerator.Current as Message.Kind);
                } 
            }

        }
    }
}
