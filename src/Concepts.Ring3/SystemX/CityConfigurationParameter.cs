/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/CityConfigurationParameter.cs#12 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Starcounter;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// TODO: Shall this class be moved/removed?
    /// </summary>
    public class CityConfigurationParameter : ListConfigurationParameter
    {
        public new class Kind : ListConfigurationParameter.Kind
        {
            public override void TempPrototypeKindInit()
            {

                _ID = BaseConfigurationIdentification.CONFPAR_CITIES;
                ConfigurationKind = Kind.GetInstance<ApplicationConfiguration.Kind>();
                Name = "CONFPAR_CITIES";
                Description = "CONFDESC_CITIES";
                _memberKind = Kind.GetInstance < City.Kind>();
            }
        }

        protected override void OnNew()
        {
            base.OnNew();

            // Create a list member for each country.
            using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT city FROM " + City.Kind.GetInstance<City.Kind>().FullInstanceClassName + " city"))
            {
                while (sqlEnumerator.MoveNext())
                {
                    AssureMember(sqlEnumerator.Current as City);
                } 
            }
        }
    }
}
