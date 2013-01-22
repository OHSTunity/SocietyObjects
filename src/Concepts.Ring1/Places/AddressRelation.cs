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
        public readonly Something Addressee;
        public void SetAddressee(Something addressee)
        {
            SetToWhat(addressee);
        }



        /// <summary>
        /// The Address addressing the Addressee
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Address Address;
        public void SetAddress(Address address)
        {
            SetWhatIs(address);
        }

        /// <summary>
        /// Setting of "WhatIs" property of this relation.
        /// </summary>
        /// <param name="address"></param>
        public override void SetValue(Something address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Address can not be null. A addressrelation must point to an Address");
            }
            base.SetValue(address);
        }

        /// <summary>
        /// Setting of "ToWhat" property of this relation.
        /// </summary>
        /// <param name="addressee"></param>
        public override void SetToWhat(Something addressee)
        {
            if (addressee == null)
            {
                throw new ArgumentNullException("Addressee can not be null. A addressrelation must point to an Addressee");
            }
            base.SetToWhat(addressee);
        }



        private bool _isDefault;
        /// <summary>
        /// If this address relation is the default relation.
        /// </summary>
        [SynonymousTo("_isDefault")]
        public readonly bool IsDefault;

        public void SetAsDefault()
        {
            if (!_isDefault) //Ugly to avoid fatal warning
                _isDefault = true;
           /*TODO
            * AddressRelation.Kind currentRelationKind = (AddressRelation.Kind)InstantiatedFrom;

            foreach (AddressRelation relation in ToWhat.ImplicitRoles<AddressRelation>(currentRelationKind))
            {
                relation._isDefault = relation.Equals(this);
            }
            */
        }

        public void UnsetAsDefault()
        {
            _isDefault = false;
        }
    }
}
