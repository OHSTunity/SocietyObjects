/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Customer.cs#7 $
      $DateTime: 2009/03/06 15:26:55 $
      $Change: 20137 $
      $Author: hentil $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// Somebody who uses  somebodys goods or services.
    /// The ToWhom is automatically considered a supplier since we can be a Customer.
    /// </summary>
    /// <ontlogy>
    /// <equal>wordnet:07559990</equal>
    /// </ontlogy>
    public class Customer : Consumer
    {
        public new class Kind : Consumer.Kind
        {
            
        }

        [SynonymousTo("ConsumerID")]
        public String CustomerID;
    }
}
