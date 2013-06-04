/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Commerce/Vendible/Vendible.cs#55 $
      $DateTime: 2012/01/24 13:17:34 $
      $Change: 54364 $
      $Author: tonsan $
      =========================================================
*/


#region (using)
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Concepts.Ring2;
using Concepts.Ring1;
using System.Reflection;
using Starcounter;
using Attribute = Concepts.Ring1.Attribute;

#endregion

namespace Concepts.Ring2 // Concepts.Ring2 means that approximatelly 50% of the world population are using the objects on a daily basis. The package business collects the items todo with trade between people and companies.
{
    /*
    /// <object id="Vendible.Quantify" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" height="400" width="550" align="middle" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000">
    /// 		<param name="_cx" value="14552"/>
    /// 		<param name="_cy" value="10583"/>
    /// 		<param name="FlashVars" value=""/>
    /// 		<param name="Movie" value="http://www.innowait.se/SocietyObjects/Res/Vendible.Quantify.swf"/>
    /// 		<param name="Src" value="http://www.innowait.se/SocietyObjects/Res/Vendible.Quantify.swf"/>
    /// 		<param name="WMode" value="Window"/>
    /// 		<param name="Play" value="-1"/>
    /// 		<param name="Loop" value="-1"/>
    /// 		<param name="Quality" value="High"/>
    /// 		<param name="SAlign" value=""/>
    /// 		<param name="Menu" value="-1"/>
    /// 		<param name="Base" value=""/>
    /// 		<param name="AllowScriptAccess" value="sameDomain"/>
    /// 		<param name="Scale" value="ShowAll"/>
    /// 		<param name="DeviceFont" value="0"/>
    /// 		<param name="EmbedMovie" value="0"/>
    /// 		<param name="BGColor" value="FFFFFF"/>
    /// 		<param name="SWRemote" value=""/>
    /// 		<param name="MovieData" value=""/>
    /// 		<param name="SeamlessTabbing" value="1"/>
    /// 		<span id="dxCrLf"></span>
    /// 		<span id="dxCrLf"></span>
    /// 		<span><span id="dxCrLf"></span>id="dxCrLf"&gt;</span>
    /// 		<span id="dxCrLf"></span><span id="dxCrLf"></span><span><span id="dxCrLf"></span>id="dxCrLf"&gt;</span>
    /// 		<span id="dxCrLf"></span><span id="dxCrLf"></span><span><span id="dxCrLf"></span>id="dxCrLf"&gt;</span>
    /// 		<embed src="Vendible.Quantify.swf" quality="high"/><span id="dxCrLf"></span>bgcolor="white" width="550" height="400"
    ///     name="Vendible.Quantify" <span id="dxCrLf"></span>align="middle"
    ///     allowscriptaccess="sameDomain"
    ///     <span id="dxCrLf"></span>type="application/x-shockwave-flash"
    ///     <span id="dxCrLf"></span>pluginspage="http://www.macromedia.com/go/getflashplayer"/&gt;<span id="dxCrLf">
    /// 			<span id="dxCrLf"></span></span>
    /// 		<span id="dxCrLf"><span id="dxCrLf"></span></span>
    /// 	</object>
    */

    /// <summary>
    /// A vendible is the base for goods, services, money or anything else that is traded.
    /// </summary>
    /// <remarks>
    /// Please not that vendible is a role. I.e. a dog can be a product, or rather play the
    /// role as a product, it is not necessary a product.
    /// </remarks>
    public class Vendible : Relation
    {
        #region Documentation
        /// <summary>
        /// A goods or service kind is the equalent of a product/article in a systems article database.
        /// Each article  Vendible) has an articlenumber (ID) and a short description (Name).
        /// </summary> 
        #endregion


       
        protected override void OnNew()
        {
            base.OnNew();
            RegistrationTime = DateTime.Now;
        }

        public DateTime RegistrationTime;

