using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// Role connecting a member (Somebody) to a Group.
    /// </summary>
    public class GroupMember : Relation
    {
        /// <summary>
        /// Group.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Group Group;
        public void SetGroup(Group group)
        {
            SetToWhat(group);
        }
        /// <summary>
        /// Group member.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Somebody Member;
        public void SetMember(Somebody member)
        {
            SetWhatIs(member);
        }
    }
}
