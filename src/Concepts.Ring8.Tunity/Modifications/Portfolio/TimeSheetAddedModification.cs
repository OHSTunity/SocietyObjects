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
    public class TimeSheetAddedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public TimeSheetAddedModification(DateTime time, Person modifier, TimeSheet sheet):
            base(time, modifier, ModificationType.TIMESHEET)
        {
            Sheet = sheet;
            this.AddTarget(sheet);
            if (sheet.Activity != null)
            {
                this.AddTarget(sheet.Activity);
            }
            if (sheet.Todo != null)
            {
                this.AddTarget(sheet.Todo);
            }
        }

        [SynonymousTo("Data")]
        public TimeSheet Sheet;

        
        public override CombineResult HowToCombine(Modification mod)
        {
            return CombineResult.NoCombine;
        }

        public override String ShortDescription
        {
            get
            {
                return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TimeSheetAdded"));
            }
        }


        public override String LongDescription
        {
            get
            {
                if ((Sheet.Todo != null) && (Sheet.Todo.Document != null))
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TimeSheetAddedDocument{0}"),
                    //  Sheet.Todo.Document.Name);
                }
                else if (Sheet.Todo != null)
                {
                    return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.TimeSheetAddedTodo{0}"),
                     // Sheet.Todo.Name);
                }
                else
                {
                    return "";// Yesugi.ResourceManager.GetString("Modification.TimeSheetAdded");
                }
            }
        }

       
    }
}
