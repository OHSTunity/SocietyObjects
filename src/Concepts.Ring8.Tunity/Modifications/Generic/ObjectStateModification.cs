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
    public abstract class ObjectStateModification: Modification
    {
        /// <summary>
        /// Add modification
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="doc"></param>
        public ObjectStateModification(DateTime time, Person modifier, ModificationType type, ObjectState state) :
            base(time, modifier, type)
        {
            NewState = state;
        }

        [SynonymousTo("Data")]
        public Something Target;

        [SynonymousTo("Description")]
        public String TargetName;

        public ObjectState NewState;
        
        public override CombineResult HowToCombine(Modification mod)
        {
            ObjectStateModification osm = mod as ObjectStateModification;
            if (osm != null)
            {
                if (this.NewState == osm.NewState)
                {
                    return CombineResult.RemoveHim;
                }
                else if (this.NewState == ObjectState.Active)
                {
                    return CombineResult.NoCombine;
                }
            }
            return CombineResult.NoCombine;
        }

    }
}
