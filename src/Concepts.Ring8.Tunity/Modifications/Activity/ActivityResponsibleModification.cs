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
    public class ActivityResponsibleModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ActivityResponsibleModification(DateTime time, Person modifier,
            TunityActivity activity, Person oldResponsible):
            base(time, modifier, ModificationType.ACTIVITY)
        {
            Activity = activity;
            NewResponsible = activity.Responsible;
            OldResponsible = oldResponsible;
            AddTarget(activity);
        }

        [SynonymousTo("Data")]
        public TunityActivity Activity;

        public Person NewResponsible;
        public Person OldResponsible;

        public override CombineResult HowToCombine(Modification mod)
        {
            ActivityResponsibleModification nm = mod as ActivityResponsibleModification;
            if ((nm != null) && (nm.Activity == this.Activity))
            {
                if (nm.NewResponsible == this.OldResponsible)
                {
                    return CombineResult.RemoveBoth;
                }
                else
                {
                    nm.OldResponsible = this.OldResponsible;
                    return CombineResult.RemoveMe;
                }
            }
            return CombineResult.NoCombine;
        }

        public override String ShortDescription
        {
            get
            {
                return"";// String.Format(
                    // Yesugi.ResourceManager.GetString("Modification.ActivityResponsibleShort{0}"),
                     //NewResponsible != null ? NewResponsible.FullName: "none");
            }
        }

        public override String LongDescription
        {
            get
            {
                 return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.ActivityResponsible{0}"),
                      //Activity.Name);
            }
        }

       
    }
}
