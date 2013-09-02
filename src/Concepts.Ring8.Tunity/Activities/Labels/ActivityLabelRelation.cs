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
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Connection between Label and activity
    /// </summary>
    public class ActivityLabelRelation : Relation
    {
       
        public ActivityLabelRelation()
        {
        }

        public ActivityLabelRelation(ActivityLabel label, TunityActivity activity)
        {
            SetWhatIs(label);
            SetToWhat(activity);
        }


        [SynonymousTo("WhatIs")]
        public readonly ActivityLabel Label;

        [SynonymousTo("ToWhat")]
        public readonly TunityActivity Activity;
    }
}
