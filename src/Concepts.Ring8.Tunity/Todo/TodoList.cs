/*
      =========================================================
      $Id: //Tunity/Dev/MarkII/Main/Concepts/Ring8/Project/TunityProjectEventInfo.cs#4 $
      $DateTime: 2009/11/26 13:39:19 $
      $Change: 27500 $
      $Author: davros $
      =========================================================
*/

using System;
using System.Linq;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring4;
using Concepts.Ring8.Tunity;
using Starcounter;
using Starcounter.Advanced;

namespace Concepts.Ring8.Tunity
{
    /// <summary>
    /// A tunityactivity, can be a project or something similiar
    /// 
    /// Its an event but it's not used exactly as an event...
    /// Only begintime and endtime is used, not plannedbeginTime and plannedEndtime
    /// 
    /// Special properties:
    /// Status, kan be Contemplated, Active, Finished or Rejected 
    /// 
    /// </summary>
    public class TodoList:Something, IObjectState
    {
       
        public TodoList()
        {
            ObjectState = ObjectState.Active;
        }


        public ObjectState ObjectState
        {
            get;
            set;
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
        /// Returns all comments for this todo
        /// </summary>
        /// <param name="includePerformed"></param>
        /// <returns></returns>
        public IEnumerable<Todo> Todos
        {
            get
            {
                return Db.SQL<Todo>("SELECT t FROM Todo t WHERE t.Active=? AND t.List = ?",true, this);  
            }
        }

        public int TodoCount
        {
            get
            {
                return Todos.Count();
            }
        }

    }
}
