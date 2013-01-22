/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Comprehension/IWordIndexUpdate.cs#2 $
      $DateTime: 2008/12/19 16:25:52 $
      $Change: 17717 $
      $Author: careri $
      =========================================================
*/


using System.Collections.Generic;

namespace Concepts.Ring1
{
    /*
    public enum IWordIndexUpdateMode
    {
        NEW,
        UPDATE
    }

    public interface IWordIndexUpdate
    {
        /// <summary>
        /// Reloads the persistent objects from the database, this might be needed if an update fails due to transaction conflicts.
        /// </summary>
        void Refresh();

        /// <summary>
        /// The owner of this update
        /// </summary>
        Something Owner { get; }

        /// <summary>
        /// Tells if the update is for a new object, or an update to an old object.
        /// </summary>
        IWordIndexUpdateMode UpdateMode { get; }

        /// <summary>
        /// Returns the HasWord relations for the given attribute.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        IEnumerable<HasWord> CurrentWordRelations(WordIndexAttribute.Kind attribute);

        /// <summary>
        /// Returns the new words that is being commited.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        IEnumerable<string> NewWords(WordIndexAttribute.Kind attribute);

        /// <summary>
        /// The attributes that are bound to this instance.
        /// </summary>
        IEnumerable<WordIndexAttribute.Kind> Attributes { get; }

        /// <summary>
        /// Returns an existing word relation for the given string
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        HasWord GetCurrentRelation(WordIndexAttribute.Kind attribute, string newValue);
    }
     */
}
