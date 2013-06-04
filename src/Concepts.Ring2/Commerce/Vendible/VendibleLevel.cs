using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    public class VendibleLevel : CategoryLevel
    {
       
        protected bool _canBeOrdered;
        /// <summary>
        /// Readonly flag that is set through the constructor.
        /// </summary>
        [SynonymousTo("_canBeOrdered")]
        public readonly bool CanBeOrdered;

        /* TODO
        /// <summary>
        /// Assures that this level has a lower level of the given kind and name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public virtual T AssureLowerByNameAndKind<T>(string name, VendibleLevel.Kind kind) where T : VendibleLevel
        {
            T level = kind.FindByNameAndParentLevel<T>(name, this);

            if (level == null)
            {
                level = kind.New<T>();
                level.Name = name;
                LowerLevel = level;
                level.HigherLevel = this;
            }
            else
            {
                if (level != LowerLevel)
                {
                    LowerLevel = level;
                }
                if (level.HigherLevel != this)
                {
                    level.HigherLevel = this;
                }
            }

            return level;
        }
        */
        /*TODO
        /// <summary>
        /// Assures that this level has a lower level of the same kind with the given name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual T AssureLowerByName<T>(string name) where T : VendibleLevel
        {
            VendibleLevel.Kind kind = (InstantiatedFrom as VendibleLevel.Kind);
            T level = kind.FindByName<T>(name);

            if (level == null)
            {
                level = kind.New<T>();
                level.Name = name;
                LowerLevel = level;
                level.HigherLevel = this;
            }
            else
            {
                if (level != LowerLevel)
                {
                    LowerLevel = level;
                }
                if (level.HigherLevel != this)
                {
                    level.HigherLevel = this;
                }
            }

            return level;
        }
        */

        // TODO Units, why do we need both is group and can be ordered??
        ///// <summary>
        ///// Tells is this is a group or not.
        ///// </summary>
        //[SynonymousTo("_isGroup")]
        //public readonly bool IsGroup;

        //protected bool _isGroup;
    }
}
