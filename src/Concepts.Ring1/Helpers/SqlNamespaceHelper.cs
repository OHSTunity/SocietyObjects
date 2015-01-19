/*
      =========================================================
      $Id: //SocietyObjects/Dev/NextMark/Concepts/Ring1/Helpers/SqlNamespaceHelper.cs#8 $
      $DateTime: 2010/11/17 11:45:23 $
      $Change: 38753 $
      $Author: careri $
      =========================================================
*/


using System;

namespace Concepts.Ring1
{
    /// <summary>
    /// Assures that a namespace is safe to use with sql.
    /// That means putting brackets around SQL-keywords within the namespace.
    /// </summary>
    public static class SqlNamespaceHelper
    {
        public static string GetSafe<T>()
        {
            return GetSafe(typeof(T));
        }

        public static string GetSafe(Type type)
        {
            return GetSafe(type.FullName);
        }

        public static string GetSafe(string namespaceStr)
        {
            // Worst case scenario is that the namespace consist of only single chars, e.g. A.B.C.D.E.F.G
            // Then the required buffer is length * 2, plus one extra for the trailing ]
            char[] buffer = new char[namespaceStr.Length * 2 + 1];
            int delta = 0;
           // buffer[0] = "";//'[';

            for (int i = 0; i < namespaceStr.Length; i++)
            {
                char c = namespaceStr[i];
                int newPos = i + delta;

                switch (c)
                {
                    case '.':
                    case '+':
                        // insert brackets
                        //buffer[newPos] = ']';
                        buffer[newPos] = '.';
                        //buffer[newPos + 2] = '[';
                        delta += 0;
                        break;
                    default:
                        buffer[newPos] = c;
                        break;
                }
            }
           // buffer[namespaceStr.Length + delta++] = ']';

            return new string(buffer, 0, namespaceStr.Length + delta);
        }
    }
}