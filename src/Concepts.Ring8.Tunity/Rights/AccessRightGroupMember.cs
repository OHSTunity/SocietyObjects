using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;

namespace Concepts.Ring8.Tunity
{
    public class AccessRightGroupMember : Relation
    {
      
        /// <summary>
        /// The system user that is an indirect member of the group.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly SystemUser SystemUser;
        public void SetSystemUser(SystemUser systemUser)
        {
            SetWhatIs(systemUser);
        }

        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly AccessRightGroup AccessRightGroup;
        public void SetRightsGroup(AccessRightGroup group)
        {
            SetToWhat(group);
        }

    }
}

