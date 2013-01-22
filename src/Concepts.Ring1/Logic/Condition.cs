/*
 * Society Objects 2.0.
 * Status: Check against SUMO.
 * Make abstract class.
 * Make Evaluate method abstract.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring1
{
    /// <summary>
    /// A boolean condition that may evaluate to either true or false.
    /// </summary>
    public class Condition : Something
    {
        /// <summary>
        /// A subcass of Condition should provide an evaluation method. 
        /// </summary>
        /// <param name="prerequisite">Optional information defined by a subclassed condition. Used by a derived condition as parametric data needed for the evaluation.</param>
        /// <returns>True or false</returns>
        public virtual bool Evaluate(Object prerequisite)
        {
            return true;
        }
    }
}
