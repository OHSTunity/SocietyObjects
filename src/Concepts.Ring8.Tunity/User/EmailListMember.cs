/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionGroupMember.cs#1 $
      $DateTime: 2008/12/09 13:00:04 $
      $Change: 17308 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Member of a EmailList
    /// Might be just a email address (then its stored in this object)
    /// or it might be a person (then it points to the person object)
    /// </summary>
    public class EmailListMember : Relation
    {
        
        /// <summary>
        /// Group.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly EmailList List;
        public void SetList(EmailList list)
        {
            SetToWhat(list);
        }
        /// <summary>
        /// Group member.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Something Member;
        public void SetMember(Something member)
        {
            SetWhatIs(member);
        }

        /// <summary>
        /// This is only valid if Member is null
        /// </summary>
        public String EmailAddress;

        public String NiceName
        {
            get 
            {
                if ((Member != null) && (Member is SystemUser))
                {
                    return (Member as SystemUser).WhoIs.FullName;
                }
                else
                    return EmailAddress;
            }
        }
    }
}


    

