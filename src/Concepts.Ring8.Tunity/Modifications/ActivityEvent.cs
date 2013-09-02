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
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    ///  /// This one includes a collection (one or many) of modifications made to a activity
    /// The collection consists of every change a certain user has made within a certain time limit
    /// This is to avoid notification of every single thing a user makes
    /// </summary>
    public class ActivityEvent: Event, IModificationTarget
    {
        private static TimeSpan TIME_LIMIT = TimeSpan.FromMinutes(20);

/*        public ActivityEvent(TunityActivity activity)
        {
            Activity = activity;
        }*/

        public ActivityEvent(TunityActivity activity, Modification firstMod)
        {
            Activity = activity;
            Person = firstMod.Modifier;
            BeginTime = firstMod.Time;
            firstMod.AddTarget(this);
        }
        
        public TunityActivity Activity;
        
        /// <summary>
        /// The person that made the event happen
        /// </summary>
        public Person Person;


        public Boolean CanTakeModification(Modification mod)
        {
            //Must have been done by the same person
            if (mod.Modifier != Person)
            {
                return false;
            }

            //Must be within a certain time limit
            if (mod.Time > EndTime.Add(TIME_LIMIT))
            {
                return false;
            }

            return true;
        }


        public void ModificationAdded(Modification newMod)
        {
            EndTime = newMod.Time;
        }

        public void ModificationRemoved(Modification mod)
        {
        }

        public Boolean Empty()
        {
            return (this.RelatedObject<Modification, ModificationTarget>() == null);
        }
        
        public IEnumerable<Modification> Modifications
        {
            get
            {
                return this.RelatedObjects<Modification, ModificationTarget>();
            }
        }



       
    }
}
