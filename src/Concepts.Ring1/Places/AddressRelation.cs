/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Places/AddressRelation.cs#8 $
      $DateTime: 2009/06/11 18:24:17 $
      $Change: 22817 $
      $Author: freblo $
      =========================================================
*/


using System;
using System.Collections;
using System.Collections.Generic;
using Starcounter;
using System.Text;

namespace Concepts.Ring1
{
    /// <summary>
    /// Descripts the roles an address can play in relation to different somethings. For instance, a
    /// street address may be the home address of somebody. Ofcourse, the very same address may
    /// also be the home address to somebody else, thus can there an address have many roles
    /// (e.g. there may be many AbstractAddresRole objects with the same somebody in the WhatIs
    /// properties).
    /// </summary>
    /// <remarks>
    /// As always with roles, the relation may be described from two viewpoints, e.g. when
    /// Person that have the role as an Employee to a Company the company should also have the
    /// role as an Employer to the Person. Obviously, from a database point of view, this is
    /// somewhat redundant. To avoid such redundancy, when two roles mutually gives the
    /// existance of the other and when a parent/child or master/detail relationship can be
    /// identified, the role that is attributed to the child should be used and the role
    /// attributed to the parent should be exclused. In the case of the Employer/Employee, the
    /// role Employee should be used with the Person
    /// </remarks>
    public abstract class AddressRelation : Relation
    {

        /// <summary>
        /// The object addressed by the Address
        /// </summary>
        [SynonymousTo("ToWhat")]
        public Something Addressee;
       


        /// <summary>
        /// The Address addressing the Addressee
        /// </summary>
        [SynonymousTo("WhatIs")]
        public Address Address;
       
        


        /// <summary>
        /// If this address relation is the default relation.
        /// </summary>
        public bool IsDefault;

        public void SetAsDefault()
        {
            IsDefault = true;
        }

        public void UnsetAsDefault()
        {
            IsDefault = false;
        }
    }
}
