/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/DigitalContents/Document.cs#7 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3.SystemX;
using Concepts.Ring4;
using Starcounter;

namespace Concepts.Ring8.Tunity
{
    public class Reviewer : Relation
    {
        /// <summary>
        /// Group.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Proof Proof;
        public void SetProof(Proof proof)
        {
            SetToWhat(proof);
        }

        /// <summary>
        /// Group member.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Person WhoIs;
        public void SetWhoIs(Person whoIs)
        {
            SetWhatIs(whoIs);
        }

        public ProofRole Role;

        public ProofEmail EmailSetting;

        private String _email;

        private String _url;

        public String Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public String DisplayName
        {
            get
            {
                if (WhoIs != null)
                {
                    return WhoIs.FullName;
                }
                return _email;
            }
        }
        public String EmailAddress
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public String RoleAsString
        {
            get
            {
                return DescriptionValueEnum.GetDescriptionValue(Role);
            }
        }

        public Boolean ApproverStatus
        {
            get
            {
                return ((Role == ProofRole.Approver) || 
                    (Role == ProofRole.ReviewerAndApprover));
            }
            set
            {
                if (value)
                {
                    switch (Role)
                    {
                        case ProofRole.Reviewer:
                            Role = ProofRole.ReviewerAndApprover;
                            break;
                        case ProofRole.ReadOnly:
                            Role = ProofRole.Approver;
                            break;
                    }
                }
                else
                {
                    switch (Role)
                    {
                        case ProofRole.Approver:
                            Role = ProofRole.ReadOnly;
                            break;
                        case ProofRole.ReviewerAndApprover:
                            Role = ProofRole.Reviewer;
                            break;
                    }
                }
            }
        }

        public Boolean ReviewerStatus
        {
            get
            {
                return ((Role == ProofRole.Reviewer) ||
                    (Role == ProofRole.ReviewerAndApprover));
            }
            set
            {
                if (value)
                {
                    switch (Role)
                    {
                        case ProofRole.Approver:
                            Role = ProofRole.ReviewerAndApprover;
                            break;
                        case ProofRole.ReadOnly:
                            Role = ProofRole.Reviewer;
                            break;
                    }
                }
                else
                {
                    switch (Role)
                    {
                        case ProofRole.Reviewer:
                            Role = ProofRole.ReadOnly;
                            break;
                        case ProofRole.ReviewerAndApprover:
                            Role = ProofRole.Approver;
                            break;
                    }
                }
            }
        }

        public Boolean IsExternal
        {
            get
            {
                return WhoIs == null;
            }
        }

        public String FullName
        {
            get
            {
                if ((WhoIs is Person))
                {
                    return (WhoIs as Person).FullName;
                }
                else
                    return Name;
            }
        }
    }
 }