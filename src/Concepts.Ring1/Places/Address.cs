/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Joachim Wester
 * Authors:                     Joachim Wester
 * 
 * Not approved. Issues identified.
 * 
 * Status:      Should an address really be a role?
 * 
 *              3 methods questioned.
 */


using System.Collections;
using System.Collections.Generic;
using System;
using Starcounter;



namespace Concepts.Ring1
{
	/// <summary>
	/// A structured identifier for a spatial or an abstract place. Typical examples are
	/// street addresses, e-mail addresses, telephone numbers, IP-addresses, stockplaces in
	/// warehouses, URLs etc.
	/// </summary>
	/// <remarks>
	/// 	<para>An abstract address may be contained within another abstract address by
	///     pointing to it in the <see cref="PartOf">PartOf Property</see>. For example, the
	///     address "14b Kensington Court Gardens, Kensington Court Place, London W8 5QE,
	///     United Kingdom" is contained in "Kensington Court Gardens, Kensington Court Place,
	///     London W8 5QE, United Kingdom", which in its turn is contained in "Kensington Court
	///     Place, London W8 5QE, United Kingdom", which is contained in "London W8 5QE, United
	///     Kingdom", which is contained in "London, United Kingdom", which is contained in
	///     "United Kingdom". To extract a text identifying the address, the properties
	///     FullIdentifier (TODO) and FullIdentifierMultiline (TODO) are used. In the case of
	///     the leaf address above, online the text "14b" will be stored whitin that address
	///     object. The rest of the identifier will be extracted from the containing addresses
	///     recursively. The formatting of the address will ofcourse depend on the Kind of
	///     address (i.e. street address, email, URL, phoneno etc.).</para>
	/// </remarks>
	public class Address : Relation
	{
        /*TODO
         * protected override void OnNew()
        {
             _FullInternalAddressID = ObjectIDString;
        }
        */

        public virtual bool IsStatic
        {
            get { return true; }
        }

        public Address StaticParent
        {
            get
            {
                Address parent = this;
                while (parent != null)
                {
                    if (parent.IsStatic) { return parent; }
                    parent = parent.PartOf;
                }
                return null;
            }
        }
		/// <summary>
        /// Each address node can be associated with a level. Normally this is evident from the Kind.
        /// An instance of PostCode (for example "London W8 5QE") would be associated with the PostCode level.
        /// </summary>
        public AddressLevel Level;

        /// <summary>
		/// The identifier that uniquely identifies this address within the parent
		/// address.
		/// </summary>
		/// <remarks>
		/// The string identifiying this specific part of a complete address. E.g. if this is
		/// an address pointing out somebodys home address, this property would contain only the
		/// street number and it would have the <see cref="PartOf">PartOf Property</see> pointing
        /// to the street. The Street Address object in its turn would have the name of the
		/// street as its <see cref="AddressID">Value Property</see> and its <see cref="PartOf">PartOf
        /// Property</see> would point to the Postcode or the City Address object and
		/// so forth.
		/// </remarks>
        /// 
        [SynonymousTo("Name")]
		public String AddressID;

		/// <summary>The parent address (if any).</summary>
		/// <remarks>
		/// Each address may have a parent address. E.g. if this is a street number, this
		/// property will contain the street.
		/// </remarks>
        private Address _PartOf;
        [SynonymousTo("_PartOf")]
        public readonly Address PartOf;

        public virtual void SetPartOf(Address partOf)
        {
            if (partOf.IsIn(this))
            {
                if (partOf == PartOf)
                {
                    throw new ApplicationException(
                        string.Format("Can not set {0} as part of itself",
                        AddressID));
                }
                else
                {
                    throw new ApplicationException(
                        string.Format("Can not set {0} as part of {1} because {1} is already a part or subpart of {0}",
                        partOf.AddressID, AddressID));
                }
            }
            string parentAddress = partOf == null ? "" : partOf.FullInternalAddressID;
            string currentAddressID = _FullInternalAddressID;
            string potentiallyNewAddressID = "";//(partOf == null) ? ObjectID.ToString() : ObjectID.ToString();
           // ObjectIDString : String.Format("{0}_{1}", parentAddress, ObjectIDString);

            if (!potentiallyNewAddressID.Equals(currentAddressID))
            {
                _PartOf = partOf;
                UpdateFullInternalAddressID(parentAddress);
            }
        }

        private void UpdateFullInternalAddressID(string parentID)
        {
            string newID = (parentID == null) ? "" : "";//ObjectID.ToString() : ObjectID.ToString();
            //ObjectIDString : String.Format("{0}_{1}", parentID, ObjectIDString);
            _FullInternalAddressID = newID;
            /*TODO foreach (Address child in GetChildAddresses<Address>())
            {
                child.UpdateFullInternalAddressID(newID);
            }*/
        }

        public T ParentOfType<T>() where T : Address
        {
            Address parent = this;
            while (parent != null)
            {
                Type type = typeof(T).GetType();
                if (parent.GetType() == type)
                {
                    return parent as T;
                }
                parent = parent.PartOf;
            }
            return null;
        }

        /// <summary>
        /// A string containing the ObjectIDs of all parents(PartOf) and its own.
        /// This string is used to quickly find all addresses included in this address
        /// </summary>
        private string _FullInternalAddressID;
        [SynonymousTo("_FullInternalAddressID")]
        public readonly string FullInternalAddressID;


