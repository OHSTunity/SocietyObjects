/*
 * Society Objects 2.0.
 * Status: 1 method questioned.
 */

#region Using directives

using System;
using System.Collections.Generic;
using Starcounter;

#endregion

namespace Concepts.Ring1
{
    /// <summary>
    /// A Level is an abstract identifiable position in a continuum or series, i.e.
    /// a way of ordering things in a one dimensional world. Each level can be "higher" or "lower" than another level.
    /// </summary>
    /// <ontology>
    /// <equal>wordnet17:10951577</equal>
    /// </ontology>
    public class Level : Something
    {
        /// <summary>
        /// TODO: What if the level already exists? Adds a level after this level.
        /// 
        /// </summary>
        /// <returns>Added level</returns>
        private Level AddHigherLevel()
        {
            //TODO: Should use the same type as parent even if its a derived level type
            Level lev = Activator.CreateInstance(this.GetType()) as Level;
            //Not the last in this levels
            if (LowerLevel != null)
            {
                LowerLevel.HigherLevel = lev;
                lev.LowerLevel = LowerLevel;
            }

            this.LowerLevel = lev;
            lev.HigherLevel = this;
            return lev;
        }

        /// <summary>
        /// Each level may have one higher level.
        /// </summary>
        public Level HigherLevel;
        
		/// <summary>
        /// Each level may have one and only one lower level.
        /// The concept of levels is one dimensional as opposed to trees that may have multiple child nodes.
        /// </summary>
        public Level LowerLevel;

        /// <summary>
        /// Tells if this level is lower than or the same as another level.
        /// </summary>
        /// <param name="otherLevel">The Level to test this level against</param>
        /// <returns>True if this level equals otherLevel or if this level is lower in than otherLevel</returns>
        public bool IsLowerOrEqualThan(Level otherLevel)
        {
            Level next = this;

            while (next != null)
            {
                if ( next == otherLevel )
                {
                    return true;
                }
                next = next.HigherLevel;
            }
            return false;
        }

        /// <summary>
        /// Gets the highest level.
        /// </summary>
        /// <remarks>
        /// Gets the highest level in the chain of levels of this level.
        /// </remarks>
        public Level HighestLevel
        {
            get
            {
                if (HigherLevel == null)
                    return this;
                else
                    return HigherLevel.HighestLevel;
            }
        }

        /// <summary>
        /// Gets the lowest level.
        /// </summary>
        /// <remarks>
        /// Gets the lowest level in the chain of levels of this level.
        /// </remarks>
        public Level LowestLevel
        {
            get 
            {
                if (LowerLevel == null)
                    return this;
                else
                    return LowerLevel.LowestLevel;
            }
        }
	}
}