        public static Vendible GetVendible(Something vendibleObject, Somebody supplier)
        {
            return vendibleObject.RelationTo<Vendible>(supplier);
        }

        /// <summary>
        /// The artifact kind that is Vendible.
        /// </summary>
        [SynonymousTo("WhatIs")]
        public readonly Something VendibleObject;

        public void SetVendibleObject(Something vendibleObject)
        {
            SetWhatIs(vendibleObject);
        }

       

        public string VendibleObjectName
        {
            get
            {
                Something vo = VendibleObject;
                return vo != null ? vo.Name : string.Empty;
            }
        }
        public string VendibleObjectDescription
        {
            get
            {
                Something vo = VendibleObject;
                return vo != null ? vo.Description : string.Empty;
            }
        }

        /// <summary>
        /// Starting from this instance the a VendibleObject is found traversing up the tree.
        /// </summary>
        /// <returns></returns>
        public Something GetVendibleObject()
        {
            Something vendibleObject = null;
            Vendible vendible = this;

            while (vendible != null)
            {
                vendibleObject = vendible.VendibleObject;

                if (vendibleObject != null)
                {
                    break;
                }
                else
                {
                    vendible = vendible.GroupedIn;
                }
            }

            return vendibleObject;

        }


        /// <summary>
        /// The supplier of this Vendible.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Somebody Supplier;

        public void SetSupplier(Somebody supplier)
        {
            SetToWhat(supplier);
        }


        /// <summary>
        /// The suppliers ID of this Vendible.
        /// </summary>
        public String ID;

        private VendibleLevel _level;
        /// <summary>
        /// Determines different levels when this Vendible is part of an hierarcy.
        /// Level can only be set with the constructors.
        /// </summary>
        [SynonymousTo("_level")]
        public readonly VendibleLevel Level;

        public void SetLevel(VendibleLevel level)
        {
            _level = level;
        }
        /// <summary>
        /// Parent Vendible of which this vendible is grouped in.
        /// </summary>
        public Vendible GroupedIn;
        public void SetGroupedIn(Vendible newGroupedIn)
        {
            //Vendible oldGroupedIn = GroupedIn;
            //if (GroupedInChange != null)
            //{
            //    GroupedInChange(this, oldGroupedIn, newGroupedIn);
            //}
            GroupedIn = newGroupedIn;
        }

        /// <summary>
        /// Virtual property that can be used in word search.
        /// </summary>
        public string ArtifactName
        {
            get
            {
                Something vo = VendibleObject;
                return (vo == null) ? null : vo.Name;
            }
        }
        /* TODO
        public IEnumerable<Vendible> Children
        {
            get { return GetChildren<Vendible>(); }
        }
         */

        /*TODO
        /// <summary>
        /// The members that this Vendible contain (productgroup hierarchy).
        /// </summary>
        public IEnumerable<T> GetChildren<T>() where T : Vendible
        {
            return IndexedQueryHelper.GetRelatesTo<T>(this, "GroupedIn");
        }
        */
        /// <summary>
        /// Defines which of the children that shall be picked by default if many are available.
        /// </summary>
        public Vendible DefaultChild;

