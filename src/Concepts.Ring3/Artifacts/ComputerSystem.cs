using System;
using System.Collections;
using System.Collections.Generic;
using Concepts.Ring1;
using Concepts.Ring2;
using Concepts.Ring3;
using Starcounter;


namespace Concepts.Ring3
{
    /// <summary>
    /// 
    /// </summary>
    public class ComputerSystem : Artifact, IConfigurationParameterOwner
    {
        
        /// <summary>
        /// Owner of this computersystem. Is used to describe the ownership structure. Owner can be different from the one that uses this computersystem.
        /// </summary>
        public Somebody Owner;

        /// <summary>
        /// Configuration of a computer system.
        /// </summary>
        public ComputerConfiguration ComputerConfiguration;


        public IEnumerable<SoftwareApplication> SoftwareApplications
        {
            get { return GetSoftwareApplications<SoftwareApplication>(); }
        }
        /// <summary>
        /// Installed software applications
        /// </summary>
        public IEnumerable<T> GetSoftwareApplications<T>() where T : SoftwareApplication
        {
            return null; //TODO:IndexedQueryHelper.GetRelatesTo<T>(this, "ComputerSystem");
        }

        /// <summary>
        /// Children of this system.
        /// </summary>
        public IEnumerable<ComputerSystem> Children
        {
            get
            {
                return null;//TODO: IndexedQueryHelper.GetRelatesTo<ComputerSystem>(this, "ConnectedTo");
            }
        }

        public IEnumerable<ConfigurationParameter> ConfigurationParameters
        {
            get { return GetConfigurationParameters<ConfigurationParameter>(); }
        }
        public IEnumerable<T> GetConfigurationParameters<T>() where T : ConfigurationParameter
        {
            return null; //TODO: IndexedQueryHelper.GetRelatesTo<T>(this, "BelongsTo");
        }

        /// <summary>
        /// <para>A ComputerSystem is connected to a ComputerSystem (ie. a Port.)</para>
        /// <example>
        /// Example:
        /// ¤ ComputerSystem
        ///  \
        ///   ¤ COM-Port 1
        ///   |\
        ///   | ¤ BarcodeReader
        ///   |
        ///   ¤ COM-Port 2
        ///    \
        ///     ¤ ReceiptPrinterEpson
        ///      \
        ///       ¤ CustomerDisplayEpson
        /// </example>
        /// </summary>
        /// 

        private ComputerSystem _connectedTo;

        [SynonymousTo("_connectedTo")]
        readonly public ComputerSystem ConnectedTo;

        /// <summary>
        /// Finds a computer system of the given kind. The search starts from this instance, so if this instance is of the given type
        /// this instance is returned.
        /// </summary>
        /// <typeparam name="T">The type of computersystem to get</typeparam>
        /// <returns></returns>
        public T Get<T>() where T : ComputerSystem
        {
            ComputerSystem parent = this;
            T parentT = null;

            while (parent != null)
            {
                if (parent is T)
                {
                    parentT = parent as T;
                    break;
                }
                parent = parent.ConnectedTo;
            }

            return parentT;
        }

        /// <summary>
        /// Finds a parent of the given type. If no parent is found, null is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetParent<T>() where T : ComputerSystem
        {
            T parentSystem = null;
            ComputerSystem parent = ConnectedTo;

            if (parent != null)
            {
                parentSystem = parent.Get<T>();
            }
            return parentSystem;
        }

        public virtual void AddChild(ComputerSystem childComputerSystem)
        {
            childComputerSystem._connectedTo = this;
            if (childComputerSystem.Owner == null)
            {
                childComputerSystem.Owner = Owner;
            }
        }
    	
    	/// <summary>
    	/// Will return <c>true</c> if <paramref name="system"/> is
    	/// a direct or indirect parent of this object
    	/// </summary>
    	/// <param name="system"></param>
    	/// <returns></returns>
    	public bool IsChildOf( ComputerSystem system )
    	{
			ComputerSystem temp = ConnectedTo;
    		while( temp != null )
    		{
				if( temp == system )
					return true;
				temp = temp.ConnectedTo;
    		}
			return false;
    	}

