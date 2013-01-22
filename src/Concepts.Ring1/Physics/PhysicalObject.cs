namespace Concepts.Ring1
{
	/// <summary>
	/// A physical object is a reference to a collection of matter at no specific point
	/// in time. Examples of physical objects include a cars, girls, motorcycles and
	/// wine.
	/// </summary>
	/// <remarks>
	/// 	<para><strong>TODO! Move the below to the Goods class.</strong></para>
	/// 	<para>SocietyObjects uses compound objects to handle objects that are (or inherits)
	///     multiple kinds (see the <see cref="Something.Melt">Melt Method</see>). For
	///     instance, if there is a need to reference an actual physical object when handling a
	///     piece of goods, the Goods object and the PhysicalObject can be melted together.
	///     Although it is normal to view a piece of goods as an entity without using a
	///     PhysicalObject. In this scenario, both Goods.Kind objects and PhysicalObject
	///     objects may have a weight property. The difference is that whereas the
	///     PhysicalObject weight is a weight measurement of the object at an unknown point in
	///     time, the weight of the Goods.Kind is the specified weight to expect from the
	///     instances (the pieces) of the goods.</para>
	/// </remarks>
    /// <ontology>
    /// <equal>wordnet:00011410</equal>
    /// </ontology>
    public class PhysicalObject : Something
    {
        /// <summary>
        /// The current mass of the physical object
        /// </summary>
        public decimal Weight;

        /// <summary>
        /// The unit of the current mass of the physical object
        /// </summary>
        public MassUnit MassUnit;

        //public override UnitOfMeasure GetUnit()
        //{
        //    return UnitOfMeasure;
        //}

        ///// <summary>
        ///// The unit of measure used to define the QuantificationQuantity.
        ///// </summary>
        //private UnitOfMeasure UnitOfMeasure;

        ///// <summary>
        ///// Physical location in space
        ///// </summary>
        //public Location Location;
    }
}
