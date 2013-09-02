/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Connection between a modification and its targets
    /// </summary>
    public class ModParticipant : Relation
    {
        
        public ModParticipant()
        {
        }

        public ModParticipant(Modification mod, Person participant)
        {
            SetWhatIs(participant);
            SetToWhat(mod);
        }


        [SynonymousTo("WhatIs")]
        public readonly Modification Modification;

        [SynonymousTo("ToWhat")]
        public readonly Person Person;
    }
}
