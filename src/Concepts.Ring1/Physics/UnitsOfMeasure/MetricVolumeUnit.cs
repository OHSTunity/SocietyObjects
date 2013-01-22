/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Physics/UnitsOfMeasure/MetricVolumeUnit.cs#1 $
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
    /// TODO: Summary for class:  MetricVolumeUnit
    /// </summary>
    public class MetricVolumeUnit : VolumeUnit
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        /*public new class Kind : VolumeUnit.Kind
        {
            public IEnumerable<MetricVolumeUnit> GenerateMetricVolumeUnits()
            {
                Litre l = null;
                foreach (var item in Litre.Kind.GetInstance<Litre.Kind>().GetAll<Litre>(false))
                {
                    l = item;
                    break;
                }
                if (l == null)
                {
                    l = new Litre();
                    l.ConversionRatio = 1;
                    l.Description = "Litre";
                    l.Name = "l";
                    Litre.Kind.GetInstance<Litre.Kind>().SetDefaultUnitOfMeasure(l);
                }

                Millilitre ml = null;
                foreach (var item in Millilitre.Kind.GetInstance<Millilitre.Kind>().GetAll<Millilitre>(false))
                {
                    ml = item;
                    break;
                }
                if (ml == null)
                {
                    ml = new Millilitre();
                    ml.ConversionRatio = 0.001m;
                    ml.Description = "Millilitre";
                    ml.Name = "ml";
                    Millilitre.Kind.GetInstance<Millilitre.Kind>().SetDefaultUnitOfMeasure(l);
                }

                Centilitre cl = null;
                foreach (var item in Centilitre.Kind.GetInstance<Centilitre.Kind>().GetAll<Centilitre>(false))
                {
                    cl = item;
                    break;
                }
                if (cl == null)
                {
                    cl = new Centilitre();
                    cl.ConversionRatio = 0.01m;
                    cl.Description = "Centilitre";
                    cl.Name = "cl";
                    Centilitre.Kind.GetInstance<Centilitre.Kind>().SetDefaultUnitOfMeasure(l);
                }

                Decilitre dl = null;
                foreach (var item in Decilitre.Kind.GetInstance<Decilitre.Kind>().GetAll<Decilitre>(false))
                {
                    dl = item;
                    break;
                }
                if (dl == null)
                {
                    dl = new Decilitre();
                    dl.ConversionRatio = 0.1m;
                    dl.Description = "Decilitre";
                    dl.Name = "dl";
                    Decilitre.Kind.GetInstance<Decilitre.Kind>().SetDefaultUnitOfMeasure(l);
                }
                return new List<MetricVolumeUnit> { ml, cl, dl, l };
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
        public decimal Convert(MetricVolumeUnit otherUnit, decimal quantity)
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
            return otherUnit is MetricVolumeUnit;
        }
    }
}
