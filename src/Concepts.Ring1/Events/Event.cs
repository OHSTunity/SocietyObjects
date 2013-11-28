/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Joachim Wester
 * Authors:                     Joachim Wester
 * 
 * Status:      PlannedBeginTime and PlannedEndTime. Planning is done by Somebodies. Multiple planned times can occur. Should be removed from here.
*/

using System;
using System.Collections.Generic;
using Starcounter;

namespace Concepts.Ring1
{
	/// <summary>
	/// Some activity that has taken place or will, is planned to or might take place
	/// in the future.
	/// </summary>
	/// <remarks>
	/// An Event may have one or several participants
	/// (<see cref="Somebody">Somebodies</see>), each playing a role to the activity (i.e each
	/// having one or more
	/// <see cref="Concepts.Ring1.ParticipatingThing">ActivityParticipantRoles</see>).
	/// </remarks>
	/// <example>
	/// 	<para>A phone conversation between two persons is an example of an activity. Both
	///     the person calling and the person receiving the phonecall are activity
	///     participants.</para>
	/// 	<para>There are two
    ///     <see cref="Concepts.Ring1.ParticipatingThing">ActivityParticipantRoles</see>. One is of the
	///     kind Caller and one is of the kind Receiver. The Caller object has its
	///     <see cref="SomebodiesRelation.WhoIs">WhatIs Property</see> pointing to the calling person and
	///     the Receiver object has its <see cref="SomebodiesRelation.WhoIs">WhatIs Property</see> pointing
	///     to the receiving person. Both objects has their <see cref="SomebodiesRelation.ToWhom">ToWhat
	///     properties</see> pointing to the activitiy.</para>
	/// 	<code lang="CS" title="A Phone call">
	/// Person jack = new Person(); // TODO. How do I find a person.
	/// Person nick = new Person(); // TODO. How do I find a person.
	///  
	/// PhoneCall call = new Phonecall(); // Phonecall extends Event
	///  
	/// Caller callerRole = new Caller(); // Caller extends ActivityParticipantRole
	/// Receiver receiverRole = new Receiver(); // Receiver extends ActivityParticipantRole // TODO! How to I use soft kinds?
	///  
	/// callerRole.WhatIs = jack;
	/// callerRole.ToWhat = call;
	///  
	/// receiverRole.WhatIs = nick;
	/// receiverRole.ToWhat = call;
	///     </code>
	/// </example>
	/// <ontlogy>
    /// <equal>wordnet17:00019484</equal>
    /// <equal>sumo:Process</equal>
    /// </ontlogy>
    public class Event : Something
	{
    

        public Event()
        {
            EndTime = DateTime.MinValue;
            BeginTime = DateTime.MinValue;
        }

		/// <summary>
		/// The point in time when this activity started happening. If it is a momentaneus activity, both <c>BeginTime</c> and
		/// <c>EndTime</c> is the same.
		/// </summary>
		public DateTime BeginTime;

		
        /// <summary>
		/// The point in time when this activity stops happening. If it is a momentaneus activity, both <c>BeginTime</c> and
		/// <c>EndTime</c> is the same.
		/// </summary>
        public DateTime EndTime;

		
		/// <summary>
		/// Tells if this is a planned or an actual event.
		/// </summary>
        public bool HasTakenPlace()
        {
            return HasBegun && HasEnded;
        }


        public bool HasBegun
        {
            get
            {
                return BeginTime > DateTime.MinValue;
            }
        }
        public bool HasEnded
        {
            get
            {
                return EndTime > DateTime.MinValue;
            }
        }
        public bool IsCurrentlyTakingPlace
        {
            get
            {
                return HasBegun && !HasEnded;
            }
        }
        public bool TookPlaceBetween(DateTime from, DateTime to)
        {
            return BeginTime > from && EndTime < to;
        }

        public virtual void BeginEvent(DateTime when)
        {
            BeginTime = when;
        }
        public virtual void EndEvent(DateTime when)
        {
            EndTime = when;
        }

        
        /// <summary>
        /// A short description of the event.
        /// </summary>
        /// <value></value>
        
        public virtual string Brief
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Converts BeginTime to a readable text.
        /// </summary>
        /// <value></value>
		
		public string BeginTimeAsString
		{
			get
			{
				if(BeginTime == DateTime.MinValue){return "";}
				return BeginTime.ToString();
			}
		}

        /// <summary>
        /// Converts EndTime to a readable text.
        /// </summary>
        /// <value></value>
		
		public string EndTimeAsString
		{
			get
			{
				if(EndTime == DateTime.MinValue){return "";}
				return EndTime.ToString();
			}
		}

