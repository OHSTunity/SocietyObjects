/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Attributes/ReminderTime.cs#3 $
      $DateTime: 2009/10/08 13:14:28 $
      $Change: 25901 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring8.Tunity.Attributes
{
    public class ReminderTime : Something 
    {
       

        /// <summary>
        /// A long representing the time value //Represent it with ticks or by just a value from 1 and up?
        /// </summary>
        public ulong TimeValue;

        /// <summary>
        /// Holds the display name of this time, is translated per user and therefore
        /// not stored.
        /// </summary>
        [Transient]
        public String DisplayName;

        public int CompareTo(object obj)
        {
            ReminderTime secTime = obj as ReminderTime;
            String thisTimeAsStr = (DisplayName != null) ? DisplayName : (Name != null) ? Name : "";
            String secTimeAsStr = (secTime.DisplayName != null) ? secTime.DisplayName : (secTime.Name != null) ? secTime.Name : "";

            return thisTimeAsStr.CompareTo(secTimeAsStr);
        }
    }
}
