using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    public class VendibleLevel : CategoryLevel
    {
        #region Kind class
        /// <summary>
        /// A Kind is a runtime object representing an ontology class, an sometimes a computer language class.
        /// </summary>
        /// <remarks>
        /// An instance of this class will be created automatically representing the VendibleKindLevel class.
        /// Please refer to the Society Objects introduction for more information.
        /// </remarks>
        public new class Kind : CategoryLevel.Kind
        {
            /// <summary>
            /// Assures a new top level.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="topLevelName"></param>
            /// <returns></returns>
            public virtual T AssureTop<T>(string topLevelName) where T : VendibleLevel
            {
                T topLevel = AssureByName<T>(topLevelName);

                if (topLevel == null)
                {
                    topLevel = New<T>();
                }

                return topLevel;
            }

            /// <summary>
            /// Finds a level with the given name and parent.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="name"></param>
            /// <param name="parentLevel"></param>
            /// <returns></returns>
            public virtual T FindByNameAndParentLevel<T>(string name, VendibleLevel parentLevel) where T : VendibleLevel
            {
                T level = null;
                string query = string.Format(
                    "SELECT level FROM {0} level WHERE level.HigherLevel=VAR({1}, parent) AND level.Name=VAR(String, name)",
                    FullInstanceClassName,
                    parentLevel.FullClassName);

                using (SqlEnumerator<T> levels = Sql.GetEnumerator<T>(query))
                {
                    levels.SetVariable("parent", parentLevel);
                    levels.SetVariable("name", name);

                    if (levels.MoveNext())
                    {
                        level = levels.Current;
                    }
                }

                return level;
            }
            public virtual T FindByName<T>(string name) where T : VendibleLevel
            {
                T level = null;
                string query = string.Format(
                    "SELECT level FROM {0} level WHERE level.Name=VAR(String, name)",
                    FullInstanceClassName);

                using (SqlEnumerator<T> levels = Sql.GetEnumerator<T>(query))
                {
                    levels.SetVariable("name", name);

                    if (levels.MoveNext())
                    {
                        level = levels.Current;
                    }
                }

                return level;
            }
        }
        #endregion

        protected bool _canBeOrdered;
        /// <summary>
        /// Readonly flag that is set through the constructor.
        /// </summary>
        [SynonymousTo("_canBeOrdered")]
        public readonly bool CanBeOrdered;


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

        // TODO Units, why do we need both is group and can be ordered??
        ///// <summary>
        ///// Tells is this is a group or not.
        ///// </summary>
        //[SynonymousTo("_isGroup")]
        //public readonly bool IsGroup;

        //protected bool _isGroup;
    }
}