        /*TODO
        public virtual IEnumerable<Address> Traverse()
        {
            String query = String.Format(
                "SELECT address FROM {0} address " +
                "WHERE address.FullInternalAddressID STARTS WITH(variable(String, internalAddress))",
                Kind.GetInstance<Address.Kind>().FullInstanceClassName);
            SqlEnumerator<Address> sqlEnumerator = Sql.GetEnumerator<Address>(query);
            sqlEnumerator.SetVariable("internalAddress", FullInternalAddressID);

            // By using yield return we make sure that the enumerator is disposed
            foreach (var v in sqlEnumerator)
            {
                yield return v;
            }
        }
        public virtual IEnumerable<Address> TraverseAddressKind(Address.Kind addressKind)
        {
            String query = String.Format(
                "SELECT address FROM {0} address " +
                "WHERE address.FullInternalAddressID STARTS WITH(variable(String, internalAddress))",
                addressKind.FullInstanceClassName);
            SqlEnumerator<Address> sqlEnumerator = Sql.GetEnumerator<Address>(query);
            sqlEnumerator.SetVariable("internalAddress", FullInternalAddressID);

            // By using yield return we make sure that the enumerator is disposed
            foreach (var v in sqlEnumerator)
            {
                yield return v;
            }
        }
        */

        /// <summary>The child addresses of this address.</summary>
		/// <remarks>
		/// Each address can be a part of a address hierarchy. The <see cref="PartOf">PartOf
		/// Property</see> will return the parent address and this property will return the
		/// children. E.g. if this is a street, this property will contain all the street
		/// numbers.
		/// </remarks>
        /// 

        /*TODO
        public IEnumerable<Address> ChildAddresses
        {
            get { return GetChildAddresses<Address>(); }
        }
        public IEnumerable<T> GetChildAddresses<T>() where T : Address
        {
            return IndexedQueryHelper.GetRelatesTo<T>(this, "PartOf");
        }

        public IEnumerable<T> GetChildAddresses<T>(Address.Kind addressKind) where T : Address
        {
            return IndexedQueryHelper.GetRelatesTo<T>(addressKind, this, "PartOf");
        }
        */
		/// <summary>
		/// Each address may have play a role to something or somebody. This is the base
        /// class for such roles. Examples of AddressRoles are HomeAddress, FaxNo and
        /// /// PrivateEMail.
		/// </summary>
		/// <remarks>
		/// Each address may have a relation to something or somebody. For example, an
		/// address may the the home address of somebody. The class (kind) HomeAddress would then
		/// be derived from this class. The <see cref="SomebodiesRelation.WhoIs">WhatIs Property
		/// (Ring1.SomebodysRole)</see> would be set to this address and the <see cref="SomebodiesRelation.ToWhom">ToWhat
		/// (Concepts.Ring1.SomebodysRole)</see> would be set to this address and the (see cref="SomebodysRole.ToWhom")ToWhat
		/// Property (Concepts.Ring1.SomebodysRole)(/see) would be set to the somebody.
		/// </remarks>

        /*TODO
        public IEnumerable<T> Roles<T>(AddressRelation.Kind relationKind, bool recursive) where T : AddressRelation
        {
            if (!recursive)
            {
                return Roles<T>(relationKind);
            }
            return RolesRecursive<T>(relationKind);
        }
        public IEnumerable<T> Roles<T>(bool recursive) where T : AddressRelation
        {
            if (!recursive)
            {
                return Roles<T>();
            }
            return RolesRecursive<T>();
        }
        
        private IEnumerable<T> RolesRecursive<T>() where T : AddressRelation
        {
                foreach (Address a in Traverse())
                {
                    foreach (T relation in a.Roles<T>())
                    {
                        yield return relation;
                    }
                }
        }

        private IEnumerable<T> RolesRecursive<T>(AddressRelation.Kind relationKind) where T : AddressRelation
        {
                foreach (Address a in Traverse())
                {
                    foreach (T relation in a.Roles<T>(relationKind))
                    {
                        yield return relation;
                    }
                }
        }

        */


		/// <summary>
		/// Tells if this address is contained in another address, directly or indirectly,
		/// e.g. true is returned if the supplied parameter is a parent or a grandparent of this
		/// address.
		/// </summary>
		/// <remarks>
		/// Recursively checks the <see cref="PartOf">PartOf Property</see> property to see
        /// if this Address is contained within the supplied Address.
		/// </remarks>
		/// <example>
		/// 	<code lang="CS" title="Check if Oslo is situated in Norway" description="Check if Oslo is situated in Norway.">
		/// public void CheckIfOlsoIsInNorway( City oslo, Country norway )
        /// {
		///     if ( oslo.IsIn( norway ) )
		///     {
		///         Console.WriteLine( "I just knew it!" );
		///     }
        /// }
		///     </code>
		/// </example>
        public bool IsIn(Address what)
        {
            if (what != null)
            {
                return FullInternalAddressID.StartsWith(what.FullInternalAddressID);
            }
            return false;
        }


        /// <summary>
        /// Accesses the address as a text string with multiple lines of text (if applicable).
        /// </summary>
        /// <remarks>
        /// Subclasses of Address needs to override this method to implement functionality to read and write
        /// text strings containing a address information, potentially spanning several lines (separated with
        /// CR or CR + LF).
        /// </remarks>
        public virtual string MultiLineAddress
        {
            set
            {
                throw new Exception("The " + this.GetType().Name + " does not implement the setting of a MultiLineAddress");
                // Parse the string and set the individual items (door, street, etc).
            }
            get
            {
                // Make a string with <cr><lf> that represents the address hierarchy starting with this level.
                // I.e. for an english address create a string
                // <door> <House>
                // <Street>
                // <City> <Postcode>
                // <Country>
                //
                // or for a Swedish address
                // <Street> <Door>
                // <CareOf>
                // <PostCode> <City>
                // <Country>
                throw new Exception("The " + this.GetType().Name + " does not implement the get property accessor for a MultiLineAddress");
            }
        }
    }

}
