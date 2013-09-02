/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/User/ParticipatingThingInfo.cs#7 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/


using System;
using Concepts.Ring1;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Extension to class ParticipatingThing to handle if an Event has been viewed by the user.
    /// </summary>
    public sealed class TunityParticipant : ParticipatingThing
    {
        public Boolean SendReminder;

        public DateTime LastViewed;
    }
}
