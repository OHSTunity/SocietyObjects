using System;
using Concepts.Ring1;
using Starcounter;


namespace Concepts.Ring2
{
    /// <summary>
    /// Definition of what categories a company has.
    /// </summary>
    public class PersonCategoryMember : Relation
    {
        /// <summary>
        /// Company that is member of a category.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Person Member;
        public void SetMember(Person member)
        {
            SetWhatIs(member);
        }


        /// <summary>
        /// The category that the company is member of.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly PersonCategory MemberOfCategory;
        public void SetMemberOfCategory(PersonCategory memberOfCategory)
        {
            SetToWhat(memberOfCategory);
        }

    }
}
