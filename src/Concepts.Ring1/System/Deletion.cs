// Move to Ring1.System subfolder

using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring1
{
    /// <summary>
    /// History handling of removing of objects. 
    /// </summary>
    /// <remarks>
    /// Has no responsibility for handling of deletion.
    /// </remarks>
    public class Deletion : ObjectChange
    {
        /*
        /// <summary>
        /// The Kind class is a fundamental concept in Society Objects. 
        /// Read more about it in the basic introduction to Society Objects.
        /// </summary>
        /// <seealso cref="Concepts.Ring1.Something.Kind"/>
        public new class Kind : ObjectChange.Kind 
        {
            /// <summary>
            /// Factory for making a history object.
            /// </summary>
            /// <param name="something"></param>
            /// <param name="modifier"></param>
            /// <returns></returns>
            public Deletion LogDelete(Something something, Something modifier)
            {
                Deletion deletion = new Deletion();
                deletion.BeginTime = DateTime.Now;
                deletion.AssureParticipant<Modifier>(GetInstance<Modifier.Kind>(),modifier);
                deletion.DeletedObjectIDString = something.ObjectIDString;
                deletion.DeletedObjectKind = something.InstantiatedFrom as Something.Kind;
                deletion.DeletedObjectName = something.Name;

                return deletion;
            }
        }*/

        /// <summary>
        /// Object identification of the deleted object.
        /// </summary>
        public String DeletedObjectIDString;
        
        /// <summary>
        /// Name of the deleted object.
        /// </summary>
        public String DeletedObjectName;
        
        /// <summary>
        /// TODO: Kind of the deleted object.
        /// </summary>
       // public Something.Kind DeletedObjectKind;
    }
}