        /* TODO
        /// <summary>
        /// Returns any children matching the given supplier, articleID and unit.
        /// </summary>
        /// <param name="vendibleID"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public IEnumerable<Vendible> GetChildren(Somebody supplier, string vendibleID, UnitOfMeasure unit)
        {

            string query = string.Format(
                "SELECT v FROM {0} v WHERE v.Supplier=VAR({1}, supplier) AND"
                + "                        v.ID=VAR(String, id) AND"
                + "                        v.Unit=VAR({2}, unit)",
                FullClassName,
                supplier.FullClassName,
                unit.FullClassName);
            SqlEnumerator<Vendible> e = Sql.GetEnumerator<Vendible>(query); //, supplier, vendibleID, unit);
            e.SetVariable("supplier", supplier);
            e.SetVariable("id", vendibleID);
            e.SetVariable("unit", unit);

            // By using yield return we make sure that the enumerator is disposed
            foreach (var v in e)
            {
                yield return v;
            }
        }
         */
        /*TODO
        public IEnumerable<Vendible> GetChildrenWithLevel(VendibleLevel level)
        {
            string query = string.Format(
                "SELECT v FROM {0} v WHERE v.GroupedIn=VAR({1}, groupedIn) AND"
                + "                        v.Level=VAR({2}, level)",
                FullClassName,
                FullClassName,
                level.FullClassName);
            SqlEnumerator<Vendible> e = Sql.GetEnumerator<Vendible>(query);
            e.SetVariable("groupedIn", this);
            e.SetVariable("level", level);

            // By using yield return we make sure that the enumerator is disposed
            foreach (var v in e)
            {
                yield return v;
            }
        }*/
        /* TODO
                
        /// <summary>
        /// Returns the categories that this Vendible is member of.
        /// </summary>
        public IEnumerable<VendibleCategory.Kind> Categories
        {
            get
            {
                List<VendibleCategory.Kind> list = new List<VendibleCategory.Kind>();

                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT member.VendibleCategoryKind FROM " + VendibleCategoryMember.Kind.GetInstance<VendibleCategoryMember.Kind>().FullInstanceClassName + " member "
                    + "WHERE member.WhatIs=variable(" + Vendible.Kind.GetInstance<Vendible.Kind>().FullInstanceClassName + ", Vendible)"))
                {
                    sqlEnumerator.SetVariable("Vendible", this);

                    // By using yield return we make sure that the enumerator is disposed
                    foreach (var v in sqlEnumerator)
                    {
                        yield return v as VendibleCategory.Kind;
                    }
                }
                 * 
               
            }
        }
                */
        /*TODO
        /// <summary>
        /// Determines if this Vendiblekind has any members(productgroup hierarcy).
        /// </summary>
        public bool HasChildren
        {
            get
            {
                return GetChildren<Vendible>().GetEnumerator().MoveNext();
            }
        }
         * */

        /// <summary>
        /// Finds all identifiers of this kind.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Identifier> Identifiers
        {
            get
            {
                return null; //TODO: Kind.GetInstance<Identifier.Kind>().GetIdentifiers<Identifier>(this);
            }
        }

        #region Unit


        private UnitOfMeasure _unit;
        /// <summary>
        /// The unit of measure used for this vendible.
        /// </summary>
        [SynonymousTo("_unit")]
        public readonly UnitOfMeasure Unit;

        public void SetUnitOfMeasure(UnitOfMeasure unit)
        {
            _unit = unit;
        }

        /// <summary>
        /// Returns the smallest part of the given unit
        /// </summary>
        public Vendible SmallestPart
        {
            get
            {
                // Fetch the smallest part
                Vendible baseUnit = this;

                while (baseUnit.SmallerPart != null)
                {
                    baseUnit = baseUnit.SmallerPart;
                }

                return baseUnit;
            }
        }

        /// <summary>
        /// Fetch all smaller part of this vendible
        /// </summary>
        public IEnumerable<Vendible> AllSmallerParts
        {
            get
            {
                Vendible baseUnit = this;
                List<Vendible> list = new List<Vendible>();
                while (baseUnit.SmallerPart != null)
                {
                    list.Add(baseUnit.SmallerPart);
                }
                return list;
            }
        }

        /// <summary>
        /// Reference to a smaller unit role.
        /// </summary>
        public Vendible SmallerPart;

        /// <summary>
        /// Checks if the given vendible is a smaller part of this vendible.
        /// I.e. A Coke 33cl is a smaller part of 6-pack Coke
        /// The check is made recursevly amongst smallerParts smallerPart etc.
        /// </summary>
        /// <param name="otherVendible">The unit to check for</param>
        /// <returns>True if the given unit is a smaller part of this unit, otherwise false.</returns>
        public bool IsSmallerPartOf(Vendible otherVendible)
        {
            Vendible smallerPart = this;

            while (smallerPart != null && !smallerPart.Equals(otherVendible))
            {
                smallerPart = smallerPart.SmallerPart;
            }

            return smallerPart != null;
        }

