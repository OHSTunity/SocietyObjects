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
    /// A tunityactivity, can be a project or something similiar
    /// 
    /// Its an event but it's not used exactly as an event...
    /// Only begintime and endtime is used, not plannedbeginTime and plannedEndtime
    /// 
    /// Special properties:
    /// Status, kan be Contemplated, Active, Finished or Rejected 
    /// 
    /// </summary>
    public class Todo:Something, IObjectState, IActivityObject, IModificationTarget
    {
       
        public Todo()
        {
            Status = TodoStatus.Active;
            ObjectState = ObjectState.Active;
        }

        public Todo(TunityActivity activity)
        {
            Status = TodoStatus.Active;
            ObjectState = ObjectState.Active;
            Activity = activity;
        }

        public ObjectState ObjectState
        {
            get;
            set;
        }

        public Boolean Active
        {
            get
            {
                return ObjectState == ObjectState.Active;
            }
        }

        public Boolean Archived
        {
            get
            {
                return ObjectState == ObjectState.Archived;
            }
        }

        public Boolean Removed
        {
            get
            {
                return ObjectState == ObjectState.Removed;
            }
        }

        public TodoStatus Status
        {
            get;
            set;
        }

        private Boolean _finished;
        public Boolean OldFinished
        {
            get
            {
                return _finished;
            }
            set
            {
                _finished = value;
            }
        }
        
        public Boolean Finished   
        {
            get 
            { 
                return ((Status == TodoStatus.Finished) ||
                    (Status == TodoStatus.Rejected)); 
            }
        }

        public TunityActivity Activity;


        public TunityActivity ParentActivity()
        {
            return Activity;
        }


        private Person _responsible;
        public Person Responsible
        {
            get { return _responsible; }
            set { _responsible = value; }
        }

        private Document _document;
        public Document Document
        {
            get { return _document; }
            set { _document = value; }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        private DateTime _latestUpdated;
        public DateTime LatestUpdated
        {
            get { return _latestUpdated; }
            set { _latestUpdated = value; }
        }

        private Modification _latestModification;
        public Modification LatestModification
        {
            get { return _latestModification; }
            set { _latestModification = value; }
        }



        public void ModificationAdded(Modification mod)
        {
            if (mod.Time > _latestUpdated)
            {
                _latestUpdated = mod.Time;
                _latestModification = mod;
            }

            if (Document != null)
            {
                if (!mod.HasTarget(Document))
                {
                    mod.AddTarget(Document);
                }
            }
        }

        public void ModificationRemoved(Modification mod)
        {
            if (Document != null)
            {
                if (mod.HasTarget(Document))
                {
                    mod.RemoveTarget(Document);
                }
            }
            if (_latestModification == mod)
            {
                _latestModification = null;
            }
        }


        /// <summary>
        /// Returns all comments for this todo
        /// </summary>
        /// <param name="includePerformed"></param>
        /// <returns></returns>
        public IEnumerable<Comment> Comments
        {
            get
            {
                return Comment.GetCommentsFor(this);  
            }
        }


        //****************************************
        // Portfolio
        //****************************************

        public TaskType TaskType;
        
        /// <summary>
        /// Planned time for this task
        /// </summary>
        public TimeSpan PlannedTime;

        
        public TimeSpan UsedTime
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


        /// <summary>
        /// Sheets bounded to this task
        /// </summary>
        public IEnumerable<TimeSheet> Sheets
        {
            get
            {
                /*TOdo:
                List<TimeSheet> list = new List<TimeSheet>();
                string query = "SELECT a FROM Concepts.Ring8.Tunity.TimeSheet"+
                " a WHERE a.Todo=variable(Concepts.Ring8.Tunity.Todo, todo)";
                SqlPrepared prepared = Sql.GetPrepared(query);
                SqlEnumerator<TimeSheet> sql = Sql.GetEnumerator<TimeSheet>(prepared);
                sql.SetVariable("todo", this);
                while (sql.MoveNext())
                {
                    yield return sql.Current;
                }
                 */
                return null;
            }
        }
    }
}
