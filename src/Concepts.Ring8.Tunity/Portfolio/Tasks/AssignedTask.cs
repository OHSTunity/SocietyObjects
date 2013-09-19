/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// A template for ProjectEvents, since it is a normal event it can contain the same properties
    /// </summary>
    public class AssignedTask : Relation
    {
        public AssignedTask()
        {
            Finished = false;
        }

        /// <summary>
        /// the task
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly TaskType TaskType;
        public void SetTaskType(TaskType taskType)
        {
            SetWhatIs(taskType);
        }

        /// <summary>
        /// the task
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly TunityActivity Activity;
        public void SetActivity(TunityActivity ev)
        {
            SetToWhat(ev);
        }

        public Boolean Finished;
 

        /// <summary>
        /// Planned time for this task
        /// </summary>
        //public TimeSpan PlannedTime;

       /* public TimeSpan UsedTime
        {
            get
            {
                TimeSpan span = new TimeSpan();
                foreach (TimeSheet sheet in Sheets)
                {
                    span += sheet.UsedTime;
                }
                return span;
            }
        }
        */

        /// <summary>
        /// Sheets bounded to this task
        /// </summary>
        public IEnumerable<TimeSheet> Sheets
        {
            get
            {
                List<TimeSheet> list = new List<TimeSheet>();
                if ((Activity != null) && (TaskType != null))
                {
                    foreach (TimeSheet sheet in Activity.ImplicitRoles<TimeSheet>())
                    {
                        if (sheet.TaskType == TaskType)
                        {
                            list.Add(sheet);
                        }
                    }
                }
                return list;
            }
        }


        public Person Person;

    }
}