        private void iGetAllChildren(List<ComputerSystem> children)
        {
            foreach (ComputerSystem cs in Children)
            {
                children.Add(cs);
                cs.iGetAllChildren(children);
            }
        }

        /// <summary>
        /// Finds all ComputerSystems connected to this
        /// ComputerSystem and all devices connected to that device and so on.
        /// 
        /// Example:
        /// 
        ///  ¤ (house)
        ///   \
        ///    ¤ (room)
        ///     \
        ///      ¤ (shelf1)     to get everything from this node and 
        ///      | \                downwards use getChildren(shelf1);
        ///      |  \
        ///      |   ¤ (box1)
        ///      |   |
        ///      |   ¤ (box2)
        ///      ¤ (shelf2)
        /// </summary>
        /// <returns>IEnumerable of ComputerSystem</returns>
        public IEnumerable<ComputerSystem> AllChildren
        {
            get
            {
                List<ComputerSystem> list = new List<ComputerSystem>();
                iGetAllChildren(list);
                return list;
            }
        }

        /// <summary>
        /// Finds the ComputerSystem to this node (root node)
        /// That is the first Computersystem above a peripheral.
        /// 
        ///     ¤ -- node to return
        ///      \
        ///       ¤
        ///       | \
        ///       |  ¤
        ///       ¤  
        ///        \
        ///         ¤ --this node
        ///            
        /// </summary>
        /// <returns>The Parent ComputerSsytem</returns>
        public ComputerSystem GetRootNode()
        {
            try
            {
                ComputerSystem parent = ConnectedTo;

                if (parent != null)
                {
                    return parent.GetRootNode();
                }
                else
                {
                    return this;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in PeripheralDevice.GetRootNode(...), error message follows:");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Checks if this node has children
        /// </summary>
        /// <returns>true if it has children</returns>]
		public bool HasChildren
		{
			get
			{
                using (var e = Children.GetEnumerator())
                {
                    return e.MoveNext(); 
                }
			}
        }

        #region SystemUsers

        /// <summary>
        /// A group of users that are allowed for this computer system and all child systems.
        /// </summary>
        public SystemUserGroup UserGroup;

        public void AddUser(SystemUser systemUser)
        {
            if (systemUser != null)
            {
                SystemUserGroup group = AssureUserGroup();
                group.AddMember(systemUser);
            }
        }

        public SystemUserGroup AssureUserGroup()
        {
            SystemUserGroup group = UserGroup;

            if (group == null)
            {
                group = new SystemUserGroup();
                group.Name = this.Name + "Users";
                UserGroup = group;
            }

            return group;
        }

        /// <summary>
        /// Each computer system can have it's own user group. First check for allowed login is this computer systems group.
        /// If not member of that group, the groups of parents to this computer system will be check. If the user is found in any parents group
        /// the user is allowed.
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        public bool IsAllowedUser(SystemUser systemUser)
        {
            bool isAllowed = false;
            ComputerSystem cs = this;

            while (cs != null)
            {
                SystemUserGroup group = cs.UserGroup;

                if (group != null && group.IsMember(systemUser))
                {
                    // The user is member of this group, he is allowed
                    isAllowed = true;
                    break;
                }
                cs = cs.ConnectedTo;
            }

            return isAllowed;
        }

        #endregion


        #region IConfigurationParameterOwner Members

        public IConfigurationParameterOwner GetConfigurationParent()
        {
            return ConnectedTo;
        }
//        public ComputerSystem GetComputerSystem()
//        {
//            return ConnectedTo;
//        }

        public IEnumerable<ConfigurationParameter> GetOwnedParameters()
        {
            return GetConfigurationParameters<ConfigurationParameter>();
        }

        #endregion

        /// <summary>
        /// Checks if this is a child to the given parent. Either a child or a sub child.
        /// </summary>
        /// <param name="appRootCs"></param>
        /// <returns></returns>
        public bool IsChild(ComputerSystem wantedParent)
        {
            bool isChild = false;
            ComputerSystem parent = ConnectedTo;

            if (parent != null)
            {
                if (wantedParent.Equals(parent))
                {
                    isChild = true;
                }
                else
                {
                    isChild = parent.IsChild(wantedParent);
                }
            }

            return isChild;
        }
    }
}
