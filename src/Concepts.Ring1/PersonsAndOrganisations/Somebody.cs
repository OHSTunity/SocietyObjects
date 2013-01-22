/*
 * Society Objects 2.0.
 * Status: Rename RelatedSomebodies
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Starcounter;



namespace Concepts.Ring1
{
    /// <summary>
    /// 	<font size="1">Somebody is a person, company, organisation, department, group, team
    ///     or pet or other social entities that has a name and that can participate in
    ///     activities with other somebodies.</font>
    /// 	<para><font size="1">A Somebody is often defined by (see
    ///     <see cref="Something.DefinedBy">DefinedBy Property (Concepts.Ring1.Something)</see>) a
    ///     government controlled organisation. This is true for Persons and Companies.
    ///     However, a somebody may be defined by any other somebody. For instance, a pet with
    ///     a specific name is normally a somebody defined by the pets owner.</font></para>
    /// </summary>
    /// <example>
    ///     Although it is legal to use the Somebody class directly for unspecified somebodies
    ///     such as GeneralSociety or Everybody , you normally use the derived classes Person
    ///     or Organisation (or its derived Company). A Somebody most often has one or more
    ///     roles ( SomebodysRole Class ) associated with them. 
    ///     <code lang="CS" title="Linking Somebodys using SomebodysRole" description="The following example adds three &lt;c&gt;Somebody&lt;/c&gt;s and links them together using roles (see &lt;see cref=SomebodysRole&gt;SomebodysRole Class&lt;/see&gt;).">
    /// Somebody myFather;
    /// Somebody myWorkPlace;
    ///  
    /// me = new Person();
    /// myFather = new Person();
    /// myWorkPlace = new Company();
    ///  
    /// me.FirstName = "Joachim";
    /// me.Surname = "Wester";
    ///  
    /// myFather.FirstName = "Christer";
    /// myFather.Surname = "Wester";
    ///  
    /// myWorkPlace.Name = "Society Objects Ltd";
    ///  
    /// myRoleAsAnEmployee = SomebodysRole.Kind[Employee].Instantiate();
    /// myRoleAsAnEmployee.WhatIs = me;             // Who is employed.
    /// myRoleAsAnEmployee.ToWhat = myWorkPlace;    // To whom am I employed.
    /// myRoleAsAnEmployee.ID = "1234";             // My employee number.
    ///  
    /// myRoleAsASon = SomebodysRole.Kind[Son].Instantiate();
    /// myRoleAsASon.WhatIs = me;           // Who is the son.
    /// myRoleAsASon.ToWhat = myFather;     // To whom am I the son.
    ///     </code>
    /// 	<code lang="CS" title="Creating new kinds of Somebodies. Creating a cricket sport team." description="As always in SocietyObjects, the diffrent kinds of somebody can be added dynamically as derived objects from Somebody.Kind. So if you need to handle a sports team in an odd sport that is not already defined in any of the rings, you can add that somebodys kind as in the example below:" inline="False">
    /// Somebody.Kind cricketTeam = new Somebody.Kind();
    /// SomebodysRole.Kind teamPlayer = new SomebodysRole.Kind();
    /// cricketTeam.ObjectName = "CricketTeam"; // Make it globally usable
    ///  
    /// Somebody myTeam = cricketTeam.New();    // Create a new cricket team
    /// myTeam.Name = "Nordic Cricked Club of Ireland";
    /// Person me = new Person();               // A Person is a Somebody
    /// me.Name = "Joachim Wester";
    ///  
    /// SomebodysRole meAsAPlayer = teamPlayer.New();
    /// teamPlayer.WhatIs = me;                 // To who the player is
    /// teamPlayer.ToWhat = myTeam;             // To whom am I a player
    ///     </code>
    /// </example>
    /// <remarks>
    /// 	<img src="http://www.innowait.se/societyobjects/res/somebody.jpg" align="right"/>Individual persons, companies, organisations, departments, groups,
    ///     parties, teams and pets are all Somebodies. They can all be organised as playing a
    ///     social role with other sombodies. Examples of these roles are Mother, Father,
    ///     Employee, Owner (pet owner), Consultant and Customer. They can
    ///     participate as members in different activities such as meetings, conversations,
    ///     training and purchasing. 
    ///     <para>A Somebody may or may not be linked to a human or an animal using the
    ///     <see cref="Role.WhatIs">Being Property</see>. Information such as the somebodys name (as
    ///     defined by the <see cref="Something.DefinedBy">DefinedBy Property
    ///     (Concepts.Ring1.Something)</see>) and its relationship with others (as defined by the
    ///     <see cref="Roles">Roles Property</see>) are all part of the Somebody. However,
    ///     information such as date of birth, weight and gender are all properties of the
    ///     being.</para>
    /// 	<para>Also important to note is that information such as someones customer number
    ///     or supplier ID are properties of somebodys role and not the somebody. If you think
    ///     of it, you yourself has different customer numbers at different companies from
    ///     where you buy things, so it is attributed to your different relationsships with
    ///     other somebodies (see <see cref="Roles">Roles Property</see>),</para>
    /// 	<para>Study the examples below to understand how to use Somebody and
    ///     SomebodysRole.</para>
    /// </remarks>
    /// <ontology>
    /// <equal>sumo:Agent</equal>
    /// </ontology>
    public class Somebody : Role
    {
        /// <summary>
        /// The Somebody class has one or more associated Kind objects. These objects are instances of this class.
        /// </summary>
        /// <seealso cref="Concepts.Ring1.Something.Kind"/>
        /*public new class Kind : Role.Kind 
        {
            /// <summary>
            /// Finds all somebodies matching the given ID.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="id"></param>
            /// <returns></returns>
            public IEnumerable<T> GetByID<T>(string id) where T : Somebody
            {
                string query = string.Format(
                    "SELECT sb FROM {0} sb WHERE sb.ID=VAR(String, id)",
                    FullInstanceClassName);
                SqlEnumerator<T> e = Sql.GetEnumerator<T>(query);
                e.SetVariable("id", id);

                // By using yield return we make sure that the enumerator is disposed
                foreach (var t in e)
                {
                    yield return t;
                }
            }

            /// <summary>
            /// Find the first somebody matching the given ID.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="id"></param>
            /// <returns></returns>
            public T GetObjectByID<T>(string id) where T : Somebody
            {
                return GetByID<T>(id).FirstOrDefault();
            }

            /// <summary>
            /// Ensures a Somebody with only the id as condition.
            /// Generic method that doesnt suite all objects when a more complex condition than name is needed.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="name"></param>
            /// <returns></returns>
            public T EnsureByID<T>(String id) where T : Somebody
            {
                T somebody = null;

                if (!string.IsNullOrEmpty(id))
                {
                    somebody = GetObjectByID<T>(id);

                    if (somebody == null)
                    {
                        somebody = New<T>();
                        somebody.ID = id;
                    }
                }
                else
                {
                    throw new ApplicationException("Cant ensure with empty id!");
                }

                return somebody;
            }
        }
        */
        #region static Somebody GeneralSociety;
        /// <summary>
        /// Represents the general society. This is the somebody that defines most somethings
        /// (see <see cref="Something.DefinedBy">DefinedBy Property
        /// (Concepts.Ring1.Something)</see>).
        /// </summary>
        /// <value>The global object representing Everybody</value>
        /// <remarks>
        /// 	<para>Many every day objects does not have any specific definer. Concepts such as a
        ///     person, a product and money are simply defined by our society. This global object
        ///     is used to represent this common society as a somebody.</para>
        /// 	<para>
        /// 		<para>The ObjectNo TODO (equals ObjectID TODO) or the ObjectName
        ///         "GeneralSociety" can be used to identify this object.</para>
        /// 		<para>
        /// 			<img src="file://///www.innowait.se/societyobjects/res/generalsociety.jpg"/></para>
        /// 		<para>The purpose of SocietyObjects is to simulate the real world. The most
        ///         important and most common objects are our everyday concepts defined in our
        ///         spoken and written language. These objects does not have a specific authority,
        ///         person or organisation that acts as definer. Other objects such as a specific
        ///         company or a specific address may be defined by an organisation related to a
        ///         government. An individual activity may be defined by an individual person. A
        ///         product may be defined by a company. Most Kind objects (see
        ///         <see cref="Something.Kind">Kind Class</see>) in Concepts.Ring1, Concepts.Ring1, Concepts.Ring2 and Concepts.Ring3
        ///         are defined by GeneralSociety.</para>
        /// 	</para>
        /// </remarks>
        public static Somebody GeneralSociety
        {
            get
            {
                // TODO
                return null;
            }
        }
        #endregion

        /// <summary>
        /// An identifier as used by the DefinedBy somebody. E.g. a specific Company may be defined by a
        /// specific government and may have an organisation number (the ID property).
        /// </summary>
        /// <remarks>
        /// Certain authorities may issue
        /// an ID for a specific person (i.e. a personal number). If a single <c>Human</c> is defined by two authorities,
        /// one should be considered primary and the other one a role or he should have two Person objects associated with
        /// the same Human object.
        /// </remarks>
        public String ID;

        /// <summary>
        /// The name of a Somebody. I.e. persons will compile FirstName, MiddleName and Surname as their full name,
        /// whereas a Company will simply use FullName as a stand alone attribute.
        /// </summary>
        
        public virtual String FullName
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// A list of the roles we play as participants of events.
        /// </summary>
        public IEnumerable<T> Events<T>() where T : Participant
        {
            return Roles<T>();
        }


        /// <summary>
        /// The different kinds of abstract addresses related to us. I.e. home addresses, telephone numbers, email addresses,
        /// delivery addresses, etc.
        /// TODO! Example.
        /// </summary>
        public IEnumerable<T> Addresses<T>() where T : AddressRelation
        {
            return ImplicitRoles<T>();
        }

        /// <summary>
        /// Returns the first address of the given kind.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toWhom"></param>
        /// <returns></returns>
        public virtual T GetAddressRelation<T>() where T:AddressRelation
        {
            T addressRelation = null;
           /*TODO AddressRelation ar = ark.New<AddressRelation>();
            string query = string.Format(
                "SELECT ar FROM {0} ar WHERE ar.InstantiatedFrom.EqualsOrIsDerivedFrom(variable({1}, ark))=TRUE AND ar.Addressee=variable({2}, addressee)",
                ark.FullInstanceClassName,
                ark.FullClassName,
                this.FullClassName);

            using (SqlEnumerator<T> enumerator = Sql.GetEnumerator<T>(query))
            {
                enumerator.SetVariable("ark", ark);
                enumerator.SetVariable("addressee", this);

                if (enumerator.MoveNext())
                {
                    addressRelation = enumerator.Current;
                } 
            }
            */
            return addressRelation;
        }

        public string ToReadableString()
        {
            return string.Concat(
                (!string.IsNullOrEmpty(FullName)) ? string.Concat(FullName, ", ") : string.Empty,
                FullClassName,
                ", [", ObjectIDString, "]"); 
        }

        /// <summary>
        /// Somebodies can communicate and here we set what language to use.
        /// <example>
        /// A company can have an internal preferred language to use when communicating.
        /// </example>
        /// </summary>
        public Language PreferredLanguage;

        /// <summary>
        /// URL to the image representing this somebody
        /// </summary>
        public String ImageURL;
		
        public override string ToSelectorString()
        {
            return FullName;
        }
    }
}
