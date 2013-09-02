/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/Accessible.cs#2 $
      $DateTime: 2008/12/12 07:46:28 $
      $Change: 17466 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring4;


namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// 
    /// </summary>
    public class ParticipantsAddedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ParticipantsAddedModification(DateTime time, Person modifier,
            TunityActivity activity, List<Person> participants):
            base(time, modifier, ModificationType.ACTIVITY)
        {
            AddTarget(activity);
            Activity = activity;
            foreach (Person participant in participants)
            {
                new ModParticipant(this, participant);
            }
        }

        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ParticipantsAddedModification(DateTime time, Person modifier,
            TunityActivity activity, Person participant) :
            base(time, modifier, ModificationType.ACTIVITY)
        {
            AddTarget(activity);
            Activity = activity;
            new ModParticipant(this, participant);
        }

        [SynonymousTo("Data")]
        public TunityActivity Activity;

        public IEnumerable<Person> Participants
        {
            get
            {
                return ImplicitlyRelatedObjects<Person, ModParticipant>();
            }
        }

        public ModParticipant AddParticipant(Person person)
        {
            ModParticipant mp = this.ImplicitRelationTo<ModParticipant>(person);
            if (mp == null)
            {
                return new ModParticipant(this, person);
            }
            else
            {
                return mp;
            }
        }

        public Boolean RemoveParticipant(Person person)
        {
            ModParticipant mp = this.ImplicitRelationTo<ModParticipant>(person);
            if (mp != null)
            {
                mp.Delete();
                return true;
            }
            return false;
        }

        public Boolean Empty
        {
            get
            {
                return this.ImplicitRole<ModParticipant>() == null;
            }
        }

        public override CombineResult HowToCombine(Modification mod)
        {
            if (mod is ParticipantsAddedModification) //Combine
            {
                foreach (Person person in Participants)
                {
                    (mod as ParticipantsAddedModification).AddParticipant(person);
                }
                return CombineResult.RemoveMe;
            }
            else if (mod is ParticipantsRemovedModification)
            {
                foreach (Person person in (mod as ParticipantsRemovedModification).Participants)
                {
                    if (RemoveParticipant(person))
                    {
                        (mod as ParticipantsRemovedModification).RemoveParticipant(person);
                    }
                }
                Boolean mEmpty = (mod as ParticipantsRemovedModification).Empty;
                Boolean thisEmpty = Empty;
                if (mEmpty && thisEmpty)
                {
                    return CombineResult.RemoveBoth;
                }
                else if (mEmpty)
                {
                    return CombineResult.RemoveHim;
                }
                else if (thisEmpty)
                {
                    return CombineResult.RemoveMe;
                }
            }
            return CombineResult.NoCombine;
        }


        public override String LongDescription
        {
            get
            {
                String result ="";// String.Format(
                   // Yesugi.ResourceManager.GetString("Modification.ParticipantsAdded"));
                List<String> names = new List<string>();
                foreach (Person person in Participants)
                {
                    names.Add(person.FullName);
                }
                int count = 0;
                foreach (String name in names)
                {
                    count++;
                    if (count == 1)
                    {
                        result += " " + name;
                    }
                    else if (count == names.Count)
                    {
                        result += " " +// Yesugi.ResourceManager.GetString("Modification.And") +
                            " " + name;
                    }
                    else
                    {
                        result += ", " + name;
                    }
                }
                return result;
            }
        }

        protected override void OnDelete()
        {
            foreach (ModParticipant mp in ImplicitRoles<ModParticipant>())
            {
                mp.Delete();
            }
            base.OnDelete();
        }


    }
}
