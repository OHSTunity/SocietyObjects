/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring2/Addressing/Places/Postal/PostAddressComponent.cs#9 $
      $DateTime: 2010/02/16 17:16:05 $
      $Change: 29427 $
      $Author: careri $
      =========================================================
*/

using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Starcounter;

namespace Concepts.Ring2
{
    public class PostAddressComponent : Place
    {
        public new class Kind : Place.Kind 
        {
            /// <summary>
            /// Finds an instance of this kind with the given parent and name.
            /// </summary>
            /// <typeparam name="T">The class that the return value is casted to. T doesnt affect the query itself.</typeparam>
            /// <param name="name">The name of the PostAddressComponent to create</param>
            /// <param name="parent">The parent that the address component shall be connected to.</param>
            /// <returns></returns>
            public virtual T Get<T>(string name, PostAddressComponent parent) where T : PostAddressComponent
            {
                return parent.GetChild<T>(name);
            }

            /// <summary>
            /// Assures an instance of this kind with the given parent.
            /// </summary>
            /// <typeparam name="T">The class that the return value is casted to. T doesnt affect the query itself.</typeparam>
            /// <param name="name">The name of the PostAddressComponent to create</param>
            /// <param name="parent">The parent that the address component shall be connected to.</param>
            /// <returns></returns>
            public virtual T Assure<T>(string name, PostAddressComponent parent) where T : PostAddressComponent
            {
                return parent.AssureChild<T>(name);
            }
        }

        /// <summary>
        /// Gets a child of the given type with the given name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual T GetChild<T>(string name) where T : PostAddressComponent
        {
            return (from address in GetChildAddresses<T>()
                    where String.Equals(
                        address.Name,
                        name,
                        StringComparison.CurrentCultureIgnoreCase)
                    select address).FirstOrDefault();
        }

        /// <summary>
        /// Assures that a child of the given type with the given name exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual T AssureChild<T>(string name) where T : PostAddressComponent
        {
            T child = GetChild<T>(name);

            if (child == null)
            {
                PostAddressComponent.Kind childKind = (PostAddressComponent.Kind)Kind.Of<T>();
                child = childKind.New<T>();
                child.Name = name;
                child.SetPartOf(this);
            }

            return child;
        }
    }
}
