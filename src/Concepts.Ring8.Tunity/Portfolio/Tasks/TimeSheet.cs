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
    public class TimeSheet : Relation
    {
        public static IEnumerable<TimeSheet> GetSheetsFor(Something target)
        {
            if (target is Todo)
            {
                return Db.SQL<TimeSheet>("SELECT a FROM TimeSheet a WHERE a.Todo=?", target);
            }
            else if (target is TunityActivity)
            {
                return Db.SQL<TimeSheet>("SELECT a FROM TimeSheet a WHERE a.Activity=?", target);
            }
            return new List<TimeSheet>();
        }


        /// <summary>
        /// Type of time
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
        public void SetActivity(TunityActivity activity)
        {
            SetToWhat(activity);
        }

        /// <summary>
        /// 
        /// </summary>
        public Todo Todo;

        /// <summary>
        /// Time when this TimeSheet was intended.
        /// (when the work was done)
        /// </summary>
        public DateTime TimeSheetTime;


        /// <summary>
        /// Some comment about the timesheet
        /// </summary>
        public String Comment;

        /// <summary>
        /// The amount of time that is logged.
        /// </summary>
        //public TimeSpan UsedTime;

        public String UsedTimeString
        {
            get
            {
                return "";// (UsedTime.Days * 24 + UsedTime.Hours).ToString("00") + ":" + UsedTime.Minutes.ToString("00");
            }
        }


        /// <summary>
        /// Person that is logged for this TimeSheet
        /// </summary>
        public Person Person;
    }
}
