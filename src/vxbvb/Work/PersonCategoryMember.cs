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
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        public new class Kind : Relation.Kind
        {
        }

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
        public readonly PersonCategory.Kind MemberOfCategory;
        public void SetMemberOfCategory(PersonCategory.Kind memberOfCategory)
        {
            SetToWhat(memberOfCategory);
        }

    }
}
