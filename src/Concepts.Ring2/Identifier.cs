/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Identifier.cs#18 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/


using Concepts.Ring1;
using Starcounter;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Concepts.Ring2
{
    /// <summary>
    /// Identifiers (IDs) are lexical tokens that name entities. 
    /// The concept is analogous to that of a "name". Identifiers 
    /// are used extensively in virtually all information processing 
    /// systems. Naming entities makes it possible to refer to them, 
    /// which is essential for any kind of symbolic processing.
    /// <example>
    /// An Identifier can tie an attribute to an object, a search word for example.
    /// </example>
    /// 
    /// </summary>
    public class Identifier : Something
    {


      
        /// <summary>
        /// 
        /// </summary>
        public Something Identifies;

        /// <summary>
        /// Tells if this is the primary identifier for an object. This flag comes in handy when displaying only one identifier for an object.
        /// </summary>
        public bool IsPrimary;
    }
}
