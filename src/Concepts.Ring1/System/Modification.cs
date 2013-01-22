// Move to Ring1.System subfolder
using System;
using System.Linq;
using System.Collections.Generic;
using Starcounter;

namespace Concepts.Ring1
{
    public class Modification : ObjectChange
    {
        /*
        public new class Kind : ObjectChange.Kind 
        {
            public class PreparedStatements
            {
                public static readonly SqlPrepared FindModificationsNewerThan;
                public static readonly SqlPrepared FindModificationsOlderThan;
                public static readonly SqlPrepared FindModificationsBetweenDates;

                public const string EndTimeField = "endtime";
                public const string BeginTimeField = "begintime";

                static PreparedStatements()
                {
                    string combinedIndexBase = string.Format(
                        "SELECT v FROM {0} v WHERE v.EndTime>VAR(Int32, {1})",
                        Kind.GetInstance<Modification.Kind>().FullInstanceClassName,
                        EndTimeField);

                    combinedIndexBase = string.Format(
                        "SELECT v FROM {0} v WHERE v.EndTime<VAR(Int32, {1})",
                        Kind.GetInstance<Modification.Kind>().FullInstanceClassName,
                        EndTimeField);

                    combinedIndexBase = string.Format(
                        "SELECT v FROM {0} v WHERE v.EndTime>VAR(Int32, {1}) AND v.EndTime<VAR(Int32, {2})",
                        Kind.GetInstance<Modification.Kind>().FullInstanceClassName,
                        BeginTimeField,
                        EndTimeField);
                }
            }
        
    


            /// <summary>
            /// Logs a modification without specifying the attribute/variablename
            /// </summary>
            /// <param name="something"></param>
            /// <param name="systemuser"></param>
            /// <returns></returns>
            public Modification LogModification(Something something, Something modifier)
            {
                return LogModification(something, modifier, null, null, null);
            }

            /// <summary>
            /// Logs a modification for the attribute/variablename of the given object and user.
            /// </summary>
            /// <param name="something"></param>
            /// <param name="systemuser"></param>
            /// <param name="variableName"></param>
            /// <param name="newValue"></param>
            /// <param name="oldValue"></param>
            /// <returns></returns>
            public Modification LogModification(Something something, Something modifier, String variableName, String newValue, String oldValue)
            {
                Modification modification = (Modification)Activator.CreateInstance(this.GetType());
                modification.BeginTime = DateTime.Now;
                modification.AssureParticipant<Modifier>(modifier);
                modification.AddModified(something, variableName, newValue, oldValue);
                modification.EndTime = modification.BeginTime;

                return modification;
            }

            /// <summary>
            /// Gets the latest modification for the given something.
            /// </summary>
            /// <param name="something"></param>
            /// <returns></returns>
            public T Latest<T>(Something something) where T : Modification
            {
                T latest = null;
                DateTime latestDate = DateTime.MinValue;

                foreach (Modified modifiedRole in something.Roles<Modified>())
                {
                    Modification mod = modifiedRole.Modification;

                    if (mod is T && mod.EndTime > latestDate)
                    {
                        latestDate = mod.EndTime;
                        latest = (T)mod;
                    }
                }
                
                return latest;
            }


        */

        public IEnumerable<T> Modified<T>() where T : Modified
        {
            return ImplicitRoles<T>();
        }

       
        /// <summary>
        /// The reason for this modification.
        /// </summary>
        public virtual string Reason
        {
            get
            {
                var reason = Description;

                if (string.IsNullOrEmpty(reason))
                {
                   // reason = ResourceManager.GetString(GetType().FullName);
                }
                return reason;
            }
        }
        

        /// <summary>
        /// Adds a modified variable to this modification.
        /// </summary>
        /// <param name="something"></param>
        /// <param name="variableName"></param> 
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        public virtual Modified AddModified(Something something, String variableName, String newValue, String oldValue)
        {
            bool hasVariableName = !string.IsNullOrEmpty(variableName);
            Modified modified = null;

            if (!hasVariableName)
            {
                // With no variable name defined we can only have one modifed relation per something.
                modified = AssureParticipant<Modified>(something);    
            }
            else
            {
                foreach (Modified mod in something.RelationsTo<Modified>(this))
                {
                    if (mod.Attribute == null &&
                        string.IsNullOrEmpty(mod.NewValue) &&
                        string.IsNullOrEmpty(mod.OldValue))
                    {
                        modified = mod;
                        break;
                    }
                }
                if (modified == null)
                {
                    modified = something.Relate<Modified>(this);
                }
                modified.Attribute = null;//TODO :Kind.GetInstance<ModifiedAttribute.Kind>().AssureKind<ModifiedAttribute.Kind>(variableName, owningKind, null);
                modified.OldValue = oldValue;
                modified.NewValue = newValue;
            }

            return modified;
        }

        /// <summary>
        /// Returns a collection of the modifiers for this modification.
        /// </summary>
        public IEnumerable<T> Modifiers<T>() where T : Modifier
        {
            return ImplicitRoles<T>();
        }


    }
}
