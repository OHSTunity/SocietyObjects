/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring3/Attributes/Genre.cs#1 $
      $DateTime: 2009/05/14 10:39:22 $
      $Change: 21850 $
      $Author: headstestdev $
      =========================================================
*/

#region Using directives
using Concepts.Ring1;
using System; 
#endregion

namespace Concepts.Ring3
{
    /// <summary>
    /// Summary for class:  Genre
    /// 
    /// A genre for a literary work
    /// 
    /// </summary>
    /// <remarks>
    /// TODO: Remarks for class: Genre
    /// In this section, we can put a longer description
    /// <para>
    /// TODO: Paragraph for class: Genre
    /// This is a paragraph describing this class in more detail.
    /// </para>
    /// </remarks>
    /// 
    /// <example>
    /// TODO: Example for class: Genre
    /// This is an example of how to use this class.
    /// </example>
    public class Genre : Something
    {
        #region Kind

        /// <summary>
        /// The runtime representation of the kind.
        /// </summary>
        public new class Kind : Something.Kind
        {

        }

        #endregion

        protected override void OnNew()
        {
            // TODO

            base.OnNew();
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
