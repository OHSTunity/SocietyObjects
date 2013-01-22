/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/PersonsAndOrganisations/Person.cs#2 $
      $DateTime: 2010/02/18 17:12:49 $
      $Change: 29486 $
      $Author: careri $
      =========================================================
*/
using System;
using System.Text;
using Concepts.Ring1;
using Starcounter;
using System.Collections;
using System.Collections.Generic;
using Attribute = Concepts.Ring1.Attribute;

namespace Concepts.Ring1
{
    /// <summary>
    /// A Person is a Somebody that represents a human being.
    /// That is the Somebody.Being field is not allowed to be null.
    /// </summary>
    /// <ontology>
    /// <equal>wordnet:00006049</equal>
    /// </ontology>
    public class Person : LegalEntity
    {
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        /// <seealso cref="Concepts.Ring1.Something.Kind"/>
        /*public new class Kind : Concepts.Ring1.LegalEntity.Kind 
        {
            public Person GetBySocialSecurityNumber(string socialSecurityNumber)
            {
                Person p = null;

                using (var persons = GetByID<Person>(socialSecurityNumber).GetEnumerator())
                {
                    if (persons.MoveNext())
                    {
                        p = persons.Current;
                    }

                    if (persons.MoveNext())
                    {
                        throw new ApplicationException("More than one person exists with the same SocialSecurityNumber!");
                    } 
                }

                return p;
            }
        }
         */

        /// <summary>
        /// Social security number.
        /// </summary>
        [SynonymousTo("ID")]
        public String SocialSecurityNumber;

        /// <summary>
        /// Title of a person
        /// </summary>
        public string Title;

        /// <summary>
        /// The persons first name.
        /// </summary>
        public string FirstName;

        /// <summary>
        /// The persons middle name
        /// </summary>
        public string MiddleName;

        /// <summary>
        /// The persons surname
        /// </summary>
        public string Surname;

        /// <summary>
        /// Fullname of a person is FirstName and Surname.
        /// </summary>
        
        public override string FullName
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                bool added = false;

                if (!String.IsNullOrEmpty(FirstName))
                {
                    builder.Append(FirstName);
                    added = true;
                }
                if (!String.IsNullOrEmpty(MiddleName))
                {
                    if (added)
                    {
                        builder.Append(' ');
                    }
                    builder.Append(MiddleName);
                    added = true;
                }
                if (!String.IsNullOrEmpty(Surname))
                {
                    if (added)
                    {
                        builder.Append(' ');
                    }
                    builder.Append(Surname);
                }
                return builder.ToString();
            }
        }

    }
}