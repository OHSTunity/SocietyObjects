using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring2
{
    /// <summary>
    /// Part of the postal address system.
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:X</equal>
    /// <equal>sumo:X</equal>
    /// </ontlogy>
    public class Country : PostAddressComponent
    {
        #region Kind class
        /// <summary>
        /// Equals the kind of country.
        /// </summary>
        /// <seealso cref="SpatialAddress.Kind"/>
        public new class Kind : PostAddressComponent.Kind
        {
            /// <summary>
            /// Fetches a country by the ISO3166_2 code.
            /// </summary>
            /// <param name="iSO3166_1_alpha_2">E.g. SE</param>
            /// <returns>Country</returns>
            public Country GetByAlpha2(string iSO3166_1_alpha_2)
            {
                Country country;

                using (SqlEnumerator<Country> sqlEnumerator = Sql.GetEnumerator<Country>(
                        string.Format("SELECT result FROM {0} result WHERE result.ISO3166_1_alpha_2=variable(String, iSO3166_1_alpha_2)", FullInstanceClassName)))
                {
                    sqlEnumerator.SetVariable("iSO3166_1_alpha_2", iSO3166_1_alpha_2);
                    country = sqlEnumerator.FirstOrDefault<Country>(); 
                }

                return country;
            }

            /// <summary>
            /// Fetches a country by the ISO3166_3 code.
            /// </summary>
            /// <param name="iSO3166_1_alpha_3">E.g. SWE</param>
            /// <returns>Country</returns>
            public Country GetByAlpha3(string iSO3166_1_alpha_3)
            {
                Country country;

                using (SqlEnumerator<Country> sqlEnumerator = Sql.GetEnumerator<Country>(
                        string.Format("SELECT result FROM {0} result WHERE result.ISO3166_1_alpha_3=variable(String, iSO3166_1_alpha_3)", FullInstanceClassName)))
                {
                    sqlEnumerator.SetVariable("iSO3166_1_alpha_3", iSO3166_1_alpha_3);
                    country = sqlEnumerator.FirstOrDefault<Country>(); 
                }
                return country;
            }


            /// <summary>
            /// Assure a country instance with the specified country ISO3166_1 codes.
            /// </summary>
            /// <param name="iSO3166_1_alpha_2">SE</param>
            /// <param name="iSO3166_1_alpha_3">SWE</param>
            /// <param name="iSO3166_1_numeric">572</param>
            /// <param name="countryName">Sweden</param>
            /// <returns>Country</returns>
            public Country Assure(string iSO3166_1_alpha_2, string iSO3166_1_alpha_3, string iSO3166_1_numeric, string countryName)
            {
                Country country = null;
                if (iSO3166_1_alpha_2 != null || countryName != null)
                {
                    country = GetByAlpha2(iSO3166_1_alpha_2);

                    if (country == null)
                    {
                        country = new Country();
                        country.ISO3166_1_alpha_2 = iSO3166_1_alpha_2;
                        country.CountryName = countryName;

                        if (iSO3166_1_alpha_3 != null)
                        {
                            country.ISO3166_1_alpha_3 = iSO3166_1_alpha_3;
                        }
                        if (iSO3166_1_numeric != null)
                        {
                            country.ISO3166_1_numeric = iSO3166_1_numeric;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot create new Concepts.Ring2.Country if variable ISO3166_1_alpha_2 or englishName is null.");
                }
                return country;
            }
        }
        #endregion

        /// <summary>
        /// The ISO Code of the country.
        /// <example>
        /// Sweden, se
        /// Norway, no
        /// </example>
        /// </summary>
        [SynonymousTo("Name")]
        public String ISO3166_1_alpha_2;

        /// <summary>
        /// The ISO Code of the country.
        /// <example>
        /// Sweden, SWE
        /// Norway, NOR
        /// </example>
        /// </summary>
        public String ISO3166_1_alpha_3;

        /// <summary>
        /// The ISO Code of the country.
        /// <example>
        /// Sweden, 752
        /// Norway, 578
        /// </example>
        /// </summary>
        public String ISO3166_1_numeric;

        /// <summary>
        /// English name of the country, from ISO 3166-1. Translations of names is done in the
        /// translation files per language.
        /// </summary>
        public String CountryName;

        /// <summary>
        /// Information to view upon default search
        /// </summary>
        /// <returns></returns>
        public override string ToSelectorString()
        {
            return CountryName;
        }

    }
}
