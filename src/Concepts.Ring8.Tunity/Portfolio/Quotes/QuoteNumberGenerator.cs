/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/EventNumberGenerator.cs#9 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring4;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Class that generates a new ProjectID for an activity.
    /// 
    /// Normally just a uniqe number.
    /// 
    /// Earlier this was a single instance kind, but since we need one generator for each client/container
    /// we create one normal instance instead. (In organizer basedata on startup)
    /// 
    /// </summary>
    public class QuoteNumberGenerator : Something
    {
        
    }
}