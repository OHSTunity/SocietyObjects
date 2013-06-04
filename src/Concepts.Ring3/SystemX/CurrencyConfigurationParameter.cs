/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CurrencyConfigurationParameter.cs#4 $
      $DateTime: 2007/07/16 17:31:53 $
      $Change: 4862 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class CurrencyConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {
                
                ID = 392L;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CURRENCIES";
                Description = "CONFDESC_CURRENCIES";
                MemberKind = Kind.GetInstance < Currency.Kind>();
            }

            public override Concepts.Ring1.Something InstantiateMember()
            {
                return MemberKind.Derive() as Something;
            }
        }

        protected override void OnNew()
        {
            base.OnNew();

            // Create a list member for each currency.
            SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT result FROM Concepts.Ring2.Currency.Kind result");

            while (sqlEnumerator.MoveNext())
            {
                AssureMember(sqlEnumerator.Current as Currency.Kind);
            }
        }
    }
}
