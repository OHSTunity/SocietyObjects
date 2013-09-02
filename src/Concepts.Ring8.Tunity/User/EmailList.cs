/*
 * 
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Production/ProductionGroup.cs#2 $
      $DateTime: 2008/12/12 07:46:28 $
      $Change: 17466 $
      $Author: davros $
      =========================================================
*/

using System;
using Starcounter;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
        /// <summary>
        /// Group of productions
        /// </summary>
        public class EmailList : Role
        {
            

            /// <summary>
            /// The object addressed by the Production
            /// </summary>
            [SynonymousTo("WhatIs")]
            public readonly Something User;
            public void SetUser(Something Owner)
            {
                SetWhatIs(Owner);
            }


            /// <summary>
            /// All somebodies that is a member of this group.
            /// </summary>
            public IEnumerable<EmailListMember> Members
            {
                get
                {
                    return Db.SQL<EmailListMember>("SELECT a FROM EmailListMember a WHERE a.List=?", this);
                }
            }

            /// <summary>
            /// Adds a person or emailaddress to the emaillist
            /// if that person not already exists in the list
            /// </summary>
            /// <param name="something"></param>
            /// <returns></returns>
            public EmailListMember Add(Something something)
            {
                if (something == null)
                    return null;
                foreach(EmailListMember member in Members)
                {
                    if (member.Member == something)
                    {
                        return null;
                    }
                }
                EmailListMember pgm = new EmailListMember();
                pgm.SetList(this);
                pgm.SetMember(something);
                return pgm;
            }

            public EmailListMember Add(String address)
            {
                if (address == null)
                    return null;
                foreach (EmailListMember member in Members)
                {
                    if ((member.Member == null) && (member.EmailAddress == address))
                    {
                        return null;
                    }
                }
                EmailListMember pgm = new EmailListMember();
                pgm.SetList(this);
                pgm.EmailAddress = address;
                return pgm;
            }

            public void Remove(String address)
            {
                foreach (EmailListMember member in Members)
                {
                    if ((member.Member == null) && (member.EmailAddress == address))
                    {
                        member.Delete();
                    }
                }
            }

            public void Remove(Something something)
            {
                EmailListMember pgm = this.ImplicitRelationTo<EmailListMember>(something);
                if (pgm != null)
                {
                    pgm.Delete();
                }
            }
        }
    }

