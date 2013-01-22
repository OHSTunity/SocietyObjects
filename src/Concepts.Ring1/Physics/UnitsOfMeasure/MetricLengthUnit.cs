/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Physics/UnitsOfMeasure/MetricLengthUnit.cs#1 $
      $DateTime: 2012/01/24 13:17:34 $
      $Change: 54364 $
      $Author: tonsan $
      =========================================================
*/


using Concepts.Ring1;
using System;
using System.Collections.Generic;

namespace Concepts.Ring1
{
    /// <summary>
    /// TODO: Summary for class:  MetricLengthUnit
    /// </summary>
    public class MetricLengthUnit : LengthUnit
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        /*public new class Kind : LengthUnit.Kind
        {
            public IEnumerable<MetricLengthUnit> GenerateMetricLengthUnits()
            {
                Metre m = null;
                foreach (var item in Metre.Kind.GetInstance<Metre.Kind>().GetAll<Metre>(false))
                {
                    m = item;
                    break;
                }
                if (m == null)
                {
                    m = new Metre();
                    m.ConversionRatio = 1;
                    m.Description = "Metre";
                    m.Name = "m";
                    Metre.Kind.GetInstance<Metre.Kind>().SetDefaultUnitOfMeasure(m);
                }

                Millimetre mm = null;
                foreach (var item in Millimetre.Kind.GetInstance<Millimetre.Kind>().GetAll<Millimetre>(false))
                {
                    mm = item;
                    break;
                }
                if (mm == null)
                {
                    mm = new Millimetre();
                    mm.ConversionRatio = 0.001m;
                    mm.Description = "Millimetre";
                    mm.Name = "mm";
                    Millimetre.Kind.GetInstance<Millimetre.Kind>().SetDefaultUnitOfMeasure(m);
                }

                Centimetre cm = null;
                foreach (var item in Centimetre.Kind.GetInstance<Centimetre.Kind>().GetAll<Centimetre>(false))
                {
                    cm = item;
                    break;
                }
                if (cm == null)
                {
                    cm = new Centimetre();
                    cm.ConversionRatio = 0.01m;
                    cm.Description = "Centimetre";
                    cm.Name = "cm";
                    Centimetre.Kind.GetInstance<Centimetre.Kind>().SetDefaultUnitOfMeasure(m);
                }

                Decimetre dm = null;
                foreach (var item in Decimetre.Kind.GetInstance<Decimetre.Kind>().GetAll<Decimetre>(false))
                {
                    dm = item;
                    break;
                }
                if (dm == null)
                {
                    dm = new Decimetre();
                    dm.ConversionRatio = 0.1m;
                    dm.Description = "Decimetre";
                    dm.Name = "dm";
                    Decimetre.Kind.GetInstance<Decimetre.Kind>().SetDefaultUnitOfMeasure(m);
                }

                Kilometre km = null;
                foreach (var item in Kilometre.Kind.GetInstance<Kilometre.Kind>().GetAll<Kilometre>(false))
                {
                    km = item;
                    break;
                }
                if (km == null)
                {
                    km = new Kilometre();
                    km.ConversionRatio = 1000;
                    km.Description = "Kilometre";
                    km.Name = "km";
                    Kilometre.Kind.GetInstance<Kilometre.Kind>().SetDefaultUnitOfMeasure(m);
                }
                return new List<MetricLengthUnit> { mm, cm, dm, m, km };
            }
        }
        */
        #endregion

        /// <summary>
        /// Converts the given quantity of this unit of measure into the other unit.
        /// I.e. litre.Convert(gallon, 3.6); would return 1 since 3.6 litre is aprox 1 gallon.
        /// </summary>
        /// <param name="unitOfMeasure"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public decimal Convert(MetricLengthUnit otherUnit, decimal quantity)
        {
            decimal convertedQty = 0;
            convertedQty = (quantity * ConversionRatio) / otherUnit.ConversionRatio;
            return convertedQty;
        }

        public override bool IsSameType(Concepts.Ring1.UnitOfMeasure otherUnit)
        {
            if (otherUnit == null)
            {
                return false;
            }
            return otherUnit is MetricLengthUnit;
        }

    }
}
