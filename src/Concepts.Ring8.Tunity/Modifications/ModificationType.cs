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
    /// Enum is used for easy access, BUT modification type is stored as STRING
    /// not as enum. This is because we don't want problems when adding/deleting
    /// enum keys. 
    /// </summary>
    public enum ModificationType
    {
        UNKNOWN = 0,
        ACTIVITY = 20,
        DOCUMENT   = 30,
        TODO = 40,
        COMMENT = 50,
        TIMESHEET = 60,
        TIMEPLANNING = 61
     }
}
