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
    public class TunityActivity : Event, IModificationTarget, IObjectState
    {
      
        public TunityActivity()
        {
            _status = ActivityStatus.Active;
            ObjectState = ObjectState.Active;
        }

        private String _folderName;
        public String FolderName
        {
            get
            {
                if (String.IsNullOrEmpty(_folderName))
                {
                    return DbHelper.GetObjectID(this) + "\\";
                }
                else
                    return _folderName;
            }
            set
            {
                _folderName = value;
            }
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

        public String ParentsName
        {
            get
            {
                String result = "";
                TunityActivity p = this;
                int counter = 0;
                while ((p.Parent != null) && (counter < 8))
                {
                    result = p.Parent.Name + "\\" + result;
                    p = p.Parent;
                    counter++;
                }
                return result;
            }
        }

        public String FullName
        {
            get
            {
                String result = this.Name;
                TunityActivity p = this;
                int counter = 0;
                while ((p.Parent != null) && (counter < 8))
                {
                    result = p.Parent.Name + "\\" + result;
                    p = p.Parent;
                    counter++;
                }
                return result;
            }
        }

        public int TreeLevel
        {
            get
            {
                TunityActivity p = this;
                int counter = 0;
                while ((p.Parent != null) && (counter < 8))
                {
                    p = p.Parent;
                    counter++;
                }
                return counter;
            }
        }

        public List<TunityActivity> Parents
        {
            get
            {
                List<TunityActivity> parents = new List<TunityActivity>();
                TunityActivity p = this;
                int counter = 0;
                while ((p.Parent != null) && (counter < 8))
                {
                    parents.Add(p.Parent);
                    p = p.Parent;
                    counter++;
                }
                parents.Reverse();
                return parents;
            }
        }


        private ActivityStatus _status;
        public ActivityStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }



        public Boolean Finished
        {
            get
            {
                return ((Status == ActivityStatus.Finished) ||
                    (Status == ActivityStatus.Rejected));
            }
        }

        public Boolean HasChildren
        {
            get
            {
                return Children.GetEnumerator().MoveNext();
            }
        }

        public Person Responsible
        {
            get
            {
                return ImplicitlyRelatedObject<Person, Responsible>();
            }
            set
            {
                Responsible res = ImplicitRole<Responsible>();
                if (res.WhoIs == value)
                    return;
                if (res != null)
                {
                    res.Delete();
                }
                if (value != null)
                {
                    res = new Responsible();
                    res.SetWhoIs(value);
                    res.SetToWhat(this);
                }
            }
        }

        public String StatusAsString
        {
            get
            {
                return "";// Yesugi.ResourceManager.GetString(
                    //DescriptionValueEnum.GetDescriptionValue(Status));
            }
        }


        public TunityActivity Parent;


        /// <summary>
        /// List of active sub activities that belongs to the activity.
        /// </summary>
        public IEnumerable<TunityActivity> Children
        {
            get
            {
                return Db.SQL<TunityActivity>("SELECT a FROM TunityActivity a WHERE a.Active=true AND a.Parent=?", this);
            }
        }
        
        /// <summary>
        /// List of subactivities with given states that belongs to the activity.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        public IEnumerable<TunityActivity> GetChildren(ObjectState[] states)
        {
            SqlResult<TunityActivity> sql =  Db.SQL<TunityActivity>("SELECT a FROM TunityActivity a WHERE a.Parent=?", this);
            foreach (TunityActivity t in sql)
            {
                 if (Array.Exists(states, element => element == t.ObjectState))
                    yield return t;
            }
        }

        /// <summary>
        /// Returns itself together with all childrens (recursive))
        /// </summary>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public List<TunityActivity> IncludingChildren()
        {
            return IncludingChildren(false);
        }

        /// <summary>
        /// Returns itself together with all childrens (recursive))
        /// </summary>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public List<TunityActivity> IncludingChildren(Boolean includeArhived)
        {
            List<TunityActivity> list = new List<TunityActivity>();
            list.Add(this);
            foreach (TunityActivity child in Children)
            {
                if (child.ObjectState == ObjectState.Active ||
                    (includeArhived && child.ObjectState == ObjectState.Archived))
                {
                    list.AddRange(child.IncludingChildren());
                }
            }
            return list;
        }
        //We are only working with dates in TunityActivity
        public DateTime BeginDate
        {
            get
            {
                return base.BeginTime.Date;
            }
            set
            {
                base.BeginTime = value.Date;
            }
        }

        //We are only working with dates in TunityActivity
        //But we want to end in the end of the day
        public DateTime EndDate
        {
            get
            {
                return base.EndTime.Date;
            }
            set
            {
                //base.EndTime = value.Date.AddDays(1).Subtract(new TimeSpan(0,0,1));
            }
        }


        /// <summary>
        /// The numeric representation of the color to use when 
        /// displaying the activity in e.g. the Gantt Scheme.
        /// </summary>
        public int Color;

        /// <summary>
        /// The creator of the activity
        /// </summary>
        [Obsolete("There is a modification object tied to this activity instead")]
        public Person Creator;

        /// <summary>
        /// Subname for the activity
        /// </summary>
        public String Product;

        /// <summary>
        /// Comments for the event
        /// </summary>
        public String Comments;


        //The ca,paign this activity belongs to
        public Campaign Campaign;


        /// <summary>
        /// Comments for the event
        /// </summary>
        public String ProjectID;

        /// <summary>
        /// Comments for the event
        /// </summary>
        public String SurveyID;
        
        
        /// <summary>
        /// Comments for the event
        /// </summary>
        [Obsolete("1")]
        public Decimal Budget;
        /// <summary>
        /// Comments for the event
        /// </summary>
        [Obsolete("1")]
        public Decimal Result;
        /// <summary>
        /// Comments for the event
        /// </summary>
        [Obsolete("1")]
        public Decimal BudgetChildren;
        /// <summary>
        /// Comments for the event
        /// </summary>
        [Obsolete("1")]
        public Decimal ResultChildren;

        /// <summary>
        /// True if a reminder is sent.
        /// </summary>
        public Boolean StartReminderSent;

        /// <summary>
        /// True if a reminder is sent.
        /// </summary>
        public Boolean StopReminderSent;

        /// <summary>
        /// How far in advance before event ends shall a reminder be sent.
        /// </summary>
        public ulong StopReminderTime;

        /// <summary>
        /// How far in advance before event ends shall a reminder be sent.
        /// </summary>
        public ulong StartReminderTime;


        #region Modifications
        //***************************************************************************
        //* Keep track of events and modifications that happens to this Activity
        //***************************************************************************
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

        /// <summary>
        /// The modifications connected to this event
        /// </summary>
        public IEnumerable<ActivityEvent> ActivityEvents
        {
            get
            {
                return Db.SQL<ActivityEvent>("SELECT a FROM ActivityEvent a WHERE a.Activity=?", this);
            }
        }

        /// <summary>
        /// Returns the activityevents on this activity sorted
        /// with the latest first
        /// </summary>
        public IEnumerable<ActivityEvent> LatestActivityEvents
        {
            get
            {
                /*TODO
                SqlEnumerator<ActivityEvent> sql = Sql.GetEnumerator<ActivityEvent>(
                    "SELECT ae FROM Concepts.Ring8.Tunity.ActivityEvent ae "+
                    "WHERE ae.Activity=variable(Concepts.Ring8.Tunity.TunityActivity, ta) "+
                    "ORDER BY ae.EndTime DESC");
                sql.SetVariable("ta", this);
                return sql;
                 * */
                return null;
            }
        }


        public ActivityEvent AddToActivityEvents(Modification mod)
        {

            if ((this.LatestUpdated == null) || (mod.Time > this.LatestUpdated))
            {
                _latestUpdated = mod.Time;
                _latestModification = mod;
            }
        
            //First try to add it to an existing AEvent
            foreach (ActivityEvent aEvent in ActivityEvents)
            {
                if (aEvent.CanTakeModification(mod))
                {
                    mod.AddTarget(aEvent);
                    return aEvent;
                }
            }

            //Otherwise create new
            return new ActivityEvent(this, mod);
        }

        public void ModificationAdded(Modification mod)
        {
            if ((this.LatestUpdated == null) || (mod.Time > this.LatestUpdated))
            {
                _latestModification = mod;
                this.LatestUpdated = mod.Time;
            }
        }



        public void ModificationRemoved(Modification mod)
        {
            DateTime time = DateTime.MinValue;
            foreach (ActivityEvent ev in ActivityEvents)
            {
                if (ev.EndTime > time)
                {
                    time = ev.EndTime;
                }
            }
            if (time > DateTime.MinValue)
            {
                LatestUpdated = time;
            }

            //Done automatically with the IModificationTarget interface
            //RemoveFromActivityEvents(mod);
        }
        

        #endregion



        /// <summary>
        /// List of active documents that belongs to the activity.
        /// </summary>
        public IEnumerable<Document> Documents
        {
            get
            {
                foreach(Document doc in RelatedObjects<Document, DocumentOwner>())
                {
                    if (doc.ObjectState == Tunity.ObjectState.Active)
                    {
                        yield return doc;
                    }
                }
            }
        }
     
        /// <summary>
        /// List of documents with the given states that belongs to the activity.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        public IEnumerable<Document> GetDocuments(ObjectState[] states)
        {
            foreach (Document doc in RelatedObjects<Document, DocumentOwner>())
            {
                if (Array.Exists(states, element => element == doc.ObjectState))
                {
                    yield return doc;
                }
            }
        }

        
        /// <summary>
        /// List of active todos that belongs to the activity
        /// </summary>
        public IEnumerable<Todo> Todos
        {
            get
            {
                return Db.SQL<Todo>("SELECT a FROM Todo a WHERE a.Active=true AND a.Activity=?", this);
            }
        }
        
        /// <summary>
        /// List of todos with the given states that belongs to the activity. 
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        public IEnumerable<Todo> GetTodos(ObjectState[] states)
        {
            SqlResult<Todo> sql =  Db.SQL<Todo>("SELECT a FROM Todo a WHERE a.Activity=?", this);
            foreach (Todo t in sql)
            {
                if (Array.Exists(states, element => element == t.ObjectState))
                    yield return t;
            }
        }

        /// <summary>
        /// Labels
        /// </summary>
        public IEnumerable<ActivityLabel> Labels
        {
            get
            {
                return ImplicitlyRelatedObjects<ActivityLabel, ActivityLabelRelation>();
            }
        }

        public void AddLabel(ActivityLabel label)
        {
            ActivityLabelRelation rel =  this.ImplicitRelationTo<ActivityLabelRelation>(this);
            if (rel == null)
            {
                rel = new ActivityLabelRelation(label, this);
            }
        }


        public Boolean HasLabel(ActivityLabel label)
        {
            return (this.ImplicitRelationTo<ActivityLabelRelation>(this) != null);
        }

        public Boolean HasParticipant(Person person)
        {
            return (this.ImplicitRelationTo<Participant>(person)) != null;
        }

        public void RemoveParticipant<T>(Person person) where T:Participant
        {
            T p = this.ImplicitRelationTo<T>(person);
            foreach (T t in this.ImplicitRelationsTo<T>(person))
            {
                t.Delete();
            }
        }


        public Boolean HasParent(TunityActivity activity)
        {
            if (this == activity)
                return true;
            else if (Parent != null)
            {
                return Parent.HasParent(activity);
            }
            else
                return false;
        }

        public void RemoveLabel(ActivityLabel label)
        {
            ActivityLabelRelation rel = label.RelationTo<ActivityLabelRelation>(this);
            if (rel != null)
            {
                rel.Delete();
            }
        }



        /// <summary>
        /// Keeps extradata that is "special solutions" for certain customers
        /// </summary>
        private ExtraCustomerData _extraData;
        public ExtraCustomerData ExtraData
        {
            get
            {
                if (_extraData != null)
                    return _extraData;
                else
                {
                    _extraData = new ExtraCustomerData();
                    return _extraData;
                }
            }

        }




        protected override void OnDelete()
        {
            foreach (ActivityEvent ev in ActivityEvents)
            {
                ev.Delete();
            }
            foreach (Role role in Roles<Role>())
            {
                role.Delete();
            }
            base.OnDelete();
        }
    }
}
