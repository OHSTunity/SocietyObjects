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
    public class TodoEditedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TodoEditedModification(DateTime time, Person modifier, Todo todo) :
            base(time, modifier, ModificationType.TODO)
        {
            Todo = todo;
            TodoName = todo.Name;
            this.AddTarget(todo);
        }

        [SynonymousTo("Data")]
        public Todo Todo;
        
        [SynonymousTo("Description")]
        public String TodoName;

        
        public override CombineResult HowToCombine(Modification mod)
        {
            if (mod is TodoEditedModification)
            {
                if ((mod as TodoEditedModification).Todo == this.Todo)
                {
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
                      // Yesugi.ResourceManager.GetString("Modification.TodoEdited"));
            }
        }

        public override String LongDescription
        {
            get
            {
               return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoEdited{0}"),
                     // TodoName);
            }
        }

       
    }
}