        /// <summary>
        /// Converts BeginTime to a short date string.
        /// </summary>
        /// <seealso cref="DateTime.ToShortDateString"/>
        /// <value></value>
        
        public string BeginTimeAsShortDateString
        {
            get
            {
                return BeginTime.ToShortDateString();
            }
        }


        /// <summary>
        /// Converts EndTime to a short date string.
        /// </summary>
        /// <seealso cref="DateTime.ToShortDateString"/>
        /// <value></value>
		
		public string EndTimeAsShortDateString
		{
			get
			{
				return EndTime.ToShortDateString();
			}
		}

        /// <summary>
        /// Assures a participant. 
        /// </summary>
        /// <param name="roleKind">The role to assure</param>
        /// <param name="whatIs">The <c>SomebodiesRelation</c> who will be the participant</param>
        /// <returns></returns>
        public T AssureParticipant<T>(Something whatIs) where T : ParticipatingThing
        {
            T pt = this.ImplicitRelationTo<T>(whatIs);  
            if (pt == null)
            {
                pt = whatIs.Relate<T>(this);
            }
            return pt;
        }

        /// <summary>
        /// Assures a participant. 
        /// </summary>
        /// <param name="roleKind">The role to assure</param>
        /// <param name="whatIs">The <c>SomebodiesRelation</c> who will be the participant</param>
        /// <param name="checkExclusivity">Allows the caller to skip the exclusive check, e.g. to speed up relate where one of the objects is new.</param>
        /// <returns></returns>
        public T AssureParticipant<T>(Something whatIs, bool checkExclusivity) where T : ParticipatingThing
        {
            if (checkExclusivity)
            {
                return AssureParticipant<T>(whatIs);
            }
            else
            {
                return whatIs.Relate<T>(this);
            }
        }
 

       /// <summary>
       /// Assures a participant and makes it exclusive. 
       /// This method can only be used if the Participant is to be exclusive, e.g. <c>Creator</c>.
       /// </summary>
       /// <param name="roleKind">The role to assure</param>
       /// <param name="whatIs">The <c>SomebodiesRelation</c> who will be the participant</param>
       /// <returns></returns>
        public T AssureExclusiveParticipant<T>(Something whatIs) where T : ParticipatingThing
        {
            T exclusiveParticipant = null;
            QueryResultRows<T> participants = this.ImplicitRoles<T>();
            foreach (T pt in participants)
            {
                if (exclusiveParticipant == null && pt.WhatIs == whatIs)
                {
                    exclusiveParticipant = pt;
                }
                else
                {
                    pt.Delete();
                }
            }            

            if (exclusiveParticipant == null)
            {
                // No need to fetch the existing participants since they have already been processed.
                exclusiveParticipant = whatIs.Relate<T>(this);
            }
            return exclusiveParticipant;
        }
	    

       /// <summary>
       /// Removes a participant. 
       /// </summary>
       /// <param name="roleKind">The role to assure</param>
       /// <param name="whatIs">The <c>SomebodiesRelation</c> who will be the participant</param>
       /// <returns></returns>
        public void RemoveParticipant(Something whatIs)
       {
           ParticipatingThing pt = whatIs.RelationTo<ParticipatingThing>(this);
           if (pt != null)
           {
               pt.Delete();
           }
       }
       /// <summary>
       /// Removes all participants of a kind. 
       /// </summary>
       /// <param name="roleKind">The role to assure</param>
       /// <returns></returns>
       public void RemoveAllParticipants()
       {
           IEnumerable<ParticipatingThing> pts = this.ImplicitRoles<ParticipatingThing>();
           foreach (ParticipatingThing pt in pts)
           {
               pt.Delete();
           }
       }
        

        //protected override void OnDelete()
        //{
        //    base.OnDelete();

        //    // Remove subsets where this object is included
        //    foreach (EventDependency dependency in Roles<EventDependency>())
        //    {
        //        dependency.Delete();
        //    }
        //    foreach (EventDependency dependency in ImplicitRoles<EventDependency>())
        //    {
        //        dependency.Delete();
        //    }

        //    // Delete all EventRoles that points to this event, both superset and subset
        //    foreach (EventRole subsetRole in Supersets<EventRole>())
        //    {
        //        subsetRole.Delete();
        //    }

        //    foreach (EventRole supersetRole in Subsets<EventRole>())
        //    {
        //        supersetRole.Delete();
        //    }

        //    // Remove all participatingThing roles
        //    foreach (ParticipatingThing pThing in ParticipantRoles<ParticipatingThing>())
        //    {
        //        pThing.Delete();
        //    }

        //}
    }
}
