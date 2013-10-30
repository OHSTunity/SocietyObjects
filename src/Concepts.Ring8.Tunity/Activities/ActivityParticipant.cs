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
using Starcounter;

namespace Concepts.Ring8.Tunity
{
   public class ActivityParticipant : Concepts.Ring1.Participant
    {
       public ActivityParticipant()
       {
           Responsible = false;
       }

       public Boolean Responsible;
       public Boolean SendReminder;
       public DateTime LastViewed;

       [SynonymousTo("ToWhat")]
       public TunityActivity Activity;
    }
}
