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
    public class ActivityStatusModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ActivityStatusModification(DateTime time,
            Person modifier, TunityActivity activity,
            ActivityStatus oldStatus):
            base(time, modifier, ModificationType.ACTIVITY)
        {
            Activity = activity;
            if (Activity != null)
            {
                ActivityName = activity.Name;
                OldStatus = oldStatus;
                NewStatus = activity.Status;
                this.AddTarget(Activity);
            }
        }

        [SynonymousTo("Data")]
        public TunityActivity Activity;

        [SynonymousTo("Description")]
        public String ActivityName;

        public ActivityStatus OldStatus;
        public ActivityStatus NewStatus;

        public override CombineResult HowToCombine(Modification mod)
        {
            ActivityStatusModification asm = mod as ActivityStatusModification;
            if (asm != null)
            {
                if (asm.NewStatus == this.OldStatus)
                {
                    return CombineResult.RemoveBoth;
                }
                else
                {
                    asm.OldStatus = this.OldStatus;
                    return CombineResult.RemoveMe;
                }
            }
            return CombineResult.NoCombine;
        }


        public override String LongDescription
        {
            get
            {
                if (NewStatus == ActivityStatus.Active)
                {
                    return"";// String.Format(
                       // Yesugi.ResourceManager.GetString("Modification.ActivityStatusReOpened"));
                }
                else if (NewStatus == ActivityStatus.Finished)
                {
                    return"";// String.Format(
                       // Yesugi.ResourceManager.GetString("Modification.ActivityStatusClosed"));
                }
                return "Modification.ActivityStatusUnknown";
            }
        }

        
    }
}
