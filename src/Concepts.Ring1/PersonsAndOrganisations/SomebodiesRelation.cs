using Starcounter;
using System;
namespace Concepts.Ring1
{
/*
    /// <remarks>
	///     If a person is an employee of a company, Employee is a derived class (kind) of
	///     SomebodysRole with the <see cref="SomebodiesRelation.WhoIs">WhoIs Propert /// (Ring1.SomebodysRole)</see>
	///     set to the person and the <see cref="SomebodiesRelation.ToWhom">ToWhom Property
	///     (Ring1.SomebodysRole)</see> set to the company. 
	///     <para>
	/// 		<img src="http://www.innowait.se/societyobjects/res/somebodyrole.jpg"/></para>
	/// 	<para>All Somebodys (persons, companies, organisations, etc.) may have one or
	///     several roles. One of the rules of SocietyObjects is that all objects in all
	///     databases in all systems should be able to coexist. So where does the supplier ID,
	///     the customer ID, the employee no etc. go? After all, a single person or a single
	///     organisation will have different ID's in the eyes of the different beholders. This
	///     is ofcourse not a problem, as the person is a single object while the role as a
	///     customer or a supplier might be one of a great many. The base class for such roles
	///     is the SomebodysRole which is a specialization of the <see cref="SomebodiesRelation">SomebodysRole
	///     Class</see> that only allows <see cref="Somebody">Somebody objects</see> for the
	///     <see cref="SomebodiesRelation.WhoIs">WhoIs</see> and <see cref="SomebodiesRelation.ToWhom">ToWhom</see>
	///     properties. This means that WhatIs should be interpreted "WhoIs" and ToWhat should
	///     be interpreted "ToWhom".</para>
	/// 	<para>If you for example take the Somebody object for the person "Jesus". This
	///     person would have a Son (inherits SomebodysRole) object. This object would have its
	///     WhatIs (=Who is) property set to "Jesus" and its ToWhat (=to whom) property set to
	///     the Person "Maria".</para>
	/// 	<para>
	/// 		<h4 class="">An example</h4>
	/// 		<para>In a simple sales system implemented on a traditional relational database
	///         there might be a table called Customer with the columns CustomerID, Name and
	///         Gender.</para>
	/// 		<para>In SocietyObjects, a Customer is a Person, a SomebodysRole and sometimes also a
	///         Human. The equivalent of these columns in SocietyObjects would be the attribute
	///         ID in the SomebodysRole derived class Customer (equals CustomerID), the Name
	///         attribute in Somebody and the Gender attribute in TODO.</para>
	/// 		<para>
	/// 			<table cols="3" bgcolor="#E0E0E0" border="1">
	/// 				<tbody>
	/// 					<tr>
	/// 						<td><strong><font size="1">Attribute</font></strong></td>
	/// 						<td><strong><font size="1">Class</font></strong></td>
	/// 						<td><strong><font size="1">Extends</font></strong></td>
	/// 					</tr>
	/// 					<tr>
	/// 						<td><font size="1">ID</font></td>
	/// 						<td><font size="1">Customer</font></td>
	/// 						<td><font size="1">SomebodysRole</font></td>
	/// 					</tr>
	/// 					<tr>
	/// 						<td><font size="1">Name</font></td>
	/// 						<td><font size="1">Person</font></td>
	/// 						<td><font size="1">Somebody</font></td>
	/// 					</tr>
	/// 					<tr>
	/// 						<td><font size="1">Gender</font></td>
	/// 						<td><font size="1">Human</font></td>
	/// 						<td></td>
	/// 					</tr>
	/// 				</tbody>
	/// 			</table>
	/// 		</para>
	/// 	</para>
	/// </remarks>
*/


    /// <summary>
	/// Something that somebody is to somebody else. Examples of roles are 
	/// Customer, Daughter, Employee. Extends Role in a way that it only allows for Somebody derived objects.
	/// </summary>
    /// <ontology>
    /// <equal>wordnet:SocialRole</equal>
    /// </ontology>
    public abstract class SomebodiesRelation : Relation
	{
   	
		/// <summary>
        /// Same as WhatIs (synonym).
        /// </summary>
        [SynonymousTo("WhatIs")]
        public Somebody WhoIs;
        
        /// <summary>
        /// Same as ToWhat (synonym).
        /// </summary>
		[SynonymousTo("ToWhat")]
		public Somebody ToWhom;
        
        /// <summary>
        /// Identification of the relation
        /// </summary>
        /// <example>
        /// A company in norway may want to set an identification on one of their customer 
        /// relations.
        /// </example>
        public String ID;

        /// <summary>
        /// A certain relation can have a preferred language.
        /// <example>
        /// A company in norway may want to set default language to one of their customer 
        /// relations to english if the other somebody doesn't understand norweigan.
        /// </example>
        /// </summary>
        public Language PreferredLanguage;
    }
}