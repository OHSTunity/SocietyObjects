/*
	=========================================================
	$Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/SystemUserGroup.cs#22 $
	$DateTime: 2010/03/17 12:54:45 $
	$Change: 30639 $
	$Author: careri $
	=========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;


namespace Concepts.Ring3
{
    public class SystemUserGroup : Something, IConfigurationParameterOwner
    {
        // TODO, add the kind. Not possible at the moment since this will render existing dumps unusable.
        //public new class Kind : Something.Kind
        //{
        //}

        #region IConfigurationParameterOwner Members

        public IConfigurationParameterOwner GetConfigurationParent()
        {
            // Will never have a parent.
            return null;
        }

        public IEnumerable<ConfigurationParameter> GetOwnedParameters()
        {
            return GetConfigurationParameters<ConfigurationParameter>();
        }
        public IEnumerable<ConfigurationParameter> ConfigurationParameters
        {
            get { return GetConfigurationParameters<ConfigurationParameter>(); }
        }

        public IEnumerable<T> GetConfigurationParameters<T>() where T : ConfigurationParameter
        {
            return null;//TODO: IndexedQueryHelper.GetRelatesTo<T>(this, "_belongsTo");
        }

        #endregion

        public IEnumerable<ComputerSystem> EmployingSystems
        {
            get { return GetEmployingSystems<ComputerSystem>(); }
        }
        /// <summary>
        /// Returns all computer systems that uses this group.
        /// </summary>
        public IEnumerable<T> GetEmployingSystems<T>() where T : ComputerSystem
        {
            return null; //TODO: IndexedQueryHelper.GetRelatesTo<T>(this, "UserGroup");
        }

        /// <summary>
        /// Adds all the given members to this group.
        /// </summary>
        /// <param name="iEnumerable"></param>
        public void AddMembers(IEnumerable<SystemUser> members)
        {
 	        foreach (SystemUser systemUser in members)
            {
                AddMember(systemUser);
            }
        }

        /// <summary>
        /// Assures that the given system user is a member of this group.
        /// </summary>
        /// <param name="headsUser"></param>
        /// <returns></returns>
        public SystemUserGroupMember AddMember(SystemUser user)
        {
            return null;//TODO:Kind.GetInstance<SystemUserGroupMember.Kind>().Relate<SystemUserGroupMember>(user, this);
        }

        /// <summary>
        /// The Indirect members of this group. E.g. the are members using the SystemUserGroupMember-relation.
        /// Configuration bound to this group doesnt affect thiese members.
        /// </summary>
        public IEnumerable<T> MembersRelations<T>() where T : SystemUserGroupMember
        {
            return ImplicitRoles<T>();
        }

        /// <summary>
        /// The members of this group.
        /// </summary>
        public IEnumerable<SystemUser> Members
        {
            get
            {
                List<SystemUser> users = new List<SystemUser>();

                foreach (SystemUserGroupMember member in MembersRelations < SystemUserGroupMember>())
                {
                    SystemUser user = member.SystemUser;
                    
                    // Needed control for corrupted database.
                    if (user != null)
                    {
                        users.Add(user); 
                    }
                }

                return users;
            }
        }

        /// <summary>
        /// Will search through all members of this group.
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        public bool IsMember(SystemUser systemUser)
        {
            bool isMember = false;

            // Start by searching direct members
            foreach (SystemUser user in Members)
            {
                if (user.Equals(systemUser))
                {
                    isMember = true;
                    break;
                }
            }

            // TODO, search lower/upper?

            return isMember;
        }

        /// <summary>
        /// Removes the given user from this group.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveMember(SystemUser user)
        {
            // Remove the relation to the user.
            foreach (SystemUserGroupMember member in MembersRelations < SystemUserGroupMember>())
            {
                if (member.SystemUser.Equals(user))
                {
                    // Delete this member relation
                    member.Delete();
                }
            }
        }
    }
}
