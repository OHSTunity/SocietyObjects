using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;


namespace Concepts.Ring8.Tunity
{
    public class AccessRightGroup : Something
    {

        public static AccessRightGroup Get(SystemUser user)
        {
            return Db.SQL<AccessRightGroup>("SELECT a FROM AccessRightGroup a JOIN AccessRightGroupMember b ON b.ToWhat=a WHERE b.WhatIs=?", user).First;
        }
        /// <summary>
        /// The rights connected to this group
        /// </summary>
        public IEnumerable<StoredRight> Rights
        {
            get
            {
                return Db.SQL<StoredRight>("SELECT a FROM StoredRight a WHERE a.Owner=?", this);
            }
        }


        /// <summary>
        ///  Deletes all rights belonging to this group
        ///  and (means that it will return default values for all rights)
        /// </summary>
        public void Reset()
        {
            foreach (StoredRight sr in Rights)
            {
                sr.Delete();
            }
        }

        /// <summary>
        /// Returns the result of the right,
        /// Returns default value if no stored value exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean GetRight(AccessRight right)
        {
            String name = Enum.GetName(typeof(AccessRight), right);
            foreach (StoredRight sr in Rights)
            {
                if (sr.Name == name)
                {
                    return sr.Value;
                }
            }
            return DefaultValueEnum.GetDefaultValue<Boolean>(right);
        }

        /// <summary>
        /// Sets the value of a AccessRight
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetRight(AccessRight right, Boolean value)
        {
            String name = Enum.GetName(typeof(AccessRight), right);
            foreach (StoredRight sr in Rights)
            {
                if (name == sr.Name)
                {
                    sr.Value = value;
                    return;
                }
            }
            StoredRight newAr = new StoredRight();
            newAr.Name = name;
            newAr.Value = value;
            newAr.Owner = this;
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
        public AccessRightGroupMember AddMember(SystemUser user)
        {
            return null;// Kind.GetInstance<AccessRightGroupMember.Kind>().Relate<AccessRightGroupMember>(user, this);
        }

        /// <summary>
        /// The Indirect members of this group. E.g. the are members using the SystemUserGroupMember-relation.
        /// Configuration bound to this group doesnt affect thiese members.
        /// </summary>
        public IEnumerable<T> MembersRelations<T>() where T : AccessRightGroupMember
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

                foreach (AccessRightGroupMember member in MembersRelations<AccessRightGroupMember>())
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
            foreach (AccessRightGroupMember member in MembersRelations<AccessRightGroupMember>())
            {
                if (member.SystemUser.Equals(user))
                {
                    // Delete this member relation
                    member.Delete();
                }
            }
        }


        /// <summary>
        /// Remove the versions connected to this document.
        /// </summary>        
        protected override void OnDelete()
        {
            foreach (StoredRight sr in Rights)
            {
                sr.Delete();
            }
            foreach (AccessRightGroupMember member in MembersRelations<AccessRightGroupMember>())
            {
                member.Delete();
            }
            base.OnDelete();
        }
    }
}

