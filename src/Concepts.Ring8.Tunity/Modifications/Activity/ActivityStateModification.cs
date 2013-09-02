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
    public class ActivityStateModification: ObjectStateModification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ActivityStateModification(DateTime time, Person modifier, TunityActivity activity):
            base(time, modifier, ModificationType.ACTIVITY, activity.ObjectState)
        {
            Activity = activity;
            if (Activity != null)
            {
                ActivityName = activity.Name;
                this.AddTarget(Activity);
            }
        }

        [SynonymousTo("Data")]
        public TunityActivity Activity;

        [SynonymousTo("Description")]
        public String ActivityName;
        
        public override CombineResult HowToCombine(Modification mod)
        {
            return CombineResult.NoCombine;
        }

        public override String LongDescription
        {
            get
            {
                if (NewState == ObjectState.Active)
                {
                    return "";//"";// String.Format(
                         //Yesugi.ResourceManager.GetString("Modification.ActivityAdded"));
                }
                else if (NewState == ObjectState.Archived)
                {
                    return "";//"";// String.Format(
                         //Yesugi.ResourceManager.GetString("Modification.ActivityArchived"));
                }
                else
                {
                    return "";//"";// String.Format(
                         //Yesugi.ResourceManager.GetString("Modification.ActivityRemoved"));
                }
            }
        }

        
    }
}
