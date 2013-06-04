/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/CustomerClaimee.cs#1 $
      $DateTime: 2007/04/11 12:03:59 $
      $Change: 3195 $
      $Author: careri $
      =========================================================
*/

using System;
using System.Collections.Generic;
using Ring1;
using Starcounter.Data;
using Ring2;

namespace Ring2
{
    /// <summary>
    /// Someone who pays for goods or service.
    /// <ontology>
    /// <equal>wordnet:09836374</equal>
    /// </ontology>
    /// </summary>
	public class CustomerClaimee : ConsumerClaimee
	{
		#region Kind class
		/// <summary>
		/// 
		/// </summary>
        /// <seealso cref="ConsumerClaimee.Kind"/>
		public new class Kind : ConsumerClaimee.Kind { }
		#endregion


        [RelatesTo(typeof(AffiliatedPerson), "ToWhat")]
        public ICollection<AffiliatedPerson> AffiliatedPersons;
	}
}
