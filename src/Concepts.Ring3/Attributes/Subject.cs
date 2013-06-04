using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring3
{
    /// <summary>
    /// The subject of e.g. a book.
    /// </summary>
    public class Subject : Something
    {
        public new class Kind : Something.Kind
        {
        }

        /// <summary>
        /// The subject memberships of this book
        /// </summary>
        public IEnumerable<T> Memberships<T>() where T : SubjectMember
        {
            return ImplicitRoles<T>();
        }

        /// <summary>
        /// The subjects of this book
        /// </summary>
        public IEnumerable<Something> Members
        {
            get { return from member in Memberships<SubjectMember>() select member.WhatIs; }
        }
    }
}
