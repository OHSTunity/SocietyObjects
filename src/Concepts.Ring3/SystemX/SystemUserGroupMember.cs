/*
	=========================================================
	$Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/SystemUserGroupMember.cs#4 $
	$DateTime: 2008/03/13 10:48:27 $
	$Change: 10427 $
	$Author: careri $
	=========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;
using Concepts.Ring1;

namespace Concepts.Ring3.SystemX
{
    public class SystemUserGroupMember : Relation
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
        public readonly SystemUserGroup SystemUserGroup;
    }
}
