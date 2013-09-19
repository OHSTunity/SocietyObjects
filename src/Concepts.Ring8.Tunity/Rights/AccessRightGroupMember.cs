using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;

namespace Concepts.Ring8.Tunity
{
    public class AccessRightGroupMember : Relation
    {
      
        /// <summary>
        /// The system user that is an indirect member of the group.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public SystemUser SystemUser;
       
        /// <summary>
        /// 
        /// </summary>
        [SynonymousTo("ToWhat")]
        public AccessRightGroup AccessRightGroup;
        
    }
}

