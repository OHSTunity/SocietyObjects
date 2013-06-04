/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Artifacts/DepartmentComputerSystem.cs#4 $
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
    /// Defines a computer system that is used by a department.
    /// </summary>
    public class DepartmentComputerSystem : ComputerSystem
    {
        public new class Kind : ComputerSystem.Kind
        {
            public DepartmentComputerSystem Get(Department department)
            {
                DepartmentComputerSystem dcs = null;
                string query = string.Format(
                    "SELECT dcs FROM {0} dcs WHERE dcs.Department=VAR({1}, department)",
                    FullInstanceClassName,
                    department.FullClassName);

                using (SqlEnumerator<DepartmentComputerSystem> systems = Sql.GetEnumerator<DepartmentComputerSystem>(query))
                {
                    systems.SetVariable("department", department);

                    if (systems.MoveNext())
                    {
                        dcs = systems.Current;
                    } 
                }
                return dcs;
            }
        }

        public DepartmentComputerSystem()
        {
        }

        public DepartmentComputerSystem(Department department)
        {
            Department = department;
            Owner = department;
        }

        /// <summary>
        /// The Department that uses this computer system.
        /// </summary>
        public Department Department;
    }
}
