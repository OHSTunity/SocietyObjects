// NOT a part of Society Objects (not a persistent object). Should be placed in Starcounter or in another library.
// If no other alternative, put in Ring1.System

using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.Ring1
{
    /// <summary>
    /// Attribute used to mark words.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class WordAttribute : System.Attribute
    {
        public WordAttribute(Type hasWordType)
        {
            if (hasWordType.IsAbstract)
            {
                throw new ArgumentException("The has word relation cant be abstract, please inherit HasWord");
            }
            HasWordType = hasWordType;
        }

        public readonly Type HasWordType;
    }
}
