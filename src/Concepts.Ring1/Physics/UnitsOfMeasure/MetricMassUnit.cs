/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Physics/UnitsOfMeasure/MetricMassUnit.cs#1 $
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
    /// TODO: Summary for class:  MetricMassUnit
    /// </summary>
    public class MetricMassUnit : MassUnit 
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
       /* public new class Kind : MassUnit.Kind
        {
            public IEnumerable<MetricMassUnit> GenerateMetricMassUnits()
            {
                Gram g = null;
                foreach (var item in Gram.Kind.GetInstance<Gram.Kind>().GetAll<Gram>(false))
	            {
                    g = item;
                    break;
	            }
                if (g == null)
                {
                    g = new Gram();
                    g.ConversionRatio = 1;
                    g.Description = "Gram";
                    g.Name = "g";
                    Gram.Kind.GetInstance<Gram.Kind>().SetDefaultUnitOfMeasure(g);
                }

                Hectogram hg = null;
                foreach (var item in Hectogram.Kind.GetInstance<Hectogram.Kind>().GetAll<Hectogram>(false))
                {
                    hg = item;
                    break;
                }
                if (hg == null)
                {
                    hg = new Hectogram();
                    hg.ConversionRatio = 100;
                    hg.Description = "Hectogram";
                    hg.Name = "hg";
                    Hectogram.Kind.GetInstance<Hectogram.Kind>().SetDefaultUnitOfMeasure(g);
                }

                Kilogram kg = null;
                foreach (var item in Kilogram.Kind.GetInstance<Kilogram.Kind>().GetAll<Kilogram>(false))
                {
                    kg = item;
                    break;
                }
                if (kg == null)
                {
                    kg = new Kilogram();
                    kg.ConversionRatio = 1000;
                    kg.Description = "Kilogram";
                    kg.Name = "kg";
                    Kilogram.Kind.GetInstance<Kilogram.Kind>().SetDefaultUnitOfMeasure(g);
                }
                return new List<MetricMassUnit> { g, hg, kg };
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
        public decimal Convert(MetricMassUnit otherUnit, decimal quantity)
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
            return otherUnit is MetricMassUnit;
        }
    }
}
