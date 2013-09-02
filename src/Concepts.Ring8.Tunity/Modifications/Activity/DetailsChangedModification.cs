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
    public class DetailsChangedModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public DetailsChangedModification(DateTime time, Person modifier, Something target):
            base(time, modifier, ModificationType.ACTIVITY)
        {
            Target = target;
            if (Target is IModificationTarget)
            {
                AddTarget(Target);
            }
        }

        [SynonymousTo("Data")]
        public Something Target;

        public override CombineResult HowToCombine(Modification mod)
        {
            if (mod is DetailsChangedModification)
            {
                return CombineResult.RemoveHim;
            }
            return CombineResult.NoCombine;
        }

        public override String LongDescription
        {
            get
            {
                 return"";// String.Format(
                     // Yesugi.ResourceManager.GetString("Modification.DetailsChanged"));
            }
        }

        
    }
}
