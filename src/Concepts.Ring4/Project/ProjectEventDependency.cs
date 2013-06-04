using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring4
{
    //public class ProjectEventDependency : EventDependency
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <seealso cref="EventDependency.Kind"/>
    //    public new class Kind : EventDependency.Kind
    //    {
    //        /// <summary>
    //        /// When must the dependent event kind start?
    //        /// </summary>
    //        public EventRelationalDependency Dependency;

    //        /// <summary>
    //        /// When does the event kind start in case occurance on i.e. weekend
    //        /// </summary>
    //        public EventBeginRoundOff RoundOff;

    //        /// <summary>
    //        /// In relation to the superior event kind, when does this event start?
    //        /// </summary>
    //        public TimeSpan Offset;

    //        public ProjectEventDependency.Kind ConnectProjectEventDependencyKinds(ProjectEvent.Kind superset, ProjectEvent.Kind subset)
    //        {
    //            ProjectEventDependency.Kind dependency = Kind.GetInstance<ProjectEventDependency.Kind>().Derive() as ProjectEventDependency.Kind;
    //            dependency.Subset = subset;
    //            dependency.Superset = superset;
    //            dependency.Offset = new TimeSpan(0, 0, 0, 0, 0);

    //            return dependency;
    //        }

    //        public ProjectEventDependency ConnectProjectEventDependency(ProjectEvent superset, ProjectEvent subset)
    //        {
    //            ProjectEventDependency dependency = New() as ProjectEventDependency;
    //            dependency.SetSubSet(subset);
    //            dependency.SetSuperSet(superset);
    //            return dependency;
    //        }
    //    }

    //    protected override void OnNew()
    //    {
    //        base.OnNew();

    //        // Copy the values from the Kind
    //        ProjectEventDependency.Kind kind = InstantiatedFrom as ProjectEventDependency.Kind;
    //        Dependency = kind.Dependency;
    //        RoundOff = kind.RoundOff;

    //        // Assure that we dont get a negative offset
    //        if (kind.Offset.Ticks > 0)
    //        {
    //            Offset = new TimeSpan(kind.Offset.Days, kind.Offset.Hours, kind.Offset.Minutes, kind.Offset.Seconds, kind.Offset.Milliseconds);
    //        }
    //        else
    //        {
    //            Offset = new TimeSpan(0, 0, 0, 0, 0);
    //        }
    //    }


    //    /// <summary>
    //    /// When must the dependent event start?
    //    /// </summary>
    //    public EventRelationalDependency Dependency;

    //    /// <summary>
    //    /// When does the event start in case occurance on i.e. weekend
    //    /// </summary>
    //    public EventBeginRoundOff RoundOff;

    //    /// <summary>
    //    /// In relation to the superior event, when does this event start?
    //    /// </summary>
    //    public TimeSpan Offset;


    //    // TODO: MustBeginOnTimeOfDay, MustBeginOnDayOfWeek, MustBeginOnWeekOfMonth, MustBeginOnMonthOfYear, etc...
    //}

    //public enum EventRelationalDependency
    //{
    //    None,
    //    StartAfter,
    //    StartBefore,
    //    FinnishAfter,
    //    FinnishBefore
    //}

    //public enum EventBeginRoundOff
    //{
    //    Down,
    //    Up,
    //    Closest
    //}
}
