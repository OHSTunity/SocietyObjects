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
    /// A template for ProjectEvents, since it is a normal event it can contain the same properties
    /// </summary>
    public class TaskType : Something
    {
        public TaskType()
        {
        }

        public String FullName
        {
            get
            {
                if ((Code != "") && (Name != ""))
                {
                    return Code + ":" + Name;
                }
                else if (Code == "")
                {
                    return Name;
                }
                else
                {
                    return Code;
                }
            }
        }

        /// <summary>
        /// Most companies are using some sort of "time code" for each type of task.
        /// </summary>
        public String Code;

        /// <summary>
        /// CostPerHour
        /// </summary>
        public int CostPerHour;
    }
}
