/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Places/Placement.cs#33 $
      $DateTime: 2012/01/24 13:17:34 $
      $Change: 54364 $
      $Author: tonsan $
      =========================================================
*/


using Starcounter;

using System.Collections.Generic;
using System;
namespace Concepts.Ring1
{
    /// <summary>
    /// TODO: Summary for class:  Placement
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Placement
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Placement
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Placement
    /// This is an example of how to use this class.
    /// </example>
    public abstract class Placement : AddressRelation
    {
        public Placement() { }
        public Placement(decimal referedQuantity, Something placedObject, Address where)
        {
            SetReferedQuantity(referedQuantity);
            SetAddress(where);
            SetPlacedObject(placedObject);
        }
        /*public new class Kind : AddressRelation.Kind
        {

            public class PreparedStatements
            {
                public static readonly SqlPrepared FindByPlacedKindCombinedIndex;
                public static readonly SqlPrepared FindByPlacedKindIndex;

                public const string PlacedKindCombinedIndexField = "combinedIndex";
                public const string PlacedKindIndexField = "placedKind";
                public const string PackageField = "package";

                static PreparedStatements()
                {
                    string combinedIndexBase = string.Format(
                        "SELECT v FROM {0} v WHERE v.PlacedKindCombinedIndex=VAR(Int32, {1})",
                        Kind.GetInstance<Placement.Kind>().FullInstanceClassName,
                        PlacedKindCombinedIndexField);

                    FindByPlacedKindCombinedIndex = Sql.GetPrepared(combinedIndexBase);

                    string placedKindIndexBase = string.Format(
                        "SELECT v FROM {0} v WHERE v.PlacedKind=VAR({1}, {2})",
                        Kind.GetInstance<Placement.Kind>().FullInstanceClassName,
                        Kind.GetInstance<Something.Kind>().FullInstanceClassName,
                        PlacedKindIndexField);

                    FindByPlacedKindIndex = Sql.GetPrepared(placedKindIndexBase);
                }
            }



            public virtual T New<T>(decimal referedQuantity, Something placedObject, Address where) where T : Placement
            {
                T placement = New<T>();
                placement.SetReferedQuantity(referedQuantity);
                placement.SetAddress(where);
                placement.SetPlacedObject(placedObject);
                return placement;
            }

            #region Placements for Objects
            public IEnumerable<Placement> PlacementsForObject(Something placedObject, Address address, IPlacementFilter filter)
            {
                if (filter.Recursive)
                {
                    foreach(Placement p in placedObject.ImplicitRoles<Placement>(this))
                    {
                        Address a = p.Address;
                        if (a != null && a.FullInternalAddressID.StartsWith(address.FullInternalAddressID))
                        {

                            if (filter != null)
                            {
                                if (filter.IsValid(p))
                                {
                                    yield return p;
                                }
                            }
                            else
                            {
                                yield return p;
                            }
                        }
                    }
                }
                else
                {
                    foreach(Placement p in address.RelationsTo<Placement>(this,placedObject))
                    {
                        if (filter != null)
                        {
                            if (filter.IsValid(p))
                            {
                                yield return p;
                            }
                        }
                        else
                        {
                            yield return p;
                        }
                    }
                }
            }

            public decimal SumPlacementsForObject(Something placedObject, Address address, IPlacementFilter filter)
            {
                decimal sum = 0;
                foreach (Placement p in PlacementsForObject(placedObject, address, filter))
                {
                    sum += p.ReferedQuantity;
                }
                return sum;
            }
            #endregion

        }
         */

        public Something PlacedKind;

        public override void SetQuantity(decimal quantity)
        {
            base.SetQuantity(quantity);
        }

        [SynonymousTo("Quantity")]
        public readonly decimal ReferedQuantity;
        public void SetReferedQuantity(decimal referedQuantity)
        {
            SetQuantity(referedQuantity);
        }

        [SynonymousTo("ToWhat")]
        public readonly Something PlacedObject;
        public void SetPlacedObject(Something placedObject)
        {
            SetAddressee(placedObject);
        }

        public override void SetToWhat(Something placedObject)
        {

            base.SetToWhat(placedObject);
        }

        public override void SetValue(Something address)
        {
            base.SetValue(address);
        }


