/*
 * Version:                     Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Joachim Wester
 * Authors:                     Joachim Wester
 * Status:                      Release candidate
 */

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// A category should be used as a Kind. You can not create instances of categories. Instead you should derive Category.Kind.
    /// </summary>
    public class Category : Something
    {
        #region Kind
        /// <summary>
        /// A category is a logical grouping of things that have something in common. Categories can be built in hierarchies.
        /// </summary>
        /// <remarks>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </remarks>
        /// <seealso cref="Something.Kind"/>
        public new class Kind : Something.Kind 
        {
            /// <summary>
            /// Name of the category kind.
            /// </summary>
            [SynonymousTo("Name")]
            public String CategoryName;
        }
        #endregion
    }

}
