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
        public readonly CompanyCategory MemberOfCategory;
        public void SetMemberOfCategory(CompanyCategory memberOfCategory)
        {
            SetToWhat(memberOfCategory);
        }

    }
}