        public PlacementPackageToBeMovedToExtension PlacementPackageToBeMovedToExtension;
        public decimal PackageQuantity
        {
            get
            {
                PlacementPackageToBeMovedToExtension pp = PlacementPackageToBeMovedToExtension;
                if (pp != null)
                {
                    //TODO return pp.CalculatePackageQuantity(ReferedQuantity);
                }
                return 0;
            }
        }

        public override T Clone<T>()
        {
            Placement p = base.Clone<Placement>();
            p.PlacementPackageToBeMovedToExtension = PlacementPackageToBeMovedToExtension;
            return p as T;
        }

        /*
        private static IEnumerable<Placement> PlacementsNotRecursive(Something.Kind placedKind, Address address, IPlacementFilter filter)
        {
            int combinedIndex;

            if (CombinedIndexHelper.TryGet(address, placedKind, false, out combinedIndex)) 
            {
                using (SqlEnumerator<Placement> sql = Sql.GetEnumerator<Placement>(
                    Placement.Kind.PreparedStatements.FindByPlacedKindCombinedIndex))
                {
                    sql.SetVariable(
                                Placement.Kind.PreparedStatements.PlacedKindCombinedIndexField,
                                combinedIndex);

                    while (sql.MoveNext())
                    {
                        if (sql.Current.Address == address &&
                            sql.Current.PlacedKind == placedKind)
                        {
                            if (filter != null)
                            {
                                if (filter.IsValid(sql.Current))
                                {
                                    yield return sql.Current;
                                }
                            }
                            else
                            {
                                yield return sql.Current;
                            }
                        }
                    } 
                }
            }
        }
        private static IEnumerable<Placement> PlacementsRecursive(Something.Kind placedKind, Address address, IPlacementFilter filter)
        {
            using (SqlEnumerator<Placement> placements = 
                Sql.GetEnumerator<Placement>(Placement.Kind.PreparedStatements.FindByPlacedKindIndex))
            {
                placements.SetVariable(Placement.Kind.PreparedStatements.PlacedKindIndexField, placedKind);
                foreach (Placement p in placements)
                {
                    if (p.Address.IsIn(address))
                    {
                        if (filter != null)
                        {
                            if (filter.IsValid(p))
                            {
                                yield return p;
                            }
                        }
                        else
                        {
                            yield return p;
                        }

                    }
                } 
            }
        }


        public static IEnumerable<Placement> Placements(Something.Kind placedKind, Address address, IPlacementFilter filter)
        {
            return filter.Recursive ? 
                PlacementsRecursive(placedKind, address, filter) : 
                PlacementsNotRecursive(placedKind, address, filter);
        }
        
        public static decimal SumPlacements(Something.Kind placedKind, Address address, IPlacementFilter filter)
        {
            decimal sum = 0;

            foreach (Placement p in Placements(placedKind, address, filter))
            {
                sum += p.ReferedQuantity;
            }
            return sum;
        }
        */
    }

    public class PositivePlacement : Placement
    {
    }

    public class NegativePlacement : Placement
    {
    }

    public class PlacementPackageToBeMovedToExtension : Something
    {
        /*public new class Kind : Something.Kind
        {
            //}
            /// <summary>
            /// TODO: change/move in/to PlacementPackageToBeMovedToExtension
            /// </summary>
            public decimal ConversionRatio;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="baseQuantity"></param>
            /// <returns></returns>
            public decimal CalculatePackageQuantity(decimal baseQuantity)
            {
                if (ConversionRatio > 0)
                {
                    return baseQuantity / ConversionRatio;
                }
                return 0;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="baseQuantity"></param>
            /// <returns></returns>
            public int CalculateUnbrokenPackageQuantity(decimal baseQuantity)
            {
                if (ConversionRatio > 0)
                {
                    return Convert.ToInt32(Math.Floor(baseQuantity / ConversionRatio));
                }
                return 0;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="quantity"></param>
            /// <returns></returns>
            public decimal ConvertToBaseQuantity(decimal packageQuantity)
            {
                if (ConversionRatio > 0)
                {
                    return packageQuantity * ConversionRatio;
                }
                return 0;
            }

            public string FullName
            {
                get
                {
                    if (!string.IsNullOrEmpty(Name) && ConversionRatio > 0)
                    {
                        return string.Format("{1} à {0}", ConversionRatio, Name);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            public override string ToSelectorString()
            {
                return FullName;
            }

        }
        */
    }
}
