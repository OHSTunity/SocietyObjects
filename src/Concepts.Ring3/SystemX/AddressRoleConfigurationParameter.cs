/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/AddressRoleConfigurationParameter.cs#12 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Starcounter;
using Concepts.Ring1;
using System;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class AddressRoleConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_ADDRESS_ROLES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_ADDRESS_ROLES";
                Description = "CONFDESC_ADDRESS_ROLES";
                _memberKind = Kind.GetInstance < AddressRelation.Kind>();
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
                    String.Format("SELECT a FROM {0} a", Kind.GetInstance < AddressRelation.Kind>().FullClassName)))
            {
                while (sqlEnumerator.MoveNext())
                {
                    AssureMember(sqlEnumerator.Current as AddressRelation.Kind);
                } 
            }

        }
    }
}
