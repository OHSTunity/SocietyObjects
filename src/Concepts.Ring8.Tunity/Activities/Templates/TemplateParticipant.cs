/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/DefaultTemplateParticipants.cs#6 $
      $DateTime: 2008/12/12 07:46:28 $
      $Change: 17466 $
      $Author: davros $
      =========================================================
*/


using Concepts.Ring1;
using System;
using Starcounter;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    public class TemplateParticipant : Concepts.Ring1.Participant
    {
        public TemplateParticipant()
        {
            Responsible = false;
        }

        public Boolean Responsible;

        [SynonymousTo("ToWhat")]
        public Template Template;
    }
}
