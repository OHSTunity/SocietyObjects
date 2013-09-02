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
    /// A campaign, can include one or several member activities (Organizer) aswell as productions (warehouse)
    /// </summary>
    public class Campaign : Something
    {

        public IEnumerable<TunityActivity> Activities
        {
            get
            {
                return Db.SQL<TunityActivity>("SELECT a FROM TunityActivity a WHERE a.Campaign=?", this);
            }
        }

        public IEnumerable<Production> Productions
        {
            get
            {
                return Db.SQL<Production>("SELECT a FROM Production a WHERE a.Campaign=?", this);
            }
        }
    }
}
