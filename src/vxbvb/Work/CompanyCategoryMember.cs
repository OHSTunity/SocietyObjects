using System;
using Concepts.Ring1;
using Starcounter;

namespace Concepts.Ring2
{
    /// <summary>
    /// Definition of what categories a company has.
    /// </summary>
    public class CompanyCategoryMember : Relation
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
        public readonly Company Member;
        public void SetMember(Company member)
        {
            SetWhatIs(member);
        }


        /// <summary>
        /// The category that the company is member of.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly CompanyCategory.Kind MemberOfCategory;
        public void SetMemberOfCategory(CompanyCategory.Kind memberOfCategory)
        {
            SetToWhat(memberOfCategory);
        }

    }
}
