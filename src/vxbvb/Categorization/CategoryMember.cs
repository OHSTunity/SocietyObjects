/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Categorization/CategoryMember.cs#2 $
      $DateTime: 2009/06/04 14:50:55 $
      $Change: 22568 $
      $Author: freblo $
      =========================================================
*/

#region Using directives
using Concepts.Ring1;
using System;
using Starcounter; 
#endregion

namespace Concepts.Ring2
{
    /// <summary>
    /// TODO: Summary for class:  CategoryMember
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: CategoryMember
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: CategoryMember
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: CategoryMember
    /// This is an example of how to use this class.
    /// </example>
    public abstract class CategoryMember : Relation
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Relation.Kind
        {
        }

        #endregion

        /// <summary>
        /// The category the something is member of.
        /// </summary>
        [SynonymousTo("ToWhat")]
        public readonly Category.Kind CategoryKind;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryKind"></param>
        public void SetVendibleCategoryKind(Category.Kind categoryKind)
        {
            SetToWhat(categoryKind);
        }

        protected override void OnNew()
        {
            base.OnNew();
            // TODO
        }

        protected override void OnDelete()
        {
            // TODO

            base.OnDelete();
        }

        public override string ToSelectorString()
        {
            // TODO
            return base.ToSelectorString();
        }

        public override string ToReadableString()
        {
            // TODO
            return base.ToReadableString();
        }
    }
}
