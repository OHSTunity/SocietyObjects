/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/Accessible.cs#2 $
      $DateTime: 2008/12/12 07:46:28 $
      $Change: 17466 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring4;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class TodoResponsibleChangedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TodoResponsibleChangedModification(DateTime time, Person modifier,
            Todo todo, Person oldResponsible):
            base(time, modifier, ModificationType.TODO)
        {
            Todo = todo;
            TodoName = todo.Name;
            NewResponsible = todo.Responsible;
            OldResponsible = oldResponsible;
            AddTarget(Todo);
        }

        [SynonymousTo("Data")]
        public Todo Todo;

        [SynonymousTo("Description")]
        public String TodoName;

        public Person NewResponsible;
        public Person OldResponsible;

        public override CombineResult HowToCombine(Modification mod)
        {
            TodoResponsibleChangedModification nm = mod as TodoResponsibleChangedModification;
            if ((nm != null) && (nm.Todo == this.Todo))
            {
                if (nm.NewResponsible == this.OldResponsible)
                {
                    return CombineResult.RemoveBoth;
                }
                else
                {
                    nm.OldResponsible = this.OldResponsible;
                    return CombineResult.RemoveMe;
                }
            }
            return CombineResult.NoCombine;
        }

        public override String ShortDescription
        {
            get
            {
                return"";// String.Format(
                    // Yesugi.ResourceManager.GetString("Modification.TodoResponsibleChangedShort{0}"),
                   //  NewResponsible != null ? NewResponsible.FullName: "none");
            }
        }

        public override String LongDescription
        {
            get
            {
                 return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoResponsibleChanged{0}"),
                     // TodoName);
            }
        }

      
    }
}
