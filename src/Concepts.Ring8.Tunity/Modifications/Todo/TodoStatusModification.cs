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
    /// A Todo has been finished or reopened
    /// </summary>
    public class TodoStatusModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TodoStatusModification(DateTime time, Person modifier,
            Todo todo):
            base(time, modifier, ModificationType.TODO)
        {
            Todo = todo;
            TodoName = todo.Name;
            newStatus = todo.Status;
            AddTarget(Todo);
        }

        [SynonymousTo("Data")]
        public Todo Todo;

        [SynonymousTo("Description")]
        public String TodoName;

        public TodoStatus newStatus;
        
        public override CombineResult HowToCombine(Modification mod)
        {
            TodoStatusModification nm = mod as TodoStatusModification;
            if ((nm != null) && (nm.Todo == this.Todo))
            {
                if (nm.newStatus != this.newStatus)
                {
                    return CombineResult.RemoveBoth;
                }
                else
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
                if (newStatus == TodoStatus.Finished)
                {
                    return"";// String.Format(
                        // Yesugi.ResourceManager.GetString("Modification.TodoFinished"));
                }
                else if (newStatus == TodoStatus.Rejected)
                {
                    return"";// String.Format(
                         // Yesugi.ResourceManager.GetString("Modification.TodoRejected"));
                }
                else
                {
                    return"";// String.Format(
                         // Yesugi.ResourceManager.GetString("Modification.TodoReOpened"));
                }
            }
        }

        public override String LongDescription
        {
            get
            {
                if (newStatus == TodoStatus.Finished)
                {
                    return"";// String.Format(
                        // Yesugi.ResourceManager.GetString("Modification.TodoFinished{0}"),
                        // TodoName);
                }
                else if (newStatus == TodoStatus.Rejected)
                {
                    return"";// String.Format(
                         // Yesugi.ResourceManager.GetString("Modification.TodoRejected{0}"),
                        //  TodoName);
                }
                else
                {
                    return"";// String.Format(
                         // Yesugi.ResourceManager.GetString("Modification.TodoReOpened{0}"),
                         // TodoName);
                }
            }
        }

    }
}
