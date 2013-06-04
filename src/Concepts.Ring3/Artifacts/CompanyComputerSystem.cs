/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Artifacts/CompanyComputerSystem.cs#4 $
      $DateTime: 2010/06/23 14:25:02 $
      $Change: 34298 $
      $Author: tobwen $
      =========================================================
*/


using Concepts.Ring2;

using System.Collections.Generic;
using Starcounter;

namespace Concepts.Ring3
{
    /// <summary>
    /// Defines a computer system that is used by a company.
    /// </summary>    
    public class CompanyComputerSystem : ComputerSystem
    {
        public new class Kind : ComputerSystem.Kind
        {
            public CompanyComputerSystem Get(Company company)
            {
                CompanyComputerSystem ccs = null;
                string query = string.Format(
                    "SELECT ccs FROM {0} ccs WHERE ccs.Company=VAR({1}, company)",
                    FullInstanceClassName,
                    company.FullClassName);

                using (SqlEnumerator<CompanyComputerSystem> systems = Sql.GetEnumerator<CompanyComputerSystem>(query))
                {
                    systems.SetVariable("company", company);

                    if (systems.MoveNext())
                    {
                        ccs = systems.Current;
                    } 
                }
                return ccs;
            }
        }

        public CompanyComputerSystem()
        {
        }

        public CompanyComputerSystem(Company company)
        {
            Company = company;
            Owner = company;
        }

        /// <summary>
        /// The company that uses this computer system.
        /// </summary>
        public Company Company;
    }
}
