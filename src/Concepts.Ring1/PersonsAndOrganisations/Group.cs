/*
 * Mark:                        Society Objects Mark II
 * Concept approval:            Meeting #?
 * Implementation approval:     pending
 * Introduced by:               Henrik Tillman
 * 
 * Not approved. Several issues found.
 **/

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// Group of somebodies, that can have the same handling as a soembody.
    /// </summary>
    public class Group : Somebody
    {
        #region Kind
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        /// <seealso cref="Somebody.Kind"/>
        /*public new class Kind : Somebody.Kind 
        {


            /// <summary>
            /// Get all members (direct and indirect) of a group.
            /// </summary>
            /// <param name="group"></param>
            /// <param name="memberList"></param>
            public void GetMembersInGroup(Group group, List<Somebody> memberList)
            {
                foreach (GroupMember obj in group.GroupMembers<GroupMember>())
                {
                    if (obj.WhatIs is Group)
                    {
                        GetMembersInGroup(obj.Group, memberList);
                    }
                    else if (obj.WhatIs is Somebody)
                    {
                        memberList.Add(obj.Member);
                    }
                }
            }

            /// <summary>
            /// All group that a somebody is member of.
            /// </summary>
            /// <param name="somebody">Somebody of a group</param>
            /// <param name="groupList">List to populate</param>
            public void AllGroups(Somebody somebody, List<Somebody> groupList)
            {
                if (groupList == null)
                {
                    return;
                }
                //IEnumerable<GroupMember> list = AllDirectMembersOf(somebody);
                //foreach (GroupMember member in list)
                //{
                //    groupList.Add(member.Group);
                //    AllGroups(member.Group, groupList);
                //}
            }

            /// <summary>
            /// All direct member relations of a somebody to a group.
            /// </summary>
            /// <param name="somebody"></param>
            /// <returns></returns>
            public IEnumerable<GroupMember> AllDirectMembersOf(Somebody somebody)
            {
                return somebody.RelationsTo<GroupMember>(this);
            }

            /// <summary>
            /// Get all members of a group
            /// </summary>
            /// <param name="group"></param>
            /// <returns></returns>
            public IList<Somebody> Members(Group group)
            {
                List<Somebody> list = new List<Somebody>();
                GetMembersInGroup(group, list);
                return list;
            }

        }
         */
        #endregion

        /// <summary>
        /// Readonly property of the owner of this group.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Somebody GroupOwner;
        
        /// <summary>
        /// Setting the owner of this group.
        /// </summary>
        /// <param name="groupOwner"></param>
        public void SetGroupOwner(Somebody groupOwner)
        {
            SetWhatIs(groupOwner);
        }

        /// <summary>
        /// Definition of this group is a member of a larger group.
        /// </summary>
        public Group MemberOf;

        /// <summary>
        /// All somebodies that is a member of this group.
        /// </summary>
        public IEnumerable<T> GroupMembers<T>() where T : GroupMember
        {
            return ImplicitRoles<T>();
        }

        /// <summary>
        /// Level of this group, so that this group can be compared
        /// with other groups.
        /// </summary>
        public Level Level;

        /// <summary>
        /// Is a somebody member of the group.
        /// </summary>
        /// <param name="somebody">Group member?</param>
        /// <returns>Validated answer if somebody is member of this group</returns>
        public Boolean IsMember(Somebody somebody)
        {
            if (somebody is Everybody)
            {
                return true;
            }

            //Check if the somebody directly is a member of this group.
            GroupMember member = somebody.RelationTo<GroupMember>(this);
            if (member != null)
            {
                return true;
            }

            //Check if the somebody indirect is a member of this group.
            List<Somebody> list = new List<Somebody>();
            //AllGroups(somebody, list);
            return list.Contains(somebody);
        }


    }

}
