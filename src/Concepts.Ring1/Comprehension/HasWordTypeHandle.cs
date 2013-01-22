using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starcounter;
using System.Diagnostics;
using System.Threading;
using System.Linq.Expressions;
using System.IO;

namespace Concepts.Ring1
{
  /* TODO
    
    
    /// <summary>
    /// This is used instead of the Kind of Something.
    /// </summary>
    public sealed class HasWordTypeHandle : Entity, IObjectIDProvider
    {
        public static IApplicationStartupPlugin GetInitPlugin()
        {
            return new TypeRepository();
        }       

        private class TypeRepository : IPrioritizedApplicationStartupPlugin
        {
            private static readonly Dictionary<ulong, Func<Word, Something, WordIndexAttribute.Kind, HasWord>> _newFunctionsPerType =
                new Dictionary<ulong, Func<Word, Something, WordIndexAttribute.Kind, HasWord>>();
            private static readonly Dictionary<Type, ulong> _handlesByType =
                new Dictionary<Type, ulong>();
            private static readonly Dictionary<ulong, Type> _typeByHandle =
                new Dictionary<ulong, Type>();

            #region IPrioritizedApplicationStartupPlugin Members

            public int Priority
            {
                get { return int.MaxValue; }
            }

            #endregion

            #region IApplicationStartupPlugin Members

            public IApplicationStartupPlugin[] Dependencies
            {
                get { return null; }
            }

            public void Execute(HostContext hostContext, LogSource startupLog)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Loading Word Index Framework");

                using (Transaction t = Transaction.NewCurrent(AccessMode.ReadWrite, 0))
                {
                    try
                    {
                        // Create new functions for all HasWord-types
                        TypeSearcher typeSearcher = new TypeSearcher();
                        string typeField = "name";
                        string query = string.Format(
                            "SELECT h FROM {0} h where h.TypeName=VAR(String, {1})",
                            SqlNamespaceHelper.GetSafe<HasWordTypeHandle>(),
                            typeField);
                        var sqlE = Sql.GetEnumerator<HasWordTypeHandle>(query);
                        var paramWord = Expression.Parameter(typeof(Word), "word");
                        var paramOwner = Expression.Parameter(typeof(Something), "owner");
                        var paramAttr = Expression.Parameter(typeof(WordIndexAttribute.Kind), "attr");

                        foreach (var hasWordType in typeSearcher.FindBySubclass(typeof(HasWord), TypeSearchOptions.ExcludeAbstracts))
                        {
                            sb.Append("\t" + hasWordType.FullName);
                            string fullName = hasWordType.FullName;
                            sqlE.SetVariable(typeField, fullName);
                            var typeHandle = sqlE.FirstOrDefault();

                            if (typeHandle == null)
                            {
                                sb.Append(" - Created new HasWordTypeHandle");
                                typeHandle = new HasWordTypeHandle(fullName);
                            }

                            var typeArgs = new Type[] 
                            { 
                                typeof(Word), typeof(Something), typeof(WordIndexAttribute.Kind)
                            };
                            var ci = hasWordType.GetConstructor(typeArgs);

                            if (ci == null)
                            {
                                throw new ApplicationException(string.Format(
                                    "Failed to find a constructor for {0} on the format public void {1}({2})",
                                    hasWordType.FullName, 
                                    hasWordType.Name,
                                    string.Join(", ", (from ta in typeArgs select ta.FullName).ToArray())));
                            }

                            _handlesByType[hasWordType] = typeHandle.ObjectID;
                            _typeByHandle[typeHandle.ObjectID] = hasWordType;
                            _newFunctionsPerType[typeHandle.ObjectID] = Expression.Lambda<Func<Word, Something, WordIndexAttribute.Kind, HasWord>>(
                                Expression.New(ci, paramWord, paramOwner, paramAttr),
                                paramWord,
                                paramOwner,
                                paramAttr).Compile();
                            sqlE.Reset();
                        }
                    }
                    catch (Exception e)
                    {
                        sb.AppendLine();
                        sb.AppendFormat("Failed to setup Word Index Framework:\r\n{0}\r\n{1}", e.Message, e.StackTrace).AppendLine();
                        startupLog.Notice(sb.ToString());
                        throw e;
                    }
                    t.Commit();
                }
                startupLog.Notice(sb.ToString());
            }

            #endregion

            public static Func<Word, Something, WordIndexAttribute.Kind, HasWord> GetNewFunc(HasWordTypeHandle handle)
            {
                return _newFunctionsPerType[handle.ObjectID];
            }

            internal static Type GetType(HasWordTypeHandle typeHandle)
            {
                return _typeByHandle[typeHandle.ObjectID];
            }

            internal static HasWordTypeHandle GetHandle(Type hasWordType)
            {
                return (HasWordTypeHandle)DbHelper.FromID(_handlesByType[hasWordType]);
            }
        }

        private HasWordTypeHandle(string typeName)
        {
            TypeName = typeName;
        }

        #region IObjectIDProvider Members

        public ulong ObjectID { get { return DbHelper.GetObjectID(this); } }

        #endregion



        /// <summary>
        /// The fullname of the type.
        /// </summary>
        public readonly string TypeName;

        public Type HasWordType
        {
            get
            {
                return TypeRepository.GetType(this);
            }
        }

        internal HasWord New(Word word, Something something, WordIndexAttribute.Kind attrKind)
        {
            return TypeRepository.GetNewFunc(this).Invoke(word, something, attrKind);
        }

        internal static HasWordTypeHandle GetHandle(Type hasWordType)
        {
            return TypeRepository.GetHandle(hasWordType);
        }
    } */
}
