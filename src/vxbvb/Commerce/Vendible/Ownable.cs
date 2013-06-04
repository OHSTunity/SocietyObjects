/*
 * Society Objects 2.0.
 * Status: OwnerChanged needs to go.
 */


using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;

namespace Concepts.Ring2
{
    /// <summary>
    /// 
    /// </summary>
    public class Ownable : Role
    {
        #region Kind
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        /// <seealso cref="Role.Kind"/>
        public new class Kind : Role.Kind 
        {
            /// <summary>
            /// 
            /// </summary>
            public Something WhatIs;
        }
        #endregion

        public void SetOwner(Somebody owner)
        {
            // NOT LEGAL. WHY ONLY EVENT ON THIS ATTRIBUTE? WHAT MAKES IT DIFFERENT FROM A RING2 PERSPECTIVE?
            OwnerChanged = DateTime.Now;
            OnOwnerChanged(owner);
            Owner = owner;
        }

        /// <summary>
        /// NOT LEGAL. WHY ONLY EVENT ON THIS ATTRIBUTE? WHAT MAKES IT DIFFERENT FROM A RING2 PERSPECTIVE?
        /// Called when the owner has changed.
        /// </summary>
        /// <param name="Owner">The new owner</param>
        protected virtual void OnOwnerChanged(Somebody Owner)
        {
        }

        /// <summary>
        /// NOT LEGAL. WHY IS THE CHANGE DATE MORE IMPORTANT ON THIS ATTRIBUTE THAN ON ANY OTHER FROM
        /// A RING 2 PERSPECTIVE?
        /// The datetime when the owner was changed.
        /// </summary>
        public DateTime OwnerChanged;

    }
}

