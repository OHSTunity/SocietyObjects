/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/SystemX/ListConfigurationParameter.cs#26 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/


using System;
using System.Linq;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring3.SystemX;
using Starcounter;


namespace Concepts.Ring3.SystemX
{
    /// <summary>
    /// Represents a ConfigurationParameter that consists of a list of available members.
    /// E.g. Countries.
    /// </summary>
    public class ListConfigurationParameter : ConfigurationParameter
    {
        public new class Kind : ConfigurationParameter.Kind
        {
            /// <summary>
            /// Returns a ListConfigurationParameter for the given identifier and owner.
            /// </summary>
            /// <param name="owner"></param>
            /// <param name="usedByType"></param>
            /// <returns></returns>
            public ListConfigurationParameter GetParameter(
                IConfigurationParameterOwner owner,
                Type usedByType)
            {
                return Get(ID, owner, usedByType) as ListConfigurationParameter;
            }


            protected ListConfigurationParameterMember.Kind _memberRelationKind;
            /// <summary>
            /// Lets inheriting classes change member relation kind.
            /// </summary>
            public ListConfigurationParameterMember.Kind MemberRelationKind
            {
                get { return _memberRelationKind; }
            }

            protected Something.Kind _memberKind;

            /// <summary>
            /// This is the kind that shall be instantiated on a new row (ListMember.WhatIs).
            /// </summary>
            public Something.Kind MemberKind
            {
                get { return _memberKind; }
            }
            
            
            /// <summary>
            /// Returns a new instance of the MemberKind, override this method for alternative instanciation.
            /// </summary>
            /// <returns></returns>
            public virtual Something InstantiateMember()
            {
                return MemberKind.New() as Something;
            }
        }

        
        /// <summary>
        /// All instances of ListConfigurationParameterMember
        /// where the WhatIs is an instance of Kind.MemberKind and the ToWhat is this.
        /// 
        /// This method can be overriden, to more complex ways of fetching the members.
        /// </summary>
        
        public virtual List<ListConfigurationParameterMember> ListMembers
        {
            get
            {
                List<ListConfigurationParameterMember> members = new List<ListConfigurationParameterMember>();
                
                foreach (ListConfigurationParameterMember member in ImplicitRoles<ListConfigurationParameterMember>())
                {
                    members.Add(member);
                }

                return members;
            }
        }

        /// <summary>
        /// Returns the default member of this list configuration.
        /// </summary>
        /// <returns></returns>
        public ListConfigurationParameterMember GetDefaultMember()
        {
            ListConfigurationParameterMember defaultMember = null;

            foreach (ListConfigurationParameterMember member in ListMembers)
            {
                if (member.IsDefaultValue)
                {
                    defaultMember = member;
                    break;
                }
            }
            return defaultMember;
        }

        /// <summary>
        /// Get value from default member.
        /// </summary>
        /// <returns>Value of default member</returns>
        public Something GetDefaultMemberValue()
        {
            ListConfigurationParameterMember defaultMember = GetDefaultMember();

            if (defaultMember != null)
            {
                return defaultMember.WhatIs;
            }
            else
            {
                return null; //TODO: Exception?
            }
        }

        public override object Value
        {
            get
            {
                return ListMembers;
            }
            set
            {
                base.Value = ListMembers;
            }
        }

        /// <summary>
        /// Creates a new member using the Kind.MemberKind to decide the something to instantiate and connect to this list.
        /// </summary>
        /// <returns></returns>
        public ListConfigurationParameterMember NewMember()
        {
            ListConfigurationParameter.Kind paramKind = (InstantiatedFrom as ListConfigurationParameter.Kind);
            ListConfigurationParameterMember.Kind memberRelationKind = paramKind.MemberRelationKind;
            memberRelationKind = (memberRelationKind == null) ?
                Kind.GetInstance<ListConfigurationParameterMember.Kind>() :
                memberRelationKind;

            Something something = (InstantiatedFrom as ListConfigurationParameter.Kind).InstantiateMember();
            return memberRelationKind.Relate<ListConfigurationParameterMember>(something, this, false);
        }
        public ListConfigurationParameterMember NewEmptyMember()
        {
            ListConfigurationParameter.Kind paramKind = (InstantiatedFrom as ListConfigurationParameter.Kind);
            ListConfigurationParameterMember.Kind memberRelationKind = paramKind.MemberRelationKind;
            memberRelationKind = (memberRelationKind == null) ?
                Kind.GetInstance<ListConfigurationParameterMember.Kind>() :
                memberRelationKind;
            ListConfigurationParameterMember lpm = memberRelationKind.New<ListConfigurationParameterMember>();
            lpm.SetToWhat(this);
            return lpm;
        }

        public ListConfigurationParameterMember AssureMember(Something listMemeber)
        {
            return AssureMember(listMemeber, false);
        }

        public ListConfigurationParameterMember AssureMember(Something listMember, bool isDefaultValue)
        {
            ListConfigurationParameter.Kind paramKind = (InstantiatedFrom as ListConfigurationParameter.Kind);
            ListConfigurationParameterMember.Kind memberRelationKind = paramKind.MemberRelationKind;
            memberRelationKind = (memberRelationKind == null) ? 
                Kind.GetInstance<ListConfigurationParameterMember.Kind>() : 
                memberRelationKind;
            ListConfigurationParameterMember member = memberRelationKind.Relate<ListConfigurationParameterMember>(listMember, this, true);
            member.IsDefaultValue = isDefaultValue;
            return member;
        }

        public void RemoveMember(Something listMember)
        {

            ListConfigurationParameterMember member = listMember.RelationTo<ListConfigurationParameterMember>(this);
            if (member != null)
            {
                member.Delete();
            }
        }

        public void RemoveAllMembers()
        {
            foreach (ListConfigurationParameterMember lm in ListMembers)
            {
                lm.Delete();
            }
        }

        public override T Clone<T>()
        {
            ListConfigurationParameter clone = base.Clone<T>() as ListConfigurationParameter;
            ListConfigurationParameterMember.Kind memberKind = null;

            // Clone members
            foreach (ListConfigurationParameterMember lm in ListMembers)
            {
                if (memberKind == null)
                {
                    memberKind = lm.InstantiatedFrom as ListConfigurationParameterMember.Kind;
                }

                memberKind.Relate(lm.WhatIs, clone);
            }

            return clone as T;
        }

        protected override void OnDelete()
        {
            // Delete all members
            ListMembers.ForEach((a) => a.Delete());

            base.OnDelete();
        }
    }

    public class ListConfigurationParameterMember : Relation
    {
        public new class Kind : Relation.Kind
        {
            
        }

        public bool IsDefaultValue;

        [SynonymousTo("ToWhat")]
        public readonly ListConfigurationParameter ListConfigurationParameter;

        public void SetConfigurationParameter(ListConfigurationParameter configParam)
        {
            SetToWhat(configParam);
        }
    }
}
