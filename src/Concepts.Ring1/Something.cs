/* 
 * Add overridable bool CanHaveOtherQuantityThanOne() to Something and Something.Kind
 * overridable bool Something::CanHaveOtherQuantityThanOne()
 * (
 *   return KindOf(this).CanHaveOtherQuantityThanOne();
 * )
 * 
 * overridable bool Something.Kind::CanHaveOtherQuantityThanOne()
 * (
 *      return false;
 * )
 * 
 * Add overridable bool CanBeFuture() to Something and Something.Kind
 * Add overridable bool CanBePast() to Something and Something.Kind 
 * 
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// 	<para><img src="http://www.innowait.se/societyobjects/res/oldteacher_mod.jpg" align="left"/>This is the SocietyObject equivalent of the Object root class. Each
    ///     something represents a real world physical or abstract concept.</para>
    /// </summary>
    /// <remarks>
    /// 	<para><img id="dxCrLf" src="http://www.innowait.se/societyobjects/res/something.jpg" align="right"/></para>
    /// 	<para class="">A Something object is always persistent. If you change any of its
    ///     properties, they are immediatelly visible when you perform a query on the database.
    ///     However, outside transactions will not notice any changes until your transaction
    ///     has commited.</para>
    /// 	<h6 class="">DefinedBy and ProvidedBy</h6>
    /// 	<para>The difference between Something and the Object root classes is that
    ///     Something adds a definer and a provider to each object. This means that all
    ///     objects, including every class (or Kind), knows who owns its definition.As
    ///     SocietyObjects mimics the our perception of the real world, and as our perception
    ///     of the real world concepts is formed throughout history by all of us and all of our
    ///     ancestors, the most common definer is the
    ///     <see cref="Somebody.GeneralSociety">GeneralSociety Somebody
    ///     Concepts.Ring1.Somebody)</see>.</para>
    /// 	<para>The property ProvidedBy is important as there might be conflicting version in
    ///     SocietyObject that correspons to a real world object. A typical example of this is
    ///     the Person object. A person is typically defined by an authority in a specific
    ///     country, where the name of the person is registred (althogh a person can be defined
    ///     by anybody, the goverment defined person is the more rigid defintion). It is
    ///     seldomly that the definition (the data) of the person is provided by that authority
    ///     though (thank god for that, big brother). In the case of a Person, the
    ///     <see cref="ProvidedBy">ProvidedBy Property</see> and the
    ///     <see cref="DefinedBy">DefinedBy Property</see> normally points to different
    ///     Somebodies. Provider is normally a system owner and defined by is a
    ///     government.</para>
    /// 	<para>When combinded with the powerfull version handling of the Innowait Database
    ///     System, SocietyObjects can manage an object as a single entity although there are
    ///     different providers with different views on its data. This means that all users of
    ///     SocietyObjects could have their data stored in a single global database and both
    ///     share data and keep their integrety as needed.</para>
    /// 	<h6 class="">Transactions</h6>
    /// 	<para>When it is created it will only be visible by its own transaction until that
    ///     transaction has been commited. There is no concept of storing or retrieving an
    ///     object from the database as the object is always persistent in the database. This
    ///     means that your object is always of the latest version. When performing a query on
    ///     the database, the changes your transaction has done to the object will be taken
    ///     into consideration. For outside transactions though, they will not notice anything
    ///     until your whole transaction is complete.</para>
    /// </remarks>
    /// <ontology>
    /// <equal>sumo:Entity</equal>
    /// </ontology>
    [Database]
    public class Something: IEntity
    {
        
        protected Something()
            : base()
        {
        }

        public virtual void OnDelete()
        {
        }

        protected virtual void OnNew()
        {
        }

        public virtual string ToReadableString()
        {
            return "";
        }

        /// <summary>
        /// Each object may have a name or a title containing a single line of text.
        /// </summary>
        public string Name;

        /// <summary>
        /// Each object may have a description containing one or more lines of text.
        /// </summary>
        public string Description;

       
        /// <summary>
        /// An instance of something can be quantified.
        /// TODO, better explanation.
        /// </summary>
        public decimal Quantity;

      
        /// <summary>
        /// Create a copy of this object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Clone<T>() where T : Something
        {
            T obj = Activator.CreateInstance<T>();
            return obj;
        }

       
        public string DbIDString
        {
            get
            {
                return DbHelper.GetObjectID(this);
            }
        }

       

        /// <summary>
        /// When this object is displayed in a selector (e.g.) a list box
        /// a describing string shall be used. This is the source of that 
        /// describing string.
        /// </summary>
        /// <returns></returns>
        public virtual string ToSelectorString()
        {
            string name = Name;

            if (string.IsNullOrEmpty(name))
            {
                name = string.Format("{0}: {1}", GetType().Name, DbHelper.GetObjectID(this));
            }

            return Name;
        }

        public string SelectorString
        {
            get
            {
                return ToSelectorString();
            }
        }

        /// <summary>
        /// An SQL-safe full type name. 
        /// E.g. if the namespace or class is Order, which is a keyword, it will be replaced by [Order]
        /// </summary>
        [DebuggerHidden]
        public virtual string FullClassName
        {
            get
            {
                return SqlNamespaceHelper.GetSafe(GetType().FullName);
            }
        }
        #region Roles and Relations

        #region Roles
        /// <summary>
        /// Roles of a given type T for this object of present time.
        /// </summary>
        /// <typeparam name="T">Type of Roles to retrieve and return</typeparam>
        /// <returns>All roles of the given typ T</returns>
        public QueryResultRows<T> Roles<T>() where T : Role
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T>(String.Format("SELECT r FROM {0} r WHERE r.WhatIs=?", SqlNamespaceHelper.GetSafe<T>()), this);
        }
        
        /// <summary>
        /// Implicit Roles of a given type T for this object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve and return</typeparam>
        /// <returns>All roles of the given type T</returns>
        public QueryResultRows<T> ImplicitRoles<T>() where T : Relation
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T>(String.Format("SELECT r FROM {0} r WHERE r.ToWhat=?", SqlNamespaceHelper.GetSafe<T>()), this);
        }
        
        /// <summary>
        /// The first Role found of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve</typeparam>
        /// <returns>The first Role found of the given type T</returns>
        public T Role<T>() where T : Role
        {
            return Roles<T>().First;
        }

        /// <summary>
        /// The first Role found of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve</typeparam>
        /// <returns>The first Role found of the given type T</returns>
        public T ImplicitRole<T>() where T : Relation
        {
            return ImplicitRoles<T>().First;
        }
        
        #endregion

        #region Relations to
        /// <summary>
        /// Relations of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve</typeparam>
        /// <param name="toWhat">The object this object have a relation to</param>
        /// <returns>All relations of the given type T</returns>
        public QueryResultRows<T> RelationsTo<T>(Something toWhat) where T : Relation
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T>(String.Format("SELECT r FROM {0} r WHERE r.WhatIs=? AND r.ToWhat=?", 
                SqlNamespaceHelper.GetSafe<T>()), this, toWhat);
        }

        /// <summary>
        /// Implicit Relations of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve and return</typeparam>
        /// <param name="WhatIs">The object this object have a relation to</param>
        /// <returns>All relations of the given type T</returns>
        public QueryResultRows<T> ImplicitRelationsTo<T>(Something whatIs) where T : Relation
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T>(String.Format("SELECT r FROM {0} r WHERE r.WhatIs=? AND r.ToWhat=?",
                SqlNamespaceHelper.GetSafe<T>()), whatIs, this);
        }
        
        /// <summary>
        /// The first Relation found of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve</typeparam>
        /// <param name="toWhat">The object this object have a relation to</param>
        /// <returns>All relations of the given type T</returns>
        public T RelationTo<T>(Something toWhat) where T : Relation
        {
            return RelationsTo<T>(toWhat).First;
        }

        /// <summary>
        /// Implicit Relations of a given type T between this object and another object
        /// </summary>
        /// <typeparam name="T">Type of roles to retrieve and return</typeparam>
        /// <param name="WhatIs">The object this object have a relation to</param>
        /// <returns>The first relation of the given type T</returns>
        public T ImplicitRelationTo<T>(Something whatIs) where T : Relation
        {
            return ImplicitRelationsTo<T>(whatIs).First;
        }
        
        #endregion

        #region Related objects
        /// <summary>
        /// Finds all objects this object is related to
        /// </summary>
        /// <typeparam name="T_Object"></typeparam>
        /// <typeparam name="T_Relation"></typeparam>
        /// <returns></returns>
        public QueryResultRows<T_Object> RelatedObjects<T_Object, T_Relation>()
            where T_Object : Something
            where T_Relation : Relation
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T_Object>(String.Format("SELECT s FROM {0} s JOIN {1} r ON r.ToWhat=s WHERE r.WhatIs=?",
                SqlNamespaceHelper.GetSafe<T_Object>(), SqlNamespaceHelper.GetSafe<T_Relation>()), this);
        }

        /// <summary>
        /// Finds all objects this object is implicitly related to
        /// </summary>
        /// <typeparam name="T_Object"></typeparam>
        /// <typeparam name="T_Relation"></typeparam>
        /// <returns></returns>
        public QueryResultRows<T_Object> ImplicitlyRelatedObjects<T_Object, T_Relation>()
            where T_Object : Something
            where T_Relation : Relation
        {
            //TODO:Change to typeof sql string
            return Db.SQL<T_Object>(String.Format("SELECT s FROM {0} s JOIN {1} r ON r.WhatIs=s WHERE r.ToWhat=?",
                 SqlNamespaceHelper.GetSafe<T_Object>(), SqlNamespaceHelper.GetSafe<T_Relation>()), this);
        }
        
        /// <summary>
        /// Find first object this object is related to
        /// </summary>
        /// <typeparam name="T_Object"></typeparam>
        /// <typeparam name="T_Relation"></typeparam>
        /// <returns></returns>
        public T_Object RelatedObject<T_Object, T_Relation>()
            where T_Object : Something
            where T_Relation : Relation
        {
            return RelatedObjects<T_Object, T_Relation>().First;
        }

        /// <summary>
        /// Find first object this object is implicitly related to
        /// </summary>
        /// <typeparam name="T_Object"></typeparam>
        /// <typeparam name="T_Relation"></typeparam>
        /// <returns></returns>
        public T_Object ImplicitlyRelatedObject<T_Object, T_Relation>()
            where T_Object : Something
            where T_Relation : Relation
        {
            return ImplicitlyRelatedObjects<T_Object, T_Relation>().First;
        }


        

        #endregion

        #region Relate
        
        /// <summary>
        /// Create a relation of type T to object toWhat
        /// (no check or assure)
        /// </summary>
        /// <typeparam name="T">Type of Relation to create</typeparam>
        /// <param name="toWhat">Object to create relation to</typeparam>
        /// <returns>All roles of the given typ T</returns>
        public T Relate<T>(Something toWhat) where T : Relation
        {
            T r = Activator.CreateInstance<T>();
            r.SetWhatIs(this);
            r.SetToWhat(toWhat);
            return r;
        }

        #endregion

        #endregion
        /*
        #region operators
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
            public static Boolean operator ==(Something x, Something y)
            {
                if ((x != null) && (y != null))
                    return DbHelper.GetObjectID(x) == DbHelper.GetObjectID(y);
                else
                    return (x == null && y == null);
            }

            // Inequality operator. Returns dbNull if either operand is
            // dbNull, otherwise returns dbTrue or dbFalse:
            public static Boolean operator !=(Something x, Something y)
            {
                if ((x != null) && (y != null))
                    return DbHelper.GetObjectID(x) != DbHelper.GetObjectID(y);
                else
                    return (x == null && y == null);
            }

        #endregion
        */
    }
}


