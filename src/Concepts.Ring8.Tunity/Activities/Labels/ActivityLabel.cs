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
    /// A label that can be used to label an activity 
    /// </summary>
    public class ActivityLabel : Something
    {
      
        public ActivityLabel()
        {
            Name = "Label" + DbHelper.GetObjectID(this);
            Color = 0xAAAAAA;
        }

        public int Color;

        /// <summary>
        /// Activities that are connected to this label
        /// </summary>
        public IEnumerable<TunityActivity> Activities
        {
            get
            {
                return RelatedObjects<TunityActivity, ActivityLabelRelation>();
            }
        }

        public int ActivityCount
        {
            get
            {
                int i = 0;
                foreach (TunityActivity activity in Activities)
                {
                    i++;
                }
                return i;
            }
        }



        protected override void OnDelete()
        {
            foreach (Role role in Roles<Role>())
            {
                role.Delete();
            }
            base.OnDelete();
        }
    }
}
