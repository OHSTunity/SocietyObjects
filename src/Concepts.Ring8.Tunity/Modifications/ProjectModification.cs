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
    /// Base class for all projectevent modifications.
    /// Lightweight modificationobject for ProjectEvents, includes Modifier and TimeStamp
    /// </summary>
    public class ProjectModification: Relation
    {
        public ProjectModification()
        {}

        public ProjectModification(Person modifier, ProjectEvent ev, ModificationType type)
        {
            SetModifier(modifier);
            SetEvent(ev);
            ModificationTime = DateTime.Now;
            Type = type;
         }

        private String _type;
        public ModificationType Type
        {
            get
            {
                try
                {
                    return (ModificationType)Enum.Parse(typeof(ModificationType), _type, true);
                }
                catch
                {
                    return ModificationType.UNKNOWN;
                }
            }
            set
            {
                _type = Enum.GetName(typeof(ModificationType), value);
            }
        }

        
        public Something Data;

        /// <summary>
        /// The person that made the modification
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Person Modifier;
        public void SetModifier(Person modifier)
        {
            SetToWhat(modifier);
        }

        /// <summary>
        /// Time for the modification
        /// </summary>
        public DateTime ModificationTime;


        /// <summary>
        /// The project that has been modified
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly ProjectEvent Event;
        public void SetEvent(ProjectEvent ev)
        {
            SetWhatIs(ev);
        }


        
    }
}
