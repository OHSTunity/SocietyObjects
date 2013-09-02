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
    public class TodoDescriptionModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TodoDescriptionModification(DateTime time, Person modifier, Todo todo, String oldTodoDescription) :
            base(time, modifier, ModificationType.TODO)
        {
            Todo = todo;
            NewTodoDescription = todo.Name;
            OldTodoDescription = oldTodoDescription;
            this.AddTarget(todo);
        }

        [SynonymousTo("Data")]
        public Todo Todo;

        public readonly String NewTodoDescription;

        [SynonymousTo("Description")]
        public readonly String OldTodoDescription;
        
        public override CombineResult HowToCombine(Modification mod)
        {
            if (mod is TodoDescriptionModification)
            {
                if ((mod as TodoDescriptionModification).Todo == this.Todo)
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
                      // Yesugi.ResourceManager.GetString("Modification.TodoDescription{0}"),
                      // NewTodoDescription);
            }
        }

        public override String LongDescription
        {
            get
            {
               return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoDescription{0}{1}"),
                     // OldTodoDescription, NewTodoDescription);
            }
        }

       
    }
}
