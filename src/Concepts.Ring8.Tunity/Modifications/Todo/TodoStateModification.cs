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
    public class TodoStateModification: ObjectStateModification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TodoStateModification(DateTime time, Person modifier, Todo todo):
            base(time, modifier, ModificationType.TODO, todo.ObjectState)
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
            return CombineResult.NoCombine;
        }

        public override String ShortDescription
        {
            get
            {
                if (NewState == ObjectState.Active)
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoAdded"));
                }
                else
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoRemoved"));
                }
            }
        }


        public override String LongDescription
        {
            get
            {
                if (NewState == ObjectState.Active)
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoAdded{0}"),
                     // TodoName);
                }
                else
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TodoRemoved{0}"),
                    //  TodoName);
                }
            }
        }

       
    }
}