        public bool IsEqualTo(Vendible otherVendible)
        {
            if (Unit != otherVendible.Unit)
            {
                return false;
            }

            Vendible smallerPart = SmallerPart;
            Vendible otherSmallerPart = otherVendible.SmallerPart;
            bool hasSmallerPart = smallerPart != null;
            bool otherHasSmallerPart = otherSmallerPart != null;
            if (!hasSmallerPart && !otherHasSmallerPart) // None of the vendibles have smaller parts.
            {
                return true;
            }
            if (!hasSmallerPart && otherHasSmallerPart || hasSmallerPart && !otherHasSmallerPart) // One of the vendibles have smaller part.
            {
                return false;
            }
            return smallerPart.IsEqualTo(otherSmallerPart); // Check if smaller parts are equal.
        }

        /*TODO
        public Vendible ConvertToOtherSupplier(Somebody supplier)
        {
            int combinedIndex;

            if (CombinedIndexHelper.TryGet(WhatIs, supplier, false, out combinedIndex))
            {
                string query = string.Empty;
                if (Unit == null)
                {
                    query = string.Format(
                            "SELECT v FROM {0} v "
                                + "WHERE v.CombinedIndex=variable(Int32, indexKey)",
                                FullClassName);
                }
                else
                {
                    query = string.Format(
                            "SELECT v FROM {0} v "
                                + "WHERE v.CombinedIndex=variable(Int32, indexKey) AND"
                                + "      v.Unit=variable({1}, unit)",
                                FullClassName,
                                Unit.FullClassName);
                }

                using (SqlEnumerator<Vendible> e = Sql.GetEnumerator<Vendible>(query))
                {
                    e.SetVariable("indexKey", combinedIndex);
                    if (Unit != null)
                    {
                        e.SetVariable("unit", Unit);
                    }
                    if (e.MoveNext())
                    {
                        if (e.Current.WhatIs == WhatIs &&
                            e.Current.Supplier == supplier)
                        {
                            if (IsEqualTo(e.Current))
                            {
                                return e.Current;
                            }
                        }
                    }  
                }
            }
            return null;
        }
        */
        /// <summary>
        /// Tells if this unit handles decimals
        /// </summary>
        public bool IsDecimalUnit;

        /// <summary>
        /// Converts the given quantity in this unit to DefaultUnitOfMeasure.
        /// </summary>
        /// <param name="qty"></param>
        public decimal QuantityInDefaultUnit(decimal qty)
        {
            if (Unit != null)
            {
                return Unit.QuantityInDefaultUnit(qty);
            }
            return qty;
        }

        #endregion

        #region Barcodes

        public IEnumerable<Barcode> Barcodes
        {
            get
            {
                /* TODO
                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(
                    "SELECT barcode FROM " + Barcode.Kind.GetInstance<Barcode.Kind>().FullInstanceClassName + " barcode " +
                    "WHERE barcode.Identifies=variable(" + Something.Kind.GetInstance<Something.Kind>().FullInstanceClassName + ", Vendible)"))
                {
                    sqlEnumerator.SetVariable("Vendible", this);

                    // By using yield return we make sure that the enumerator is disposed
                    foreach (var v in sqlEnumerator)
                    {
                        yield return v as Barcode;
                    }
                }*/
                return new List<Barcode>();
            }
        }

        #endregion

