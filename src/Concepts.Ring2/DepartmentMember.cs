/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/DepartmentMember.cs#2 $
      $DateTime: 2007/12/05 14:57:33 $
      $Change: 7814 $
      $Author: freblo $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
namespace Concepts.Ring2
{
    /// <summary>
    /// A Relation between a somebody and a Department.
    /// </summary>
    public class DepartmentMember : SomebodiesRelation
    {
        public new class Kind : SomebodiesRelation.Kind
        {
        }

        /// <summary>
        /// The Department that this somebody is a member of
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Department Department;
        public void SetDepartment(Department department)
        {
            SetToWhat(department);
        }
    }
}
