using Starcounter;
using System.Collections.Generic;
using System;
using Concepts.Ring1;
using Concepts.Ring1.SystemX;


namespace Concepts.Ring3
{
    /// <summary>
    /// The role as user to a system domain.
    /// </summary>
    public class SystemUser : Role, IConfigurationParameterOwner
    {
       // private static readonly SessionStateStoreSlot UserGroupSlot;
       // private static readonly SessionStateStoreSlot ComputerSystemSlot;

        static SystemUser()
        {
         //   UserGroupSlot = StateManager.AllocateSessionStateSlot();
         //   ComputerSystemSlot = StateManager.AllocateSessionStateSlot();
        }


        public SystemUser()
        {
        }

        public SystemUser(Somebody somebody)
        {
            WhoIs = somebody;
        }

		/// <summary>
        /// Same as WhatIs (synonym).
        /// </summary>
        [SynonymousTo("WhatIs")]
        public Somebody WhoIs;
        
        /*TODO:
        /// <summary>
        /// The computer system where the user has logged in.
        /// This shall be set during login.
        /// </summary>
        public ComputerSystem ConnectedTo
        {
            get { return StateManager.GetSessionState(ComputerSystemSlot) as ComputerSystem; }
            set { StateManager.SetSessionState(ComputerSystemSlot, value); }
        }

        /// <summary>
        /// The group that this user belongs to when fetching configuration.
        /// The group is set upon login.
        /// </summary>
        public SystemUserGroup Group
        {
            get { return StateManager.GetSessionState(UserGroupSlot) as SystemUserGroup; }
            set { StateManager.SetSessionState(UserGroupSlot, value); }
        }
        */
        private Language _language;

        /// <summary>
        /// The language this user uses.
        /// Setting the language will update the culture of the ScUser
        /// </summary>
        public Language Language
        {
            get { return _language; }
            set 
            { 
                _language = value;
            }
        }


        protected IEnumerable<T> MemberRelations<T>() where T : SystemUserGroupMember
        {
            return Roles<T>();
        }

        /// <summary>
        /// All system user groups that this user belongs to
        /// </summary>
        public IEnumerable<SystemUserGroup> Groups
        {
            get
            {
                List<SystemUserGroup> groups = new List<SystemUserGroup>();

                foreach (SystemUserGroupMember memberRelation in MemberRelations<SystemUserGroupMember>())
                {
                    groups.Add(memberRelation.SystemUserGroup);
                }

                return groups;
            }
        }

        private string _password;
        /// <summary>
        /// The user password.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
            }
        }

        /// <summary>
        /// The user name. Also updates the starcounter user.
        /// </summary>
        public string Username
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }

        }

        /// <summary>
        /// A signature (from Latin signare, "sign") is a handwritten (and sometimes stylized) depiction 
        /// of someone's name, nickname or even a simple "X" that a person writes on documents as a proof 
        /// of identity and intent. The writer of a signature is a signatory. Like a handwritten signature, 
        /// a signature work describes the work as readily identifying its creator.
        /// </summary>
        public string Signature;

        /// <summary>
        /// Indicates if this is the default system user of WhoIs
        /// </summary>
        public Boolean IsDefault;


        protected override void OnNew()
        {
            IsDefault = false;
        }

        /// <summary>
        /// Clones a system user role for a person and leavs th
        /// computer ToWhat property uninitialized.
        /// </summary>
        /// <returns>Cloned System user</returns>
        public SystemUser Clone()
        {
            SystemUser newSystemUser = new SystemUser();
            newSystemUser.Password = this.Password;
            newSystemUser.Username = this.Username;
            newSystemUser.WhoIs = this.WhoIs;
//            newSystemUser.Configuration = this.Configuration;
            return newSystemUser;
        }

      
        protected override void OnDelete()
        {
            //Delete all roles to this user
            foreach (var role in Roles<Role>())
            {
                role.Delete();
            }

        }

        #region IConfigurationParameterOwner Members

        public IConfigurationParameterOwner GetConfigurationParent()
        {
            return null;//todo:Group;
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
            return null; //TODO: IndexedQueryHelper.GetRelatesTo<T>(this, "BelongsTo");
        }

        public override string ToSelectorString()
        {
            Somebody s = WhoIs;
            if (s != null)
            {
                return string.Format("{0} - {1}", Username, s.FullName);
            }
            return base.ToSelectorString();
        }
        #endregion
    }
}