        /// <summary>
        /// Defines the constitution of this Vendible. For a simple Vendible e.g. Coca-Cola, this
        /// property would be null.
        /// But if the vendible kind is a compound vendible, e.g. a mixed Beer-6pack, this property
        /// would point to a configuration defining the 6-pack, e.g.
        /// <VendibleConfiguration Name="Mixed 6-pack">
        ///   <Item>
        ///     <Vendible>Piece of Weissbier</Vendible>
        ///     <Multiplier>1</Multiplier>
        ///   </Item>
        ///   <Item>
        ///     <Vendible>Piece of Ale</Vendible>
        ///     <Multiplier>1</Multiplier>
        ///   </Item>
        ///   <Item>
        ///     <Vendible>Piece of Bayersk</Vendible>
        ///     <Multiplier>4</Multiplier>
        ///   </Item>
        /// </VendibleConfiguration>
        ///   
        /// </summary>
       //TODO public VendibleConfiguration VendibleConfiguration;

        /// <summary>
        /// Returns the id used to identified this product.
        /// This is a virual property that returns the first availble id in the following chain: this.ID, VendibleObject.CreatorsModelID, MainBarcode.Name
        /// </summary>
        public string MainIdentifier
        {
            get
            {
                string id = ID;

                /*TODO
                if (string.IsNullOrEmpty(id))
                {
                    Artifact.Kind artifactKind = VendibleObject as Artifact.Kind;
                    id = (artifactKind != null) ? artifactKind.CreatorsModelID : null;

                    if (string.IsNullOrEmpty(id))
                    {
                        // Get the primary identifier and display that
                        id = GetIdentifier<Identifier>();
                    }
                }*/

                return id;
            }
        }

        /// <summary>
        /// Returns the primary identifier of the given type for the vendible object 
        /// </summary>
        /// <returns></returns>
        public String GetIdentifier<T>() where T : Identifier
        {
            return "";
            /*TODO:
            T id = null;

            foreach (T currentID in ((Identifier.Kind)Kind.Of<T>()).GetIdentifiers<T>(VendibleObject))
            {
                if (id == null)
                {
                    id = currentID as T;
                }
                else if (currentID.IsPrimary)
                {
                    // This is the primary identifier
                    id = currentID;
                    break;
                }
            }
            return id != null ? id.Name : null;
             */
        }

        public override string ToReadableString()
        {
            // Get the something and the supplier
            return string.Concat("Something: ", VendibleObject.ToReadableString(), ", Supplier: ", Supplier.ToReadableString(), " ", base.ToReadableString());
        }

        public override string ToSelectorString()
        {
            string id = MainIdentifier;
            id = (string.IsNullOrEmpty(id)) ? "" : id + " : ";
            string artName = ArtifactName;
            string name = (string.IsNullOrEmpty(artName)) ? Name : artName;

            return string.Format("{0}{1}", id, name);
        }

        /// <summary>
        /// Tells if the given somebody is a supplier of this vendible, either directly or indirectly.
        /// </summary>
        /// <param name="somebody"></param>
        /// <returns></returns>
        // TODO Units, shall this be moved to Heads.ProductView?
        public bool IsSupplier(Somebody somebody)
        {
            bool isSupplier = false;
            Somebody vendibleSupplier = Supplier;

            // TODO Units, replace with assortment logic
            if (somebody is Company)
            {
                Company c = somebody as Company;

                while (c != null)
                {
                    if (vendibleSupplier.Equals(c))
                    {
                        // We've found a supplier in the company hierarchy, so lets say that we are a supplier
                        isSupplier = true;
                        break;
                    }
                    c = c.MotherCompany;
                }
            }
            else
            {
                isSupplier = vendibleSupplier.Equals(somebody);
            }

            return isSupplier;
        }

        /// <summary>
        /// 
        /// </summary>
//        public PlacementPackageToBeMovedToExtension.Kind DefaultSalesPackage;

        /// <summary>
        /// Words searchable in the global seeker. Separate word with space.
        /// </summary>
        public string SearchWords;

//        public static event GroupedInChangeDelegate GroupedInChange;
    }
//    public delegate void GroupedInChangeDelegate(Vendible changedVendible, Vendible oldGroupedIn, Vendible newGroupedIn);
}
