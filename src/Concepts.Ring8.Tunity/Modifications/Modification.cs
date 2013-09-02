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
    /// Base class for all modifications (Person that has modified something)
    /// A modification is something that has been done by a Person
    /// the target/targets can be anything
    /// ex: an added comment on a file/version affects the document and the activity as well. 
    /// 
    /// Property Name is used to store the "Type" of Modification
    /// Property Description stores the name of the modded object (if its removed later)
    /// </summary>
    public abstract class Modification: Something
    {
        public Modification()
        {}

        public Modification(DateTime time, Person modifier, ModificationType type)
        {
            Modifier = modifier;
            if (time != null)
            {
                Time = time;
            }
            else
            {
                Time = DateTime.Now;
            }
            Type = type;
         }
        
        public ModificationType Type
        {
            get
            {
                try
                {
                    return (ModificationType)Enum.Parse(typeof(ModificationType), Name, true);
                }
                catch
                {
                    return ModificationType.UNKNOWN;
                }
            }
            set
            {
                Name = Enum.GetName(typeof(ModificationType), value);
            }
        }

        public System.Collections.Generic.IEnumerable<Something>  Targets
        {
            get
            {
                return this.ImplicitlyRelatedObjects<Something, ModificationTarget>();
            }
        }

        public void AddTarget(Something target)
        {
            if (target == null)
                return;
            
            if (!HasTarget(target))
            {
                new ModificationTarget(this, target);
                if (target is IModificationTarget)
                {
                    (target as IModificationTarget).ModificationAdded(this);
                }
            }
        }



        public static IEnumerable<Modification> GetModificationsFor(Something target)
        {
            return target.RelatedObjects<Modification, ModificationTarget>();
        }

        public Boolean HasTarget(Something target)
        {
            if (target == null)
                return false;

            return this.ImplicitRelationTo<ModificationTarget>(target) != null;
        }

        public T GetTarget<T>() where T:Something
        {
            return this.ImplicitlyRelatedObject<T, ModificationTarget>();
        }

        public void RemoveTarget(Something target)
        {
            ModificationTarget mt = this.ImplicitRelationTo<ModificationTarget>(target);
            if (mt != null)
            {
                mt.Delete();         
                if (target is IModificationTarget)
                {
                    (target as IModificationTarget).ModificationRemoved(this);
                }
            }
        }

        public virtual CombineResult HowToCombine(Modification mod)
        {
            return CombineResult.NoCombine;
        }


        public T GetData<T>() where T : Something
        {
            return Data as T;
        }

        public Something Data;

        /// <summary>
        /// The person that made the modification
        /// </summary>
        public Person Modifier;
       
        /// <summary>
        /// Time for the modification
        /// </summary>
        public DateTime Time;


        /// <summary>
        /// Does not includes target
        /// </summary>
        public virtual String ShortDescription
        {
            get
            {
                return LongDescription;
            }
        }

        /// <summary>
        /// Includes target
        /// </summary>
        public virtual String LongDescription
        {
            get
            {
                return "did something unknown";
            }
        }

        /// <summary>
        /// For example the comment in a commentModification
        /// </summary>
        public virtual String ExtraData
        {
            get
            {
                return "";
            }
        }

        protected override void OnDelete()
        {
            foreach (ModificationTarget target in ImplicitRoles<ModificationTarget>())
            {
                target.Delete();
            }
            base.OnDelete();
        }

    }
}
