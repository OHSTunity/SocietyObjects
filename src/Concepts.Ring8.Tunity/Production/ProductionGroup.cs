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
using System.Collections.Generic;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// Group of productions
    /// </summary>
    public class ProductionGroup : Something, IObjectState
    {
            
        public ProductionGroup()
        {
            _objectState = ObjectState.Active;
            _defaultGroup = false;
            AllowProductions = false;
        }

        private ObjectState _objectState;
        public ObjectState ObjectState
        {
            get { return _objectState; }
            set { _objectState = value; }
        }

        public Boolean Active
        {
            get
            {
                return ObjectState == ObjectState.Active;
            }
        }

        public Boolean Archived
        {
            get
            {
                return ObjectState == ObjectState.Archived;
            }
        }

        public Boolean Removed
        {
            get
            {
                return ObjectState == ObjectState.Removed;
            }
        }
            /// <summary>
            /// Definition of this group is a member of a larger group.
            /// </summary>
            public ProductionGroup MemberOf
            {
                get
                {
                    return this.RelatedObject<ProductionGroup, ProductionGroupMember>();
                }
            }

            public IEnumerable<ProductionGroup> ChildGroups
            {
                get
                {
                    return this.ImplicitlyRelatedObjects<ProductionGroup, ProductionGroupMember>();
                }
            }

            public String DSID;
            public String Modified_hash;


            /// <summary>
            /// All somebodies that is a member of this group.
            /// </summary>
            public IEnumerable<ProductionGroupMember> GroupMembers
            {
                get
                {
                    return Db.SQL<ProductionGroupMember>("SELECT a FROM ProductionGroupMember a WHERE a.Group=?", this);
                }
            }

            public long Priority;
            public long MenuLevel;

            public bool AllowProductions;

            private bool _defaultGroup;
            public bool DefaultGroup
            {
                get
                {
                    return _defaultGroup;
                }
                set
                {
                    if (value != _defaultGroup)
                    {
                        _defaultGroup = value;
                        if (value) //Make sure this is the only default group
                        {
                            SqlResult<ProductionGroup> sql = Db.SQL<ProductionGroup>("SELECT a FROM ProductionGroup a");
                            foreach (ProductionGroup pg in sql)
                            {
                                if (pg != this)
                                {
                                    pg.DefaultGroup = false;
                                }
                            }
                        }
                    }
                }
            }

            public void AddMember(Something something)
            {
                ProductionGroupMember pgm = new ProductionGroupMember();
                pgm.SetGroup(this);
                pgm.SetMember(something);
            }


            public void RemoveMember(Something something)
            {
                ProductionGroupMember pgm = this.ImplicitRelationTo<ProductionGroupMember>(something);
                if (pgm != null)
                {
                    pgm.Delete();
                }
            }
            /// <summary>
            /// Is a somebody member of the group.
            /// </summary>
            /// <param name="somebody">Group member?</param>
            /// <returns>Validated answer if somebody is member of this group</returns>
            public Boolean IsMember(Something production)
            {
   
                //Check if the somebody directly is a member of this group.
                ProductionGroupMember member = production.RelationTo<ProductionGroupMember>(this);
                if (member != null)
                {
                    return true;
                }

                return false;
            }


        }

    }

