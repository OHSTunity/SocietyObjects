/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Physics/UnitsOfMeasure/UnitOfMeasure.cs#5 $
      $DateTime: 2012/01/24 13:17:34 $
      $Change: 54364 $
      $Author: tonsan $
      =========================================================
*/

using System;
using Concepts.Ring1;
using Starcounter;

using System.Collections.Generic;

namespace Concepts.Ring1
{
	/// <summary>
    /// A standard of measurement for some dimension. For example, the Meter is a unit of measure for the dimension of length (same as the sumo definition).
    /// </summary>
    /// <ontology>
    /// <equal>sumo:UnitOfMeasure</equal>
    /// <equal>wordnet:10624551</equal>
    /// </ontology>
	public class UnitOfMeasure : Something
	{
        /// <summary>
        /// The UnitOfMeasure class has one or more associated Kind objects. These objects are instances of this class.
        /// </summary>
        /// <seealso cref="Concepts.Ring1.Something.Kind"/>
        /*public new class Kind : Concepts.Ring1.Something.Kind
        {
            /// <summary>
            /// Returns the UnitOfMeasure with the given name, null might be returned.
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public UnitOfMeasure Get(String name)
            {
                UnitOfMeasure unitOfMeasure = null;
                String query = String.Format(
                    "SELECT uom FROM {0} uom WHERE uom.Name=variable(String, name)",
                    FullInstanceClassName);

                using (SqlEnumerator sqlEnumerator = Sql.GetEnumerator(query))
                {
                    sqlEnumerator.SetVariable("name", name);

                    if (sqlEnumerator.MoveNext())
                    {
                        unitOfMeasure = sqlEnumerator.Current as UnitOfMeasure;
                    } 
                }
                return unitOfMeasure;
            }

            /// <summary>
            /// A readonly property for fetching the default unit.
            /// </summary>
            [SynonymousTo("_DefaultUnitOfMeasure")]
            public readonly UnitOfMeasure DefaultUnit;

            /// <summary>
            /// The default unit of measure for this Kind.
            /// This value can only be set once, therefore its private.
            /// </summary>
            private UnitOfMeasure _DefaultUnitOfMeasure;

            internal void SetDefaultUnitOfMeasure(UnitOfMeasure unit)
            {
                if (_DefaultUnitOfMeasure != null)
                {
                    throw new ApplicationException("Once the default unit for a UnitOfMeasure has been set it can never be changed!");
                }
                _DefaultUnitOfMeasure = unit;
            }
        }
        */

	    /// <summary>
	    /// Returns the conversion ration for this UnitOfMeasure and the DefaultUnit for the UnitOfMeasureKind.
	    /// </summary>
	    /// <example>
	    /// UnitOfMeasure.Kind length = ((UnitOfMeasure.Kind) Kind.Of<UnitOfMeasure>()).AssureKind("Length");
	    /// UnitOfMeasure metre = length.Assure("Metre");
	    /// ((DefaultUnit.Kind) Kind.Of<DefaultUnit>()).Relate(metre, length);
	    /// metre.ConversionRation = 1;
	    /// 
	    /// // Lets fetch an other UnitOfMeasure, foot. 
        /// // One foot is Approximately 30cm, e.g. 0.3 metre.
	    /// UnitOfMeasure foot = length.Assure("Foot");
	    /// foot.ConversionRatio = 0.3
	    /// </example>
        public decimal ConversionRatio;

        public decimal QuantityInDefaultUnit(decimal qty)
        {
            return qty * ConversionRatio;
        }

        public virtual bool IsSameType(UnitOfMeasure otherUnit)
        {
            return false;
        }

        public override string ToSelectorString()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                return Description;
            }
            return base.ToSelectorString();
        }
    }
}	 
