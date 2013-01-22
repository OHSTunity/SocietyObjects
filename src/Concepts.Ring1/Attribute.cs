/*
 * Society Objects Mark II
 * 
 * value should be of type Object, not Something. Check with Carl.
 * 
 * Add field OwnerKind to Attribute.Kind with the type Something.Kind
 */

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;


namespace Concepts.Ring1
{
    /// <summary>
    /// In computing, attributes are entities that define properties 
    /// of objects, elements, or files. Attributes usually consist of 
    /// a name (or key) and value.
    /// </summary>
    public abstract class Attribute : Something
    {
        private Something _owner;

        /// <summary>
        /// Type references this attribute, owner of this attribute.
        /// </summary>
        [SynonymousTo("_owner")]
        public readonly Something Owner;
        
        /// <summary>
        /// Set the owner of this attribute
        /// </summary>
        public virtual void SetOwner(Something owner)
        {
            _owner = owner;
        }

        private Something _value;

        /// <summary>
        /// Value of this attribute.
        /// </summary>
        [SynonymousTo("_value")]
        public readonly Something Value;

        /// <summary>
        /// Set the value of this attribute.
        /// </summary>
        public virtual void SetValue(Something value)
        {
            _value = value;
        }

    }
}
