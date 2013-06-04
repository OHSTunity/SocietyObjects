/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CategoryConfigurationParameter.cs#13 $
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
    /// TODO: Summary for class:  CategoryConfigurationParameter
    /// </summary>
    public class CategoryConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_CATEGORY;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CATEGORY";
                Description = "CONFDESC_CATEGORY";
                _memberKind = Kind.GetInstance < Category.Kind>();
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
                    "SELECT result FROM Concepts.Ring1.Category.Kind result"))
            {
                while (sqlEnumerator.MoveNext())
                {
                    AssureMember(sqlEnumerator.Current as Category.Kind);
                } 
            }

        }
    }
}